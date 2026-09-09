using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Service_DAL
    {
        private readonly AppDbContext _context;

        public Service_DAL(AppDbContext context)
        {
            _context = context;
        }

        // GetAll
        public List<Service> GetAll()
        {
                return _context.Services.ToList();
        }

        // GetById
        public Service? GetById(int id)
        {
                return _context.Services.FirstOrDefault(s => s.ServiceId == id);
        }

        // Kiểm tra tên dịch vụ đã tồn tại hay chưa (không kiểm tra dịch vụ đang chọn), dùng khi update dịch vụ
        public bool IsNameExists(string name, int excludeId = 0)
        {
            return _context.Services.Any(s => s.ServiceName.ToLower() == name.ToLower()
                                          && s.ServiceId != excludeId);
        }

        // ADD
        public bool Add(Service entity)
        {
                _context.Services.Add(entity);
                return _context.SaveChanges() > 0;
        }

        // UPDATE
        public bool Update(Service entity)
        {
                var existing = _context.Services.FirstOrDefault(s => s.ServiceId == entity.ServiceId);
                if (existing == null) return false;

                existing.ServiceName = entity.ServiceName;
                existing.UnitPrice = entity.UnitPrice;
                existing.IsLongTerm = entity.IsLongTerm;
                existing.Description = entity.Description;
                existing.Status = entity.Status;

                return _context.SaveChanges() > 0;
        }

        // DELETE
        public bool Delete(int id)
        {
                var existing = _context.Services.FirstOrDefault(s => s.ServiceId == id);
                if (existing == null) return false;

                _context.Services.Remove(existing);
                return _context.SaveChanges() > 0;
        }
    }
}
