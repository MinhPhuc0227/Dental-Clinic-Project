using DentalClinic.APP.Properties;
using DentalClinic.BLL;
using DentalClinic.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class UC_Account : UserControl
    {
        private readonly Account_BLL _bll = new Account_BLL();
        private List<AccountDto> _fullList = new List<AccountDto>();

        public UC_Account()
        {
            InitializeComponent();
        }

        private void UC_Account_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDataToGridView();
        }

        // Config datagridview 
        private void ConfigureDataGridView()
        {
            dgvAccount.AutoGenerateColumns = true;
        }

        // Load data to datagridview
        public void LoadDataToGridView()
        {
            var result = _bll.GetAll();

            if (result.IsSuccess && result.Data != null)
            {
                _fullList = result.Data;
                dgvAccount.DataSource = _fullList;
                AddActionImageColumns();
            }
            else
            {
                MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add edit and delete image columns 
        private void AddActionImageColumns()
        {
            if (!dgvAccount.Columns.Contains("EditCol"))
            {
                var imgEdit = new DataGridViewImageColumn
                {
                    Name = "EditCol",
                    HeaderText = "Sửa / Đổi MK",
                    Image = Resources.edit,
                    Width = 80,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvAccount.Columns.Add(imgEdit);
            }

            if (!dgvAccount.Columns.Contains("DeleteCol"))
            {
                var imgDelete = new DataGridViewImageColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "Xóa",
                    Image = Resources.delete,
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvAccount.Columns.Add(imgDelete);
            }
        }

        // Cellcontentclick (Edit/Delete) 
        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDto = dgvAccount.Rows[e.RowIndex].DataBoundItem as AccountDto;
            if (selectedDto == null) return;

            string colName = dgvAccount.Columns[e.ColumnIndex].Name;

            // EDIT
            if (colName == "EditCol")
            {
                using (var dialog = new Dialog_Account(selectedDto))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataToGridView();
                    }
                }
            }
            // DELETE
            else if (colName == "DeleteCol")
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa tài khoản '{selectedDto.UserName}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    var result = _bll.Delete(selectedDto.AccountId);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToGridView();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvAccount.DataSource = _fullList;
            }
            else
            {
                var filtered = _fullList.Where(a => a.UserName.ToLower().Contains(keyword)
                                                 || a.RoleDisplay.ToLower().Contains(keyword)
                                                 || a.StatusDisplay.ToLower().Contains(keyword)).ToList();
                dgvAccount.DataSource = filtered;
            }
        }
    }
}
