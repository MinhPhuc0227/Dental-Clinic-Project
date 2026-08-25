using DentalClinic.BLL;
using DentalClinic.DAL;
using DentalClinic.DTO;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class UC_Doctor_Examination : UserControl
    {
        private readonly Visit_BLL _visitBLL;
        private readonly Service_BLL _serviceBLL = new Service_BLL();
        private readonly Medicine_BLL _medicineBLL = new Medicine_BLL();
        private readonly MedicalRecord_BLL _medicalRecordBLL = new MedicalRecord_BLL(new MedicalRecord_DAL(new AppDbContext()));
        private readonly int _doctorId;
        private int _currentVisitId = 0;

        // Quản lý danh sách dịch vụ và thuốc được chọn tạm thời trên giao diện
        private BindingList<SelectedServiceDto> _selectedServices = new BindingList<SelectedServiceDto>();
        private BindingList<SelectedMedicineDto> _selectedMedicines = new BindingList<SelectedMedicineDto>();

        // Lưu giá tiền tạm thời (Sau này có thể thay bằng giá thực tế từ Database)
        private Dictionary<int, decimal> _servicePrices = new Dictionary<int, decimal>();
        private Dictionary<int, decimal> _medicinePrices = new Dictionary<int, decimal>();

        public UC_Doctor_Examination(Visit_BLL visitBLL, int doctorId)
        {
            InitializeComponent();
            _visitBLL = visitBLL;
            _doctorId = doctorId;
        }

        private void UC_Doctor_Examination_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadWaitingQueue();
            ClearPatientInfo();

            // Khởi tạo các tính năng cho Dịch vụ & Thuốc mới thêm
            InitPrescriptionAndServiceFeatures();
            LoadServiceAndMedicineData();
        }

        private void SetupDataGridView()
        {
            dgvWaitingQueue.AutoGenerateColumns = false;
            dgvWaitingQueue.Columns.Clear();

            // Cột ẩn : Lưu mã VisitId để khi click vào biết đang chọn ca khám nào
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VisitId",
                Name = "VisitId",
                Visible = false
            });

            // Cột STT (Queue Number) 
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "QueueNumber",
                HeaderText = "STT",
                Width = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9, FontStyle.Bold) }
            });

            // Cột giờ nhận 
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CheckInDateTime",
                HeaderText = "Giờ Nhận",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm", Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Cột tên bệnh nhân
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PatientName",
                HeaderText = "Bệnh Nhân",
                Width = 140
            });

            // Cột loại bệnh nhân
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AppointmentBadge",
                HeaderText = "Loại",
                Width = 140
            });

            // Cột Lý do khám
            dgvWaitingQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReasonForVisit",
                HeaderText = "Lý Do Khám",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvWaitingQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWaitingQueue.ReadOnly = true;
            dgvWaitingQueue.AllowUserToAddRows = false;
            dgvWaitingQueue.RowHeadersVisible = false;
        }

        public void LoadWaitingQueue()
        {
            try
            {
                var result = _visitBLL.GetWaitingQueue(DateTime.Today, "", _doctorId, VisitStatus.Waiting);

                if (result.IsSuccess && result.Data != null)
                {
                    dgvWaitingQueue.DataSource = result.Data;
                    dgvWaitingQueue.ClearSelection();
                }
                else
                {
                    dgvWaitingQueue.DataSource = null;
                    ClearPatientInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chờ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearPatientInfo()
        {
            lbFullName.Text = "...";
            lbPhone.Text = "...";
            lbPatientNote.Text = "...";
            lbReasonForVisit.Text = "...";
            lbAppointmentNote.Text = "...";
            lbPatientNote.ForeColor = Color.Black;
        }

        private void dgvWaitingQueue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvWaitingQueue.Rows[e.RowIndex].DataBoundItem is WaitingQueueDto selectedVisit)
                {
                    // LOAD DỮ LIỆU PATIENT LÊN PANEL LEFT (thông tin cá nhân, lịch hẹn, tiếp nhận)
                    _currentVisitId = selectedVisit.VisitId;
                    lbFullName.Text = selectedVisit.PatientName;
                    lbPhone.Text = selectedVisit.PatientPhone;

                    lbReasonForVisit.Text = string.IsNullOrWhiteSpace(selectedVisit.ReasonForVisit)
                        ? "Không có" : selectedVisit.ReasonForVisit;

                    lbPatientNote.Text = string.IsNullOrWhiteSpace(selectedVisit.PatientNote)
                        ? "Không có" : selectedVisit.PatientNote;

                    lbAppointmentNote.Text = string.IsNullOrWhiteSpace(selectedVisit.AppointmentNote)
                        ? "Không có hẹn / Không có ghi chú" : selectedVisit.AppointmentNote;

                    lbExaminationDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                    // RESET VÀ LOAD DỮ LIỆU PATIENT LÊN PANEL RIGHT (nếu có lưu tạm)

                    // 1. Reset giao diện right panel 
                    lbMedicalRecordId.Text = "...";
                    txtDiagnosis.Clear();
                    txtConclusion.Clear();
                    _selectedServices.Clear();
                    _selectedMedicines.Clear();
                    CalculateTotal();

                    // 2. Đổ dữ liệu lưu nháp lên giao diện (nếu có): chẩn đoán, kết luận, dịch vụ, thuốc
                    var draftRecord = _medicalRecordBLL.GetDraftRecord(_currentVisitId);

                    if (draftRecord != null)
                    {
                        lbMedicalRecordId.Text = draftRecord.MedicalRecordId.ToString();
                        txtDiagnosis.Text = draftRecord.Diagnosis;
                        txtConclusion.Text = draftRecord.Conclusion;

                        foreach (var s in draftRecord.Services)
                        {
                            _selectedServices.Add(s);
                        }

                        foreach (var m in draftRecord.Medicines)
                        {
                            _selectedMedicines.Add(m);
                        }

                        CalculateTotal();
                    }
                }
            }
        }

        private void InitPrescriptionAndServiceFeatures()
        {
            // 1. Cấu hình ComboBox cho phép gõ tìm kiếm (Autocomplete)
            SetupAutocompleteComboBox(cbService);
            SetupAutocompleteComboBox(cbMedicine);

            // 2. Setup 2 DataGridView (dgvService và dgvMedicine)
            SetupServiceDataGridView();
            SetupMedicineDataGridView();

            // (Lưu ý: Sau này bạn gọi hàm load danh sách dịch vụ/thuốc từ BLL vào cbService và cbMedicine ở đây)
        }

        private void SetupAutocompleteComboBox(ComboBox cb)
        {
            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void SetupServiceDataGridView()
        {
            dgvService.AutoGenerateColumns = false;
            dgvService.Columns.Clear();

            dgvService.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServiceId", Visible = false });
            dgvService.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServiceName", HeaderText = "Tên Dịch Vụ", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvService.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", Width = 60 }); // Cho phép sửa SL trực tiếp
            dgvService.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn Giá", ReadOnly = true, Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvService.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalPrice", HeaderText = "Thành Tiền", ReadOnly = true, Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });

            DataGridViewButtonColumn delCol = new DataGridViewButtonColumn { Name = "colDel", HeaderText = "Xóa", Text = "X", UseColumnTextForButtonValue = true, Width = 50 };
            delCol.DefaultCellStyle.ForeColor = Color.Red;
            dgvService.Columns.Add(delCol);

            dgvService.DataSource = _selectedServices;
            dgvService.AllowUserToAddRows = false;
            dgvService.RowHeadersVisible = false;
        }

        private void SetupMedicineDataGridView()
        {
            dgvMedicine.AutoGenerateColumns = false;
            dgvMedicine.Columns.Clear();

            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicineId", Visible = false });
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicineName", HeaderText = "Tên Thuốc", ReadOnly = true, Width = 150 });

            // Các cột số lượng hiển thị gọn gàng
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Morning", HeaderText = "Sáng", Width = 50 });
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Noon", HeaderText = "Trưa", Width = 50 });
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Afternoon", HeaderText = "Chiều", Width = 55 });
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Evening", HeaderText = "Tối", Width = 50 });
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Days", HeaderText = "Ngày", Width = 50 });

            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Instruction", HeaderText = "Cách dùng", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Tổng SL", Width = 65 });

            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn giá", ReadOnly = true, Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvMedicine.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalPrice", HeaderText = "Thành tiền", ReadOnly = true, Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });

            DataGridViewButtonColumn delCol = new DataGridViewButtonColumn { Name = "colDelMed", HeaderText = "Xóa", Text = "X", UseColumnTextForButtonValue = true, Width = 40 };
            delCol.DefaultCellStyle.ForeColor = Color.Red;
            dgvMedicine.Columns.Add(delCol);

            dgvMedicine.DataSource = _selectedMedicines;
            dgvMedicine.AllowUserToAddRows = false;
            dgvMedicine.RowHeadersVisible = false;
        }

        private void LoadServiceAndMedicineData()
        {
            // 1. Load Dịch vụ từ Service_BLL
            var serviceResult = _serviceBLL.GetAll();
            if (serviceResult.IsSuccess && serviceResult.Data != null)
            {
                _servicePrices.Clear();
                foreach (var s in serviceResult.Data)
                {
                    // Lưu đơn giá vào từ điển để tra cứu nhanh khi bác sĩ bấm nút Thêm
                    _servicePrices[s.ServiceId] = s.UnitPrice;
                }

                cbService.DataSource = serviceResult.Data;
                cbService.DisplayMember = "ServiceName"; // Hiển thị tên dịch vụ lên ComboBox
                cbService.ValueMember = "ServiceId";     // Giá trị ngầm bên dưới là ID
                cbService.SelectedIndex = -1;            // Không chọn sẵn dòng nào khi mới mở
            }

            // 2. Load Thuốc từ Medicine_BLL
            var medicineResult = _medicineBLL.GetAll();
            if (medicineResult.IsSuccess && medicineResult.Data != null)
            {
                _medicinePrices.Clear();
                foreach (var m in medicineResult.Data)
                {
                    // Lưu đơn giá thuốc vào từ điển
                    _medicinePrices[m.MedicineId] = m.UnitPrice;
                }

                cbMedicine.DataSource = medicineResult.Data;
                cbMedicine.DisplayMember = "MedicineName"; // Hiển thị tên thuốc lên ComboBox
                cbMedicine.ValueMember = "MedicineId";     // Giá trị ngầm là ID
                cbMedicine.SelectedIndex = -1;
            }
        }

        private void btAddService_Click(object sender, EventArgs e)
        {
            if (cbService.SelectedValue is not int serviceId)
            {
                serviceId = 1;
            }

            int qty = (int)nudServiceQuantity.Value;
            if (qty <= 0) qty = 1;

            string serviceName = cbService.Text;
            decimal unitPrice = _servicePrices.ContainsKey(serviceId) ? _servicePrices[serviceId] : 200000; // Giá mặc định mẫu

            var existing = _selectedServices.FirstOrDefault(s => s.ServiceId == serviceId);
            if (existing != null)
            {
                existing.Quantity += qty;
            }
            else
            {
                _selectedServices.Add(new SelectedServiceDto
                {
                    ServiceId = serviceId,
                    ServiceName = string.IsNullOrEmpty(serviceName) ? "Dịch vụ mẫu" : serviceName,
                    Quantity = qty,
                    UnitPrice = unitPrice
                });
            }

            dgvService.Refresh();
            CalculateTotal();
        }

        private void btAddMedicine_Click(object sender, EventArgs e)
        {
            if (cbMedicine.SelectedValue is not int medicineId)
            {
                medicineId = 1;
            }

            int morning = (int)nudMorning.Value;
            int noon = (int)nudNoon.Value;
            int afternoon = (int)nudAfternoon.Value;
            int evening = (int)nudEvening.Value;
            int days = (int)nudDays.Value;

            int tempQty = (morning + noon + afternoon + evening) * days;

            if (tempQty <= 0)
            {
                MessageBox.Show("Vui lòng kê ít nhất 1 viên thuốc (nhập số lượng vào các buổi)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string medName = cbMedicine.Text;
            string instruction = cbInstruction.Text.Trim();
            decimal unitPrice = _medicinePrices.ContainsKey(medicineId) ? _medicinePrices[medicineId] : 10000;

            // Kiểm tra thuốc đã tồn tại trong dgv chưa
            var existingMedicine = _selectedMedicines.FirstOrDefault(m => m.MedicineId == medicineId);

            if (existingMedicine != null)
            {
                // Nếu đã tồn tại -> Cập nhật dữ liệu mới
                existingMedicine.Morning = morning;
                existingMedicine.Noon = noon;
                existingMedicine.Afternoon = afternoon;
                existingMedicine.Evening = evening;
                existingMedicine.Days = days;
                existingMedicine.Instruction = instruction;
            }
            else
            {
                // Nếu không tồn tại -> Thêm dòng mới
                _selectedMedicines.Add(new SelectedMedicineDto
                {
                    MedicineId = medicineId,
                    MedicineName = string.IsNullOrEmpty(medName) ? "Thuốc mẫu" : medName,
                    Morning = morning,
                    Noon = noon,
                    Afternoon = afternoon,
                    Evening = evening,
                    Days = days,
                    Instruction = instruction,
                    UnitPrice = unitPrice
                });
            }

            // Refresh dgv, tính lại tổng tiền
            dgvMedicine.Refresh();
            CalculateTotal();

            // Reset giao diện để nhập mới
            nudMorning.Value = 0;
            nudNoon.Value = 0;
            nudAfternoon.Value = 0;
            nudEvening.Value = 0;
            nudDays.Value = 1;
            cbInstruction.Text = "";
            cbMedicine.Focus();
        }

        private void dgvService_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvService.Refresh();
            CalculateTotal();
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvService.Columns[e.ColumnIndex].Name == "colDel")
            {
                _selectedServices.RemoveAt(e.RowIndex);
                CalculateTotal();
            }
        }

        private void dgvMedicine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvMedicine.Refresh();
            CalculateTotal();
        }

        private void dgvMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMedicine.Columns[e.ColumnIndex].Name == "colDelMed")
            {
                _selectedMedicines.RemoveAt(e.RowIndex);
                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            decimal serviceTotal = _selectedServices.Sum(s => s.TotalPrice);
            decimal medicineTotal = _selectedMedicines.Sum(m => m.TotalPrice);
            decimal grandTotal = serviceTotal + medicineTotal;

            lbServiceAmount.Text = serviceTotal.ToString("N0") + " VNĐ";
            lbMedicineAmount.Text = medicineTotal.ToString("N0") + " VNĐ";
            lbTotalAmount.Text = grandTotal.ToString("N0") + " VNĐ";
        }

        private void btSaveDraft_Click(object sender, EventArgs e)
        {
            ProcessSaveMedicalRecord(isDraft: true);
        }

        private void btComplete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Vui lòng nhập Chẩn đoán trước khi hoàn thành khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnosis.Focus();
                return;
            }

            var confirm = MessageBox.Show("Xác nhận hoàn thành ca khám?\nHồ sơ sẽ được chốt và chuyển ra quầy thu ngân.",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                ProcessSaveMedicalRecord(isDraft: false);
            }
        }

        private void ProcessSaveMedicalRecord(bool isDraft)
        {
            if (_currentVisitId == 0)
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân từ danh sách chờ để thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Map dữ liệu trên giao diện vào dto 
            var recordData = new SaveMedicalRecordDto
            {
                VisitId = _currentVisitId,
                DoctorId = _doctorId,
                Diagnosis = txtDiagnosis.Text.Trim(),
                Conclusion = txtConclusion.Text.Trim(),
                Services = _selectedServices.ToList(),
                Medicines = _selectedMedicines.ToList(),
                IsDraft = isDraft
            };

            try
            {
                // Gọi BLL lưu dữ liệu vào dtb
                var result = _medicalRecordBLL.SaveRecord(recordData);

                if (result.IsSuccess)
                {
                    if (isDraft)
                    {
                        lbMedicalRecordId.Text = recordData.MedicalRecordId.ToString();
                        MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hoàn thành ca khám! Bệnh nhân đã được chuyển trạng thái sang Chờ thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset giao diện, refresh dgv
                        _currentVisitId = 0;
                        ClearPatientInfo();
                        txtDiagnosis.Clear();
                        txtConclusion.Clear();
                        _selectedServices.Clear();
                        _selectedMedicines.Clear();
                        CalculateTotal();
                        LoadWaitingQueue();
                    }
                }
                else
                {
                    MessageBox.Show(result.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình xử lý: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btViewMedicalHistory_Click(object sender, EventArgs e)
        {
            Dialog_PatientHistory diaglog = new Dialog_PatientHistory(_currentVisitId, lbFullName.Text);
            diaglog.ShowDialog();
        }

        private void dgvWaitingQueue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvWaitingQueue.Rows[e.RowIndex].DataBoundItem is WaitingQueueDto item)
            {
                if (item.IsAppointment)
                {
                    dgvWaitingQueue.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 245, 230);
                }
            }
        }
    }
}