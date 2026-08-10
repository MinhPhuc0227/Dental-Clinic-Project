using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class PaymentMethod_DAL
    {
        // 1. Get all 
        public List<PaymentMethod> GetAll()
        {
            using (var db = new AppDbContext())
                return db.PaymentMethods.AsNoTracking().ToList();
        }

        // 2. Get by ID
        public PaymentMethod? GetById(int paymentMethodId)
        {
            using (var db = new AppDbContext())
                return db.PaymentMethods
                    .AsNoTracking()
                    .FirstOrDefault(p => p.PaymentMethodId == paymentMethodId);
        }

        // 3. Add
        public void Add(PaymentMethod p)
        {
            using (var db = new AppDbContext())
            {
                db.PaymentMethods.Add(p);
                db.SaveChanges();
            }
        }

        // 4. Update
        public bool Update(PaymentMethod p)
        {
            using (var db = new AppDbContext())
            {
                var editPaymentMethod = db.PaymentMethods.Find(p.PaymentMethodId);
                if (editPaymentMethod != null)
                {
                    editPaymentMethod.PaymentMethodName = p.PaymentMethodName;
                    editPaymentMethod.Description = p.Description;
                    editPaymentMethod.IsCash = p.IsCash;
                    editPaymentMethod.Status = p.Status;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        // 5. Delete
        public bool Delete(int paymentMethodId)
        {
            using (var db = new AppDbContext())
            {
                var item = db.PaymentMethods.Find(paymentMethodId);
                if (item != null)
                {
                    db.PaymentMethods.Remove(item);
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }

        // 6. Check if there are any invoices associated with the payment method 
        public bool HasAssociatedInvoices(int paymentMethodId)
        {
            using (var db = new AppDbContext())
            {
                return db.Invoices.Any(hd => hd.PaymentMethodId == paymentMethodId);
            }
        }
    }
}
