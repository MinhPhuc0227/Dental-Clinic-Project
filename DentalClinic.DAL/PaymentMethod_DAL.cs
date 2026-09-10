using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class PaymentMethod_DAL
    {
        private readonly AppDbContext _context;

        public PaymentMethod_DAL(AppDbContext context)
        {
            _context = context;
        }

        // GetAll
        public List<PaymentMethod> GetAll(string keyword = "", PaymentMethodStatus? status = null)
        {
            var query = _context.PaymentMethods.AsQueryable();

            // Tìm kiếm
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();

                query = query.Where(pm =>
                    pm.PaymentMethodName.Contains(keyword) ||
                    (pm.Description != null && pm.Description.Contains(keyword)));
            }

            // Lọc trạng thái
            if (status.HasValue)
            {
                query = query.Where(pm => pm.Status == status.Value);
            }

            return query.ToList();
        }

        // GetById
        public PaymentMethod? GetById(int id)
        {
                return _context.PaymentMethods.FirstOrDefault(pm => pm.PaymentMethodId == id);
        }

        // Kiểm tra tên phương thức thanh toán đã tồn tại chưa (khi update)
        public bool IsNameExists(string name, int excludeId = 0)
        {
                return _context.PaymentMethods.Any(pm => pm.PaymentMethodName.ToLower() == name.ToLower() && pm.PaymentMethodId != excludeId);
        }

        // ADD
        public bool Add(PaymentMethod entity)
        {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.PaymentMethods.Add(entity);
                        _context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
        }

        // UPDATE
        public bool Update(PaymentMethod entity)
        {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var existing = _context.PaymentMethods.FirstOrDefault(pm => pm.PaymentMethodId == entity.PaymentMethodId);
                        if (existing == null) return false;

                        existing.PaymentMethodName = entity.PaymentMethodName;
                        existing.Description = entity.Description;
                        existing.IsCash = entity.IsCash;
                        existing.Status = entity.Status;

                        _context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
        }

        // DELETE
        public bool Delete(int id)
        {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var existing = _context.PaymentMethods.FirstOrDefault(pm => pm.PaymentMethodId == id);
                        if (existing == null) return false;

                        _context.PaymentMethods.Remove(existing);
                        _context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
        }
    }
}
