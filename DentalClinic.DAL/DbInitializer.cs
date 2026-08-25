using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public static class DbInitializer
    {
        public static void Seed()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                bool hasAdmin = context.Accounts.Any(a => a.Role == AccountRole.Admin);

                if (!hasAdmin)
                {
                    var adminAccount = new Account
                    {
                        UserName = "admin",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        Role = AccountRole.Admin,
                        Status = AccountStatus.Active,
                        CreatedDate = DateTime.Now
                    };

                    context.Accounts.Add(adminAccount);
                    context.SaveChanges();
                }
            }
        }
    }
}
