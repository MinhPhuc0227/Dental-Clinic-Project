using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Medicine_DAL
    {
        private readonly AppDbContext _context;
        public Medicine_DAL(AppDbContext context)
        {
            _context = context;
        }

        public List<Medicine> GetAll(
    string keyword = "",
    MedicineStatus? status = null)
        {
                var query = _context.Medicines.AsQueryable();

                // Tìm kiếm theo tên thuốc hoặc đơn vị
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    string kw = keyword.Trim().ToLower();

                    query = query.Where(m =>
                        m.MedicineName.ToLower().Contains(kw) ||
                        m.Unit.ToLower().Contains(kw));
                }

                // Lọc theo trạng thái
                if (status.HasValue)
                {
                    query = query.Where(
                        m => m.Status == status.Value);
                }

                return query
                    .OrderBy(m => m.MedicineName)
                    .ToList();
        }

        public Medicine? GetById(int id)
        {
                return _context.Medicines.FirstOrDefault(m => m.MedicineId == id);
        }

        public bool Add(Medicine entity)
        {
                _context.Medicines.Add(entity);
                return _context.SaveChanges() > 0;
        }

        public bool Update(Medicine entity)
        {
                var existing = _context.Medicines.FirstOrDefault(m => m.MedicineId == entity.MedicineId);
                if (existing == null) return false;

                existing.MedicineName = entity.MedicineName;
                existing.Unit = entity.Unit;
                existing.UnitPrice = entity.UnitPrice;
                existing.Description = entity.Description;
                existing.Status = entity.Status;

                return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
                var existing = _context.Medicines.FirstOrDefault(m => m.MedicineId == id);
                if (existing == null) return false;

                _context.Medicines.Remove(existing);
                return _context.SaveChanges() > 0;
        }

        // Kiểm tra trùng tên thuốc khi Thêm hoặc Sửa
        public bool IsNameExists(string name, int excludeId = 0)
        {
                return _context.Medicines.Any(m => m.MedicineName.ToLower() == name.ToLower()
                                               && m.MedicineId != excludeId);
        }
    }
}
