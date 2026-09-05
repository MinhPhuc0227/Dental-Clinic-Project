using DentalClinic.BLL;
using DentalClinic.DTO;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class Dialog_Treatment : Form
    {
        private readonly Treatment_BLL _treatmentBLL;
        private readonly Service_BLL _serviceBLL;
        private readonly Doctor_BLL _doctorBLL;

        public bool IsTreatmentCreated { get; private set; } = false;
        public int CreatedTreatmentId { get; private set; } = 0;
        private readonly int? _initialServiceId;
        private string _doctorName = "...";

        // Bệnh nhân hiện tại
        private readonly int _patientId;

        // Bác sĩ đang đăng nhập
        private readonly int _doctorId;

        // Visit hiện tại đang được bác sĩ khám
        private readonly int _currentVisitId;

        // Treatment đang được chọn
        private int _selectedTreatmentId = 0;

        // Chế độ
        private bool _isAdding = false;
        private bool _isEditing = false;

        public Dialog_Treatment(
    Treatment_BLL treatmentBLL,
    Service_BLL serviceBLL,
    int patientId,
    int doctorId,
    int currentVisitId,
    string doctorName,
    int? initialServiceId = null)
        {
            InitializeComponent();

            _treatmentBLL = treatmentBLL;
            _serviceBLL = serviceBLL;

            _patientId = patientId;
            _doctorId = doctorId;
            _currentVisitId = currentVisitId;
            _doctorName = doctorName;
            _initialServiceId = initialServiceId;
        }

        private string GetCurrentDoctorName()
        {
            var result = _doctorBLL.GetById(_doctorId);

            if (result.IsSuccess && result.Data != null)
                return result.Data.FullName;

            return "...";
        }

        // =========================================================
        // LOAD
        // =========================================================

        private void Dialog_Treatment_Load(object? sender, EventArgs e)
        {
            SetupTreatmentGrid();
            SetupTreatmentSessionGrid();

            LoadServices();
            LoadStatus();
            LoadTreatments();

            // Mở ở chế độ thêm mới
            if (_initialServiceId.HasValue)
            {
                SetAddMode();

                cbService.SelectedValue = _initialServiceId.Value;

                lbDoctorName.Text = _doctorName;
            }
            else
            {
                SetViewMode();
            }
        }

        // =========================================================
        // SETUP DATAGRIDVIEW TREATMENT
        // =========================================================

        private void SetupTreatmentGrid()
        {
            dgvTreatments.AutoGenerateColumns = false;
            dgvTreatments.Columns.Clear();

            dgvTreatments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TreatmentId",
                    Name = "TreatmentId",
                    Visible = false
                });

            dgvTreatments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ServiceName",
                    Name = "colServiceName",
                    HeaderText = "Dịch vụ",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

            dgvTreatments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "StartDate",
                    Name = "colStartDate",
                    HeaderText = "Ngày bắt đầu",
                    Width = 105,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy"
                    }
                });

            dgvTreatments.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "StatusDisplay",
                    Name = "colStatus",
                    HeaderText = "Trạng thái",
                    Width = 120
                });

            dgvTreatments.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colDelete",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true,
                    Width = 65,
                    FlatStyle = FlatStyle.Flat
                });

            dgvTreatments.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTreatments.MultiSelect = false;
            dgvTreatments.ReadOnly = true;
            dgvTreatments.AllowUserToAddRows = false;
            dgvTreatments.RowHeadersVisible = false;
        }

        // =========================================================
        // SETUP DATAGRIDVIEW SESSION
        // =========================================================

        private void SetupTreatmentSessionGrid()
        {
            dgvTreatmentSession.AutoGenerateColumns = false;
            dgvTreatmentSession.Columns.Clear();

            dgvTreatmentSession.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "VisitId",
                    Name = "VisitId",
                    Visible = false
                });

            dgvTreatmentSession.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TreatmentSessionNumber",
                    Name = "colSessionNumber",
                    HeaderText = "Buổi",
                    Width = 70,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment =
                            DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvTreatmentSession.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CheckInDateTime",
                    Name = "colSessionDate",
                    HeaderText = "Ngày khám",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy HH:mm"
                    }
                });

            dgvTreatmentSession.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DoctorName",
                    Name = "colSessionDoctor",
                    HeaderText = "Bác sĩ",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });

            dgvTreatmentSession.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "StatusDisplay",
                    Name = "colSessionStatus",
                    HeaderText = "Trạng thái",
                    Width = 120
                });

            dgvTreatmentSession.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTreatmentSession.MultiSelect = false;
            dgvTreatmentSession.ReadOnly = true;
            dgvTreatmentSession.AllowUserToAddRows = false;
            dgvTreatmentSession.RowHeadersVisible = false;
        }

        // =========================================================
        // LOAD TREATMENTS
        // =========================================================

        private void LoadTreatments()
        {
            try
            {
                var result =
                    _treatmentBLL.GetByPatientId(_patientId);

                if (!result.IsSuccess || result.Data == null)
                {
                    dgvTreatments.DataSource = null;

                    ClearTreatmentDetails();
                    ClearSessionGrid();

                    return;
                }

                dgvTreatments.DataSource = result.Data;

                dgvTreatments.ClearSelection();

                _selectedTreatmentId = 0;

                ClearTreatmentDetails();
                ClearSessionGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải danh sách kế hoạch điều trị:\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD SERVICES
        // =========================================================

        private void LoadServices()
        {
            try
            {
                var result = _serviceBLL.GetAll();

                if (!result.IsSuccess || result.Data == null)
                {
                    cbService.DataSource = null;
                    return;
                }

                var longTermServices = result.Data
                    .Where(s => s.IsLongTerm)
                    .ToList();

                cbService.DataSource = longTermServices;
                cbService.DisplayMember = "ServiceName";
                cbService.ValueMember = "ServiceId";

                cbService.SelectedIndex = -1;

                lbTotalAmount.Text = "0 VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải danh sách dịch vụ:\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD STATUS
        // =========================================================

        private void LoadStatus()
        {
            cbStatus.DataSource =
                Enum.GetValues<TreatmentStatus>();

            cbStatus.FormattingEnabled = true;

            cbStatus.Format += (sender, e) =>
            {
                if (e.ListItem is TreatmentStatus status)
                {
                    e.Value = GetTreatmentStatusText(status);
                }
            };

            cbStatus.SelectedItem =
                TreatmentStatus.InProgress;
        }

        private string GetTreatmentStatusText(
            TreatmentStatus status)
        {
            return status switch
            {
                TreatmentStatus.InProgress =>
                    "Đang thực hiện",

                TreatmentStatus.Completed =>
                    "Đã hoàn thành",

                TreatmentStatus.Cancelled =>
                    "Đã hủy",

                _ => "Không xác định"
            };
        }

        // =========================================================
        // CHỌN SERVICE
        // =========================================================

        private void cbService_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (cbService.SelectedItem is ServiceDto service)
            {
                lbTotalAmount.Text =
                    service.UnitPrice.ToString("N0") + " VNĐ";
            }
            else
            {
                lbTotalAmount.Text = "0 VNĐ";
            }
        }

        // =========================================================
        // CHỌN TREATMENT
        // =========================================================

        private void dgvTreatments_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            string columnName =
                dgvTreatments.Columns[e.ColumnIndex].Name;

            // Nút Xóa
            if (columnName == "colDelete")
            {
                DeleteTreatment(e.RowIndex);
                return;
            }

            if (dgvTreatments.Rows[e.RowIndex].DataBoundItem
                is TreatmentDto treatment)
            {
                LoadTreatmentDetails(treatment);
            }
        }

        private void LoadTreatmentDetails(
            TreatmentDto treatment)
        {
            _selectedTreatmentId =
                treatment.TreatmentId;

            _isAdding = false;
            _isEditing = false;

            // Dịch vụ
            cbService.SelectedValue =
                treatment.ServiceId;

            // Bác sĩ
            lbDoctorName.Text =
                treatment.DoctorName;

            // Ngày bắt đầu
            dtpStartDate.Value =
                treatment.StartDate;

            // Ngày kết thúc
            dtpEndDate.Value =
                treatment.EndDate ?? treatment.StartDate;

            // Số buổi dự kiến
            decimal plannedSessions =
                treatment.PlannedSessions ?? 0;

            if (plannedSessions < nudPlannedSessions.Minimum)
                plannedSessions = nudPlannedSessions.Minimum;

            if (plannedSessions > nudPlannedSessions.Maximum)
                plannedSessions = nudPlannedSessions.Maximum;

            nudPlannedSessions.Value =
                plannedSessions;

            // Tổng chi phí
            lbTotalAmount.Text =
                treatment.TotalAmount.ToString("N0") +
                " VNĐ";

            // Trạng thái
            cbStatus.SelectedItem =
                treatment.Status;

            // Ghi chú
            textBox1.Text =
                treatment.Note ?? string.Empty;

            // Tiến độ
            lbCompletedSessions.Text =
                treatment.CompletedSessions.ToString();

            lbProgress.Text =
                $"{treatment.ProgressPercent:0.##}%";

            // Load session
            LoadTreatmentSessions(
                treatment.TreatmentId);

            SetViewMode();
        }

        // =========================================================
        // LOAD SESSION
        // =========================================================

        private void LoadTreatmentSessions(
            int treatmentId)
        {
            try
            {
                var result =
                    _treatmentBLL.GetVisits(treatmentId);

                if (!result.IsSuccess ||
                    result.Data == null)
                {
                    dgvTreatmentSession.DataSource = null;
                    return;
                }

                dgvTreatmentSession.DataSource =
                    result.Data;

                dgvTreatmentSession.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải các buổi điều trị:\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearSessionGrid()
        {
            dgvTreatmentSession.DataSource = null;
        }

        // =========================================================
        // CHỈNH SỬA
        // =========================================================

        private void btEditTreatment_Click(
            object? sender,
            EventArgs e)
        {
            if (_selectedTreatmentId <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn một kế hoạch điều trị.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Không cho chỉnh sửa kế hoạch đã hoàn thành
            if (cbStatus.SelectedItem is TreatmentStatus status &&
                status == TreatmentStatus.Completed)
            {
                MessageBox.Show(
                    "Kế hoạch điều trị đã hoàn thành nên không thể chỉnh sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            _isEditing = true;
            _isAdding = false;

            cbService.Enabled = false;
            lbDoctorName.Enabled = false;

            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            nudPlannedSessions.Enabled = true;
            textBox1.ReadOnly = false;

            // Trạng thái không chỉnh sửa ở đây
            cbStatus.Enabled = false;

            btEditTreatment.Enabled = false;

            btSave.Visible = true;
            btCancel.Visible = true;
        }

        // =========================================================
        // LƯU
        // =========================================================

        private void btSave_Click(
            object? sender,
            EventArgs e)
        {
            SaveTreatment();
        }

        private void SaveTreatment()
        {
            // -------------------------
            // Validation chung
            // -------------------------

            if (cbService.SelectedValue is not int serviceId)
            {
                MessageBox.Show(
                    "Vui lòng chọn dịch vụ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbService.Focus();
                return;
            }

            if (nudPlannedSessions.Value <= 0)
            {
                MessageBox.Show(
                    "Số buổi dự kiến phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                nudPlannedSessions.Focus();
                return;
            }

            if (dtpEndDate.Value.Date <
                dtpStartDate.Value.Date)
            {
                MessageBox.Show(
                    "Ngày kết thúc không được trước ngày bắt đầu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpEndDate.Focus();
                return;
            }

            // =====================================================
            // THÊM MỚI
            // =====================================================

            if (_isAdding)
            {
                var dto = new CreateTreatmentDto
                {
                    PatientId = _patientId,

                    DoctorId = _doctorId,

                    ServiceId = serviceId,

                    StartDate =
                        dtpStartDate.Value.Date,

                    EndDate =
                        dtpEndDate.Value.Date,

                    PlannedSessions =
                        (int)nudPlannedSessions.Value,

                    Note =
                        string.IsNullOrWhiteSpace(textBox1.Text)
                            ? null
                            : textBox1.Text.Trim()
                };

                var result =
                    _treatmentBLL.Add(dto);

                if (!result.IsSuccess)
                {
                    MessageBox.Show(
                        result.Message,
                        "Không thể lưu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                IsTreatmentCreated = true;

                MessageBox.Show(
                    result.Message,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Sau khi tạo xong
                _isAdding = false;

                SetViewMode();

                LoadTreatments();

                return;
            }

            // =====================================================
            // CHỈNH SỬA
            // =====================================================

            if (_isEditing)
            {
                if (_selectedTreatmentId <= 0)
                    return;

                var status =
                    cbStatus.SelectedItem is TreatmentStatus treatmentStatus
                        ? treatmentStatus
                        : TreatmentStatus.InProgress;

                var dto = new UpdateTreatmentDto
                {
                    TreatmentId =
                        _selectedTreatmentId,

                    DoctorId =
                        _doctorId,

                    ServiceId =
                        serviceId,

                    StartDate =
                        dtpStartDate.Value.Date,

                    EndDate =
                        dtpEndDate.Value.Date,

                    PlannedSessions =
                        (int)nudPlannedSessions.Value,

                    Status =
                        status,

                    Note =
                        string.IsNullOrWhiteSpace(textBox1.Text)
                            ? null
                            : textBox1.Text.Trim()
                };

                var result =
                    _treatmentBLL.Update(dto);

                if (!result.IsSuccess)
                {
                    MessageBox.Show(
                        result.Message,
                        "Không thể cập nhật",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show(
                    result.Message,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                int treatmentId =
                    _selectedTreatmentId;

                _isEditing = false;

                LoadTreatmentsBySelectedId(
                    treatmentId);
            }
        }

        // =========================================================
        // HỦY
        // =========================================================

        private void btCancel_Click(
            object? sender,
            EventArgs e)
        {
            _isAdding = false;
            _isEditing = false;

            btEditTreatment.Enabled = true;

            if (_selectedTreatmentId > 0)
            {
                var result =
                    _treatmentBLL.GetById(
                        _selectedTreatmentId);

                if (result.IsSuccess &&
                    result.Data != null)
                {
                    LoadTreatmentDetails(
                        result.Data);

                    return;
                }
            }

            ClearTreatmentDetails();
        }

        // =========================================================
        // XÓA
        // =========================================================

        private void DeleteTreatment(int rowIndex)
        {
            if (dgvTreatments.Rows[rowIndex]
                .DataBoundItem is not TreatmentDto treatment)
            {
                return;
            }

            // Nếu đã có Visit thì BLL sẽ từ chối,
            // nhưng báo trước cho người dùng.
            if (treatment.CompletedSessions > 0)
            {
                MessageBox.Show(
                    "Không thể xóa kế hoạch vì đã có buổi khám thuộc kế hoạch.",
                    "Không thể xóa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa kế hoạch \"{treatment.ServiceName}\" không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            var result =
                _treatmentBLL.Delete(
                    treatment.TreatmentId);

            MessageBox.Show(
                result.Message,
                result.IsSuccess
                    ? "Thành công"
                    : "Không thể xóa",
                MessageBoxButtons.OK,
                result.IsSuccess
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning);

            if (result.IsSuccess)
            {
                if (_selectedTreatmentId ==
                    treatment.TreatmentId)
                {
                    _selectedTreatmentId = 0;

                    ClearTreatmentDetails();
                    ClearSessionGrid();
                }

                LoadTreatments();
            }
        }

        // =========================================================
        // HOÀN THÀNH
        // =========================================================

        private void btCompleteTreatment_Click(
            object? sender,
            EventArgs e)
        {
            CompleteTreatment();
        }

        private void CompleteTreatment()
        {
            if (_selectedTreatmentId <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn kế hoạch điều trị.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cbStatus.SelectedItem is TreatmentStatus status)
            {
                if (status == TreatmentStatus.Completed)
                {
                    MessageBox.Show(
                        "Kế hoạch điều trị đã hoàn thành.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                if (status == TreatmentStatus.Cancelled)
                {
                    MessageBox.Show(
                        "Kế hoạch điều trị đã bị hủy.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn đánh dấu kế hoạch điều trị này là đã hoàn thành không?",
                "Xác nhận hoàn thành",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            var result =
                _treatmentBLL.Complete(
                    _selectedTreatmentId);

            MessageBox.Show(
                result.Message,
                result.IsSuccess
                    ? "Thành công"
                    : "Không thể hoàn thành",
                MessageBoxButtons.OK,
                result.IsSuccess
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning);

            if (result.IsSuccess)
            {
                LoadTreatmentsBySelectedId(
                    _selectedTreatmentId);
            }
        }

        // =========================================================
        // THÊM BUỔI KHÁM
        // =========================================================

        private void btAddSession_Click(
            object? sender,
            EventArgs e)
        {
            if (_selectedTreatmentId <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn một kế hoạch điều trị.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (_currentVisitId <= 0)
            {
                MessageBox.Show(
                    "Không xác định được buổi khám hiện tại.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Nếu đã hoàn thành thì không thêm buổi
            if (cbStatus.SelectedItem is TreatmentStatus status &&
                status != TreatmentStatus.InProgress)
            {
                MessageBox.Show(
                    "Chỉ có thể thêm buổi khám vào kế hoạch đang thực hiện.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var result =
                _treatmentBLL.AssignVisitToTreatment(
                    _currentVisitId,
                    _selectedTreatmentId);

            MessageBox.Show(
                result.Message,
                result.IsSuccess
                    ? "Thành công"
                    : "Không thể thêm buổi",
                MessageBoxButtons.OK,
                result.IsSuccess
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning);

            if (result.IsSuccess)
            {
                LoadTreatmentsBySelectedId(
                    _selectedTreatmentId);
            }
        }

        // =========================================================
        // CLEAR
        // =========================================================

        private void ClearTreatmentDetails()
        {
            _selectedTreatmentId = 0;

            cbService.SelectedIndex = -1;

            lbDoctorName.Text = "...";

            dtpStartDate.Value =
                DateTime.Today;

            dtpEndDate.Value =
                DateTime.Today;

            nudPlannedSessions.Value = 1;

            lbTotalAmount.Text =
                "0 VNĐ";

            cbStatus.SelectedItem =
                TreatmentStatus.InProgress;

            textBox1.Clear();

            lbCompletedSessions.Text =
                "0";

            lbProgress.Text =
                "0%";

            SetViewMode();
        }

        // =========================================================
        // CHẾ ĐỘ THÊM MỚI
        // =========================================================

        private void SetAddMode()
        {
            _isAdding = true;
            _isEditing = false;
            _selectedTreatmentId = 0;

            cbService.Enabled = true;

            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;

            nudPlannedSessions.Enabled = true;

            textBox1.ReadOnly = false;

            cbStatus.Enabled = false;

            btEditTreatment.Enabled = false;
            btCompleteTreatment.Enabled = false;
            btAddSession.Enabled = false;

            btSave.Visible = true;
            btCancel.Visible = true;
        }

        // =========================================================
        // CHẾ ĐỘ XEM
        // =========================================================

        private void SetViewMode()
        {
            _isAdding = false;
            _isEditing = false;

            cbService.Enabled = false;

            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;

            nudPlannedSessions.Enabled = false;

            textBox1.ReadOnly = true;

            cbStatus.Enabled = false;

            btSave.Visible = false;
            btCancel.Visible = false;

            btEditTreatment.Enabled =
                _selectedTreatmentId > 0;

            btCompleteTreatment.Enabled =
                _selectedTreatmentId > 0 &&
                cbStatus.SelectedItem is TreatmentStatus status &&
                status == TreatmentStatus.InProgress;

            btAddSession.Enabled =
                _selectedTreatmentId > 0 &&
                cbStatus.SelectedItem is TreatmentStatus currentStatus &&
                currentStatus == TreatmentStatus.InProgress;
        }

        // =========================================================
        // RESET + LOAD ADD MODE
        // =========================================================

        public void StartNewTreatment()
        {
            ClearTreatmentDetailsForAdd();
            SetAddMode();

            lbDoctorName.Text = _doctorId.ToString();
        }

        private void ClearTreatmentDetailsForAdd()
        {
            _selectedTreatmentId = 0;

            cbService.SelectedIndex = -1;

            lbDoctorName.Text =
                "...";

            dtpStartDate.Value =
                DateTime.Today;

            dtpEndDate.Value =
                DateTime.Today;

            nudPlannedSessions.Value =
                1;

            lbTotalAmount.Text =
                "0 VNĐ";

            cbStatus.SelectedItem =
                TreatmentStatus.InProgress;

            textBox1.Clear();

            lbCompletedSessions.Text =
                "0";

            lbProgress.Text =
                "0%";

            ClearSessionGrid();
        }

        // =========================================================
        // LOAD LẠI TREATMENT ĐANG CHỌN
        // =========================================================

        private void LoadTreatmentsBySelectedId(
            int treatmentId)
        {
            try
            {
                var result =
                    _treatmentBLL.GetByPatientId(
                        _patientId);

                if (!result.IsSuccess ||
                    result.Data == null)
                {
                    LoadTreatments();
                    return;
                }

                dgvTreatments.DataSource =
                    result.Data;

                dgvTreatments.ClearSelection();

                foreach (DataGridViewRow row
                         in dgvTreatments.Rows)
                {
                    if (row.DataBoundItem
                        is TreatmentDto treatment &&
                        treatment.TreatmentId ==
                        treatmentId)
                    {
                        row.Selected = true;

                        LoadTreatmentDetails(
                            treatment);

                        return;
                    }
                }

                ClearTreatmentDetails();
                ClearSessionGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải lại kế hoạch điều trị:\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SESSION CLICK
        // =========================================================

        private void dgvTreatmentSession_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Hiện tại chỉ chọn Session.
            // MedicalRecord sẽ được xem từ Dialog_PatientHistory
            // bằng TreatmentId.
        }

        public void SetService(int serviceId)
        {
            cbService.SelectedValue = serviceId;
        }
    }
}