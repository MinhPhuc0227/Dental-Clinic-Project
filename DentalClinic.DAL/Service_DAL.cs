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

        public List<Service> GetAll()
        {
                return _context.Services.ToList();
        }

        public Service? GetById(int id)
        {
                return _context.Services.FirstOrDefault(s => s.ServiceId == id);
        }

        public bool Add(Service entity)
        {
                _context.Services.Add(entity);
                return _context.SaveChanges() > 0;
        }

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

        public bool Delete(int id)
        {
                var existing = _context.Services.FirstOrDefault(s => s.ServiceId == id);
                if (existing == null) return false;

                _context.Services.Remove(existing);
                return _context.SaveChanges() > 0;
        }

        public bool IsNameExists(string name, int excludeId = 0)
        {
                return _context.Services.Any(s => s.ServiceName.ToLower() == name.ToLower()
                                              && s.ServiceId != excludeId);
        }
    }
}
