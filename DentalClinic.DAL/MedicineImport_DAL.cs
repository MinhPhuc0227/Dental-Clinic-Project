using DentalClinic.DTO;
using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.DAL
{
    public class MedicineImport_DAL
    {
        private readonly AppDbContext _context;

        public MedicineImport_DAL(AppDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // CREATE IMPORT
        // =========================================================
        public bool CreateImport(CreateMedicineImportDto dto)
        {
            using var transaction =
                _context.Database.BeginTransaction();

            try
            {
                // -------------------------------------------------
                // 1. Kiểm tra nhà cung cấp
                // -------------------------------------------------
                var supplier =
                    _context.Suppliers
                        .FirstOrDefault(s =>
                            s.SupplierId == dto.SupplierId);

                if (supplier == null)
                {
                    throw new InvalidOperationException(
                        "Không tìm thấy nhà cung cấp.");
                }

                if (!supplier.IsActive)
                {
                    throw new InvalidOperationException(
                        "Nhà cung cấp này đã ngừng hoạt động.");
                }

                // -------------------------------------------------
                // 2. Kiểm tra Account
                // -------------------------------------------------
                var account =
                    _context.Accounts
                        .FirstOrDefault(a =>
                            a.AccountId == dto.AccountId);

                if (account == null)
                {
                    throw new InvalidOperationException(
                        "Không tìm thấy tài khoản.");
                }

                if (account.Role != AccountRole.Admin)
                {
                    throw new InvalidOperationException(
                        "Chỉ Admin mới được phép nhập kho.");
                }

                if (account.Status != AccountStatus.Active)
                {
                    throw new InvalidOperationException(
                        "Tài khoản Admin hiện không hoạt động.");
                }

                // -------------------------------------------------
                // 3. Kiểm tra phương thức thanh toán
                // -------------------------------------------------
                var paymentMethod =
                    _context.PaymentMethods
                        .FirstOrDefault(p =>
                            p.PaymentMethodId ==
                            dto.PaymentMethodId);

                if (paymentMethod == null)
                {
                    throw new InvalidOperationException(
                        "Không tìm thấy phương thức thanh toán.");
                }

                // -------------------------------------------------
                // 4. Kiểm tra ngày nhập
                // -------------------------------------------------
                if (dto.ImportDate > DateTime.Now)
                {
                    throw new InvalidOperationException(
                        "Ngày nhập không được lớn hơn thời gian hiện tại.");
                }

                // -------------------------------------------------
                // 5. Kiểm tra danh sách thuốc
                // -------------------------------------------------
                if (dto.Items == null ||
                    dto.Items.Count == 0)
                {
                    throw new InvalidOperationException(
                        "Phiếu nhập phải có ít nhất một loại thuốc.");
                }

                // Không cho trùng thuốc trong cùng phiếu
                if (dto.Items
                    .GroupBy(x => x.MedicineId)
                    .Any(g => g.Count() > 1))
                {
                    throw new InvalidOperationException(
                        "Một loại thuốc chỉ được xuất hiện một lần trong phiếu nhập.");
                }

                // -------------------------------------------------
                // 6. Load thuốc
                // -------------------------------------------------
                var medicines =
                    new Dictionary<int, Medicine>();

                foreach (var item in dto.Items)
                {
                    var medicine =
                        _context.Medicines
                            .FirstOrDefault(m =>
                                m.MedicineId ==
                                item.MedicineId);

                    if (medicine == null)
                    {
                        throw new InvalidOperationException(
                            $"Không tìm thấy thuốc có mã {item.MedicineId}.");
                    }

                    if (medicine.Status != MedicineStatus.Active)
                    {
                        throw new InvalidOperationException(
                            $"Thuốc \"{medicine.MedicineName}\" đã ngừng hoạt động.");
                    }

                    medicines[item.MedicineId] =
                        medicine;
                }

                // -------------------------------------------------
                // 7. Tạo phiếu nhập
                // -------------------------------------------------
                var import =
                    new MedicineImport
                    {
                        ImportDate =
                            dto.ImportDate,

                        SupplierId =
                            dto.SupplierId,

                        AccountId =
                            dto.AccountId,

                        PaymentMethodId =
                            dto.PaymentMethodId,

                        Note =
                            string.IsNullOrWhiteSpace(dto.Note)
                                ? null
                                : dto.Note.Trim(),

                        TotalAmount = 0
                    };

                _context.MedicineImports.Add(import);

                // Lấy ID phiếu nhập
                _context.SaveChanges();

                decimal totalAmount = 0;

                // -------------------------------------------------
                // 8. Tạo chi tiết + cộng tồn kho
                // -------------------------------------------------
                foreach (var item in dto.Items)
                {
                    var medicine =
                        medicines[item.MedicineId];

                    decimal itemTotal =
                        item.Quantity *
                        item.UnitImportPrice;

                    var detail =
                        new MedicineImportDetail
                        {
                            MedicineImportId =
                                import.MedicineImportId,

                            MedicineId =
                                item.MedicineId,

                            Quantity =
                                item.Quantity,

                            UnitImportPrice =
                                item.UnitImportPrice,

                            TotalAmount =
                                itemTotal
                        };

                    _context.MedicineImportDetails.Add(detail);

                    // CỘNG TỒN KHO
                    medicine.QuantityInStock +=
                        item.Quantity;

                    totalAmount += itemTotal;
                }

                // -------------------------------------------------
                // 9. Cập nhật tổng tiền
                // -------------------------------------------------
                import.TotalAmount =
                    totalAmount;

                _context.SaveChanges();

                // -------------------------------------------------
                // 10. Commit
                // -------------------------------------------------
                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        // =========================================================
        // GET HISTORY
        // =========================================================
        public List<MedicineImportListDto> GetHistory(
            DateTime fromDate,
            DateTime toDate,
            int? supplierId,
            string keyword)
        {
            var query =
                _context.MedicineImports
                    .AsNoTracking()
                    .Include(i => i.Supplier)
                    .Include(i => i.Account)
                    .Include(i => i.PaymentMethod)
                    .AsQueryable();

            query = query.Where(i =>
                i.ImportDate >= fromDate.Date &&
                i.ImportDate <=
                    toDate.Date
                        .AddDays(1)
                        .AddTicks(-1));

            if (supplierId.HasValue &&
                supplierId.Value > 0)
            {
                query = query.Where(i =>
                    i.SupplierId ==
                    supplierId.Value);
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw =
                    keyword.Trim().ToLower();

                query = query.Where(i =>
                    i.Supplier.SupplierName
                        .ToLower()
                        .Contains(kw)
                    ||
                    i.Account.UserName
                        .ToLower()
                        .Contains(kw));
            }

            return query
                .OrderByDescending(i => i.ImportDate)
                .Select(i =>
                    new MedicineImportListDto
                    {
                        MedicineImportId =
                            i.MedicineImportId,

                        ImportDate =
                            i.ImportDate,

                        SupplierName =
                            i.Supplier.SupplierName,

                        UserName =
                            i.Account.UserName,

                        PaymentMethodName =
                            i.PaymentMethod.PaymentMethodName,

                        TotalAmount =
                            i.TotalAmount
                    })
                .ToList();
        }


        // =========================================================
        // GET DETAIL
        // =========================================================
        public MedicineImportDetailDto?
            GetDetail(int importId)
        {
            var import =
                _context.MedicineImports
                    .AsNoTracking()
                    .Include(i => i.Supplier)
                    .Include(i => i.Account)
                    .Include(i => i.PaymentMethod)
                    .FirstOrDefault(i =>
                        i.MedicineImportId ==
                        importId);

            if (import == null)
                return null;

            return new MedicineImportDetailDto
            {
                MedicineImportId =
                    import.MedicineImportId,

                ImportDate =
                    import.ImportDate,

                SupplierName =
                    import.Supplier.SupplierName,

                UserName =
                    import.Account.UserName,

                PaymentMethodName =
                    import.PaymentMethod
                        .PaymentMethodName,

                Note =
                    import.Note,

                TotalAmount =
                    import.TotalAmount,

                Items =
                    _context.MedicineImportDetails
                        .AsNoTracking()
                        .Where(d =>
                            d.MedicineImportId ==
                            importId)
                        .Select(d =>
                            new MedicineImportItemDto
                            {
                                MedicineId =
                                    d.MedicineId,

                                MedicineName =
                                    d.Medicine.MedicineName,

                                Unit =
                                    d.Medicine.Unit,

                                Quantity =
                                    d.Quantity,

                                UnitImportPrice =
                                    d.UnitImportPrice
                            })
                        .ToList()
            };
        }
    }
}