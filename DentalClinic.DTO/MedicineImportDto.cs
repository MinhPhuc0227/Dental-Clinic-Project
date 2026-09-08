using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    // Danh sách phiếu nhập thuốc (hiển thị trên datagridview)
    public class MedicineImportListDto
    {
        public int MedicineImportId { get; set; }
        public DateTime ImportDate { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PaymentMethodName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }


    // Chi tiết của một phiếu nhập thuốc (khi chọn một phiếu nhập trong danh sách)
    public class MedicineImportDetailDto
    {
        public int MedicineImportId { get; set; }
        public DateTime ImportDate { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PaymentMethodName { get; set; } = string.Empty;
        public string? Note { get; set; }
        public decimal TotalAmount { get; set; }
        public List<MedicineImportItemDto> Items { get; set; } = new List<MedicineImportItemDto>();
    }

    // Thông tin chi tiết của từng loại thuốc được nhập trong phiếu nhập 
    public class MedicineImportItemDto
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;

        [Range(1,int.MaxValue, ErrorMessage = "Số lượng nhập phải lớn hơn 0.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá nhập phải lớn hơn 0.")]
        public decimal UnitImportPrice { get; set; }

        public decimal TotalAmount => Quantity * UnitImportPrice;
    }


    // Thông tin của phiếu nhập thuốc khi tạo (dùng khi thêm thuốc vào phiếu nhập, xem thuốc trong phiếu đã tạo)
    public class CreateMedicineImportDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn nhà cung cấp.")]
        public int SupplierId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Tài khoản nhập kho không hợp lệ.")]
        public int AccountId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn phương thức thanh toán.")]
        public int PaymentMethodId { get; set; }

        public DateTime ImportDate { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
        public string? Note { get; set; }

        [MinLength(1, ErrorMessage = "Phiếu nhập phải có ít nhất một loại thuốc.")]
        public List<MedicineImportItemDto> Items { get; set; } = new List<MedicineImportItemDto>();
    }
}
