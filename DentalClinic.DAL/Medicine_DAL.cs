using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Medicine_DAL
    {
        public List<Medicine> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Medicines.ToList();
            }
        }

        public Medicine? GetById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Medicines.FirstOrDefault(m => m.MedicineId == id);
            }
        }

        public bool Add(Medicine entity)
        {
            using (var context = new AppDbContext())
            {
                context.Medicines.Add(entity);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Medicine entity)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Medicines.FirstOrDefault(m => m.MedicineId == entity.MedicineId);
                if (existing == null) return false;

                existing.MedicineName = entity.MedicineName;
                existing.Unit = entity.Unit;
                existing.UnitPrice = entity.UnitPrice;
                existing.QuantityInStock = entity.QuantityInStock;
                existing.Description = entity.Description;
                existing.Status = entity.Status;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Medicines.FirstOrDefault(m => m.MedicineId == id);
                if (existing == null) return false;

                context.Medicines.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }

        // Kiểm tra trùng tên thuốc khi Thêm hoặc Sửa
        public bool IsNameExists(string name, int excludeId = 0)
        {
            using (var context = new AppDbContext())
            {
                return context.Medicines.Any(m => m.MedicineName.ToLower() == name.ToLower()
                                               && m.MedicineId != excludeId);
            }
        }
    }
}
