using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Supplier_DAL
    {
        private readonly AppDbContext _context;

        public Supplier_DAL(AppDbContext context)
        {
            _context = context;
        }

        // GetAll
        public List<Supplier> GetAll(string keyword = "", bool? isActive = null)
        {
            var query = _context.Suppliers.AsNoTracking().AsQueryable();

            // Tìm kiếm
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();

                query = query.Where(s =>
                    s.SupplierName.ToLower().Contains(kw) ||
                    s.Phone.Contains(kw) ||
                    (s.Address != null &&
                    s.Address.ToLower().Contains(kw)) ||
                    (s.Email != null &&
                    s.Email.ToLower().Contains(kw)));
            }

            // Lọc trạng thái
            if (isActive.HasValue)
            {
                query = query.Where(s => s.IsActive == isActive.Value);
            }

            return query.OrderBy(s => s.SupplierId).ToList();
        }

        // GetById
        public Supplier? GetById(int id)
        {
            return _context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
        }

        // Kiểm tra tên nhà cung cấp đã tồn tại chưa 
        public bool IsNameExists(string name, int excludeId = 0)
        {
            string normalizedName = name.Trim().ToLower();

            return _context.Suppliers.Any(s =>
                s.SupplierName.ToLower() == normalizedName &&
                s.SupplierId != excludeId);
        }

        // ADD
        public bool Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            return _context.SaveChanges() > 0;
        }

        // UPDATE
        public bool Update(Supplier supplier)
        {
            var existing = _context.Suppliers.FirstOrDefault(s => s.SupplierId == supplier.SupplierId);

            if (existing == null) return false;

            existing.SupplierName = supplier.SupplierName;
            existing.Phone = supplier.Phone;
            existing.Address = supplier.Address;
            existing.Email = supplier.Email;
            existing.Note = supplier.Note;
            existing.IsActive = supplier.IsActive;

            return _context.SaveChanges() > 0;
        }

        // Kiểm tra đã từng nhập kho chưa
        public bool HasImportHistory(int supplierId)
        {
            return _context.MedicineImports
                .Any(i =>
                    i.SupplierId == supplierId);
        }

        // DELETE
        public bool Delete(int supplierId)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);

            if (supplier == null) return false;

            bool hasImportHistory = HasImportHistory(supplierId);

            if (hasImportHistory)
            {
                // Đã có lịch sử nhập kho thì cho ẩn
                supplier.IsActive = false;
            }
            else
            {
                // Chưa từng nhập kho thì xóa luôn
                _context.Suppliers.Remove(supplier);
            }

            return _context.SaveChanges() > 0;
        }
    }
}
