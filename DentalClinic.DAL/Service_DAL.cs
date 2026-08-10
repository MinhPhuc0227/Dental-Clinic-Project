using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Service_DAL
    {
        public List<Service> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Services.ToList();
            }
        }

        public Service? GetById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Services.FirstOrDefault(s => s.ServiceId == id);
            }
        }

        public bool Add(Service entity)
        {
            using (var context = new AppDbContext())
            {
                context.Services.Add(entity);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Service entity)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Services.FirstOrDefault(s => s.ServiceId == entity.ServiceId);
                if (existing == null) return false;

                existing.ServiceName = entity.ServiceName;
                existing.UnitPrice = entity.UnitPrice;
                existing.Description = entity.Description;
                existing.Status = entity.Status;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Services.FirstOrDefault(s => s.ServiceId == id);
                if (existing == null) return false;

                context.Services.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }

        public bool IsNameExists(string name, int excludeId = 0)
        {
            using (var context = new AppDbContext())
            {
                return context.Services.Any(s => s.ServiceName.ToLower() == name.ToLower()
                                              && s.ServiceId != excludeId);
            }
        }
    }
}
