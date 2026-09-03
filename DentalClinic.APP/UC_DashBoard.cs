using DentalClinic.BLL;
using DentalClinic.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DentalClinic.APP
{
    public partial class UC_DashBoard : UserControl
    {
        private readonly Dashboard_BLL _dashboardBLL;

        public UC_DashBoard(Dashboard_BLL dashboardBLL)
        {
            InitializeComponent();

            _dashboardBLL = dashboardBLL;
        }

        // =========================================================
        // LOAD
        // =========================================================

        private void UC_DashBoard_Load(
            object sender,
            EventArgs e)
        {
            dtpFrom.Value =
                DateTime.Today;

            dtpTo.Value =
                DateTime.Today;

            SetupCharts();

            SetupLowStockGrid();

            SetupRecentImportGrid();

            SetupPatientGrid();

            LoadDashboard();
        }


        // =========================================================
        // LOAD ALL
        // =========================================================

        public void LoadDashboard()
        {
            if (dtpFrom.Value.Date >
                dtpTo.Value.Date)
            {
                MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DateTime from =
                dtpFrom.Value.Date;

            DateTime to =
                dtpTo.Value.Date;

            LoadSummary(from, to);

            LoadVisitChart(from, to);

            LoadRevenueChart(from, to);

            LoadVisitStatusChart(from, to);

            LoadLowStock();

            LoadRecentImports();

            LoadDoctorChart(from, to);

            LoadPatientStatistics(from, to);
        }


        // =========================================================
        // SUMMARY
        // =========================================================

        private void LoadSummary(
            DateTime from,
            DateTime to)
        {
            var result =
                _dashboardBLL.GetSummary(
                    from,
                    to);

            if (!result.IsSuccess ||
                result.Data == null)
            {
                return;
            }

            var data =
                result.Data;

            lbTodayPatients.Text =
                data.Patients.ToString();

            lbTodayVisits.Text =
                data.Visits.ToString();

            lbTodayRevenue.Text =
                data.Revenue.ToString("N0")
                + " VNĐ";

            lbWaiting.Text =
                data.Waiting.ToString();

            lbWaitingPayment.Text =
                data.WaitingPayment.ToString();

            lbMedicineStock.Text =
                data.MedicineStock.ToString("N0");

            lbTotalMedicines.Text =
                data.TotalMedicines.ToString();

            lbTotalStock.Text =
                data.MedicineStock.ToString("N0");
        }


        // =========================================================
        // CHART SETUP
        // =========================================================

        private void SetupCharts()
        {
            SetupChart(chartVisits);

            SetupChart(chartRevenue);

            SetupChart(chartVisitStatus);

            SetupChart(chartDoctorVisits);
        }


        private void SetupChart(Chart chart)
        {
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.Titles.Clear();

            chart.ChartAreas.Clear();

            var area =
                new ChartArea("MainArea");

            area.AxisX.MajorGrid.Enabled =
                false;

            area.AxisY.MajorGrid.LineColor =
                Color.LightGray;

            area.AxisX.LabelStyle.Font =
                new Font(
                    "Segoe UI",
                    9);

            area.AxisY.LabelStyle.Font =
                new Font(
                    "Segoe UI",
                    9);

            chart.ChartAreas.Add(area);
        }


        // =========================================================
        // VISIT CHART
        // =========================================================

        private void LoadVisitChart(
            DateTime from,
            DateTime to)
        {
            var result =
                _dashboardBLL.GetVisitStatistics(
                    from,
                    to);

            if (!result.IsSuccess ||
                result.Data == null)
            {
                return;
            }

            chartVisits.Series.Clear();
            chartVisits.Titles.Clear();
            chartVisits.Legends.Clear();

            chartVisits.Titles.Add(
                "LƯỢT KHÁM THEO NGÀY");

            var series =
                new Series("Lượt khám")
                {
                    ChartType =
                        SeriesChartType.Column,

                    IsValueShownAsLabel =
                        true
                };

            foreach (var item in result.Data)
            {
                series.Points.AddXY(
                    item.Date.ToString("dd/MM"),
                    item.Count);
            }

            chartVisits.Series.Add(
                series);

            chartVisits.ChartAreas[0]
                .AxisX.Interval = 1;

            chartVisits.ChartAreas[0]
                .AxisY.Minimum = 0;

            chartVisits.ChartAreas[0]
                .AxisY.Interval = 1;
        }


        // =========================================================
        // REVENUE CHART
        // =========================================================

        private void LoadRevenueChart(
            DateTime from,
            DateTime to)
        {
            var result =
                _dashboardBLL.GetRevenueStatistics(
                    from,
                    to);

            if (!result.IsSuccess ||
                result.Data == null)
            {
                return;
            }

            chartRevenue.Series.Clear();
            chartRevenue.Titles.Clear();
            chartRevenue.Legends.Clear();

            chartRevenue.Titles.Add(
                "DOANH THU THEO NGÀY");

            var series =
                new Series("Doanh thu")
                {
                    ChartType =
                        SeriesChartType.Column,

                    IsValueShownAsLabel =
                        true
                };

            foreach (var item in result.Data)
            {
                var point =
                    new DataPoint();

                point.SetValueXY(
                    item.Date.ToString("dd/MM"),
                    (double)item.Amount);

                point.Label =
                    item.Amount.ToString("N0");

                series.Points.Add(point);
            }

            chartRevenue.Series.Add(
                series);

            chartRevenue.ChartAreas[0]
                .AxisX.Interval = 1;

            chartRevenue.ChartAreas[0]
                .AxisY.Minimum = 0;

            chartRevenue.ChartAreas[0]
                .AxisY.LabelStyle.Format =
                "N0";
        }


        // =========================================================
        // VISIT STATUS
        // =========================================================

        private void LoadVisitStatusChart(
            DateTime from,
            DateTime to)
        {
            var result =
                _dashboardBLL.GetVisitStatusStatistics(
                    from,
                    to);

            if (!result.IsSuccess ||
                result.Data == null)
            {
                return;
            }

            chartVisitStatus.Series.Clear();
            chartVisitStatus.Legends.Clear();
            chartVisitStatus.Titles.Clear();

            chartVisitStatus.Titles.Add(
                "TRẠNG THÁI LƯỢT KHÁM");

            if (result.Data.Count == 0)
            {
                return;
            }

            var series =
                new Series("Trạng thái")
                {
                    ChartType =
                        SeriesChartType.Doughnut,

                    IsValueShownAsLabel =
                        true
                };

            foreach (var item in result.Data)
            {
                series.Points.AddXY(
                    item.Status,
                    item.Count);
            }

            chartVisitStatus.Series.Add(
                series);

            chartVisitStatus.Legends.Add(
                new Legend("StatusLegend")
                {
                    Docking =
                        Docking.Bottom
                });
        }


        // =========================================================
        // LOW STOCK
        // =========================================================

        private void SetupLowStockGrid()
        {
            dgvLowStock.AutoGenerateColumns =
                false;

            dgvLowStock.Columns.Clear();

            dgvLowStock.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "MedicineId",

                    HeaderText =
                        "Mã thuốc",

                    Width = 70
                });

            dgvLowStock.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "MedicineName",

                    HeaderText =
                        "Tên thuốc",

                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });

            dgvLowStock.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "Unit",

                    HeaderText =
                        "Đơn vị",

                    Width = 80
                });

            dgvLowStock.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "QuantityInStock",

                    HeaderText =
                        "Tồn kho",

                    Width = 90
                });

            dgvLowStock.ReadOnly = true;
            dgvLowStock.RowHeadersVisible = false;
            dgvLowStock.AllowUserToAddRows = false;
        }


        private void LoadLowStock()
        {
            var result =
    _dashboardBLL.GetLowStockMedicines();

            if (!result.IsSuccess)
                return;

            dgvLowStock.DataSource =
                result.Data;
        }


        // =========================================================
        // RECENT IMPORT
        // =========================================================

        private void SetupRecentImportGrid()
        {
            dgvRecentImports.AutoGenerateColumns =
                false;

            dgvRecentImports.Columns.Clear();

            dgvRecentImports.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "MedicineImportId",

                    HeaderText =
                        "Mã phiếu",

                    Width = 80
                });

            dgvRecentImports.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "ImportDate",

                    HeaderText =
                        "Ngày nhập",

                    Width = 140,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format =
                                "dd/MM/yyyy HH:mm"
                        }
                });

            dgvRecentImports.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "SupplierName",

                    HeaderText =
                        "Nhà cung cấp",

                    Width = 160
                });

            dgvRecentImports.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "UserName",

                    HeaderText =
                        "Người nhập",

                    Width = 120
                });

            dgvRecentImports.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "TotalAmount",

                    HeaderText =
                        "Tổng tiền",

                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format = "N0",
                            Alignment =
                                DataGridViewContentAlignment.MiddleRight
                        }
                });

            dgvRecentImports.ReadOnly = true;
            dgvRecentImports.RowHeadersVisible = false;
            dgvRecentImports.AllowUserToAddRows = false;
        }


        private void LoadRecentImports()
        {
            var result =
                _dashboardBLL.GetRecentImports(5);

            if (!result.IsSuccess)
                return;

            dgvRecentImports.DataSource =
                result.Data;
        }


        // =========================================================
        // DOCTOR CHART
        // =========================================================

        private void LoadDoctorChart(
    DateTime from,
    DateTime to)
        {
            var result =
                _dashboardBLL.GetDoctorStatistics(
                    from,
                    to);

            if (!result.IsSuccess ||
                result.Data == null)
            {
                return;
            }

            chartDoctorVisits.Series.Clear();
            chartDoctorVisits.Legends.Clear();
            chartDoctorVisits.Titles.Clear();

            chartDoctorVisits.Titles.Add(
                "LƯỢT KHÁM THEO BÁC SĨ");

            if (result.Data.Count == 0)
            {
                return;
            }

            var series = new Series("Lượt khám")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                IsXValueIndexed = true
            };

            foreach (var item in result.Data)
            {
                var point = new DataPoint();

                // Giá trị số lượt khám
                point.SetValueY(item.VisitCount);

                // Tên bác sĩ nằm ở trục Y
                point.AxisLabel = item.DoctorName;

                // Số lượt khám hiển thị trên thanh
                point.Label = item.VisitCount.ToString();

                series.Points.Add(point);
            }

            chartDoctorVisits.Series.Add(series);

            var area = chartDoctorVisits.ChartAreas[0];

            area.AxisX.Minimum = 0;
            area.AxisX.Interval = 1;

            area.AxisX.Title = "Số lượt khám";
            area.AxisY.Title = "Bác sĩ";

            area.AxisY.Interval = 1;

            area.AxisY.IsMarginVisible = true;
        }

        // =========================================================
        // PATIENT GRID
        // =========================================================

        private void SetupPatientGrid()
        {
            dgvPatientStatistics.AutoGenerateColumns =
                false;

            dgvPatientStatistics.Columns.Clear();

            dgvPatientStatistics.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "PatientId",

                    HeaderText =
                        "Mã BN",

                    Width = 70
                });

            dgvPatientStatistics.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "PatientName",

                    HeaderText =
                        "Bệnh nhân",

                    Width = 200
                });

            dgvPatientStatistics.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "VisitCount",

                    HeaderText =
                        "Số lượt khám",

                    Width = 110
                });

            dgvPatientStatistics.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName =
                        "LastVisit",

                    HeaderText =
                        "Lần khám gần nhất",

                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format =
                                "dd/MM/yyyy HH:mm"
                        }
                });

            dgvPatientStatistics.ReadOnly =
                true;

            dgvPatientStatistics.RowHeadersVisible =
                false;

            dgvPatientStatistics.AllowUserToAddRows =
                false;
        }


        private void LoadPatientStatistics(
            DateTime from,
            DateTime to)
        {
            var result =
                _dashboardBLL.GetPatientStatistics(
                    from,
                    to);

            if (!result.IsSuccess)
                return;

            dgvPatientStatistics.DataSource =
                result.Data;
        }


        // =========================================================
        // DATE FILTER
        // =========================================================

        private void dtpFrom_ValueChanged(
            object sender,
            EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadDashboard();
            }
        }


        private void dtpTo_ValueChanged(
            object sender,
            EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadDashboard();
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}