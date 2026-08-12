using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class PaymentMethod_DAL
    {
        // GetAll
        public List<PaymentMethod> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.PaymentMethods.ToList();
            }
        }

        // GetById
        public PaymentMethod? GetById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.PaymentMethods.FirstOrDefault(pm => pm.PaymentMethodId == id);
            }
        }

        // Check if name exists
        public bool IsNameExists(string name, int excludeId = 0)
        {
            using (var context = new AppDbContext())
            {
                return context.PaymentMethods.Any(pm => pm.PaymentMethodName.ToLower() == name.ToLower() && pm.PaymentMethodId != excludeId);
            }
        }

        // Add
        public bool Add(PaymentMethod entity)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.PaymentMethods.Add(entity);
                        context.SaveChanges();
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

        // Update
        public bool Update(PaymentMethod entity)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var existing = context.PaymentMethods.FirstOrDefault(pm => pm.PaymentMethodId == entity.PaymentMethodId);
                        if (existing == null) return false;

                        existing.PaymentMethodName = entity.PaymentMethodName;
                        existing.Description = entity.Description;
                        existing.IsCash = entity.IsCash;
                        existing.Status = entity.Status;

                        context.SaveChanges();
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

        // Delete
        public bool Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var existing = context.PaymentMethods.FirstOrDefault(pm => pm.PaymentMethodId == id);
                        if (existing == null) return false;

                        context.PaymentMethods.Remove(existing);
                        context.SaveChanges();
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
}
