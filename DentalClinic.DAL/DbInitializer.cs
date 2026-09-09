using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.DAL
{
    public static class DbInitializer
    {
        public static void Seed()
        {
            using var context = new AppDbContext();

            context.Database.Migrate();

            using var transaction = context.Database.BeginTransaction();

            try
            {
                SeedAccountsAndStaff(context);
                SeedPaymentMethods(context);
                SeedServices(context);
                SeedSuppliers(context);
                SeedMedicines(context);
                SeedPatients(context);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // 1. Tài khoản + Bác sĩ + Lễ tân
        private static void SeedAccountsAndStaff(AppDbContext context)
        {
            // Admin
            GetOrCreateAccount(
                context,
                userName: "admin",
                password: "123456",
                role: AccountRole.Admin);

            // Bác sĩ 1
            var doctorAccount1 = GetOrCreateAccount(
                context,
                userName: "minhphuc",
                password: "123456",
                role: AccountRole.Doctor);

            if (!context.Doctors.Any(d => d.AccountId == doctorAccount1.AccountId))
            {
                context.Doctors.Add(new Doctor
                {
                    FullName = "Nguyễn Minh Phúc",
                    Gender = Gender.Female,
                    DateOfBirth = new DateOnly(2005, 2, 27),
                    Phone = "0357173931",
                    Email = "doctor1@gmail.com",
                    Description = "Bác sĩ nha khoa tổng quát.",
                    AccountId = doctorAccount1.AccountId
                });
            }

            // Bác sĩ 2
            var doctorAccount2 = GetOrCreateAccount(
                context,
                userName: "ngocquy",
                password: "123456",
                role: AccountRole.Doctor);

            if (!context.Doctors.Any(d => d.AccountId == doctorAccount2.AccountId))
            {
                context.Doctors.Add(new Doctor
                {
                    FullName = "Nguyễn Ngọc Quý",
                    Gender = Gender.Male,
                    DateOfBirth = new DateOnly(2005, 11, 29),
                    Phone = "0357173932",
                    Email = "doctor02@gmail.com",
                    Description = "Bác sĩ chuyên điều trị nha khoa phục hồi.",
                    AccountId = doctorAccount2.AccountId
                });
            }

            // Bác sĩ 3
            var doctorAccount3 = GetOrCreateAccount(
                context,
                userName: "huuphuc",
                password: "123456",
                role: AccountRole.Doctor);

            if (!context.Doctors.Any(d => d.AccountId == doctorAccount3.AccountId))
            {
                context.Doctors.Add(new Doctor
                {
                    FullName = "Lê Hữu Phúc",
                    Gender = Gender.Male,
                    DateOfBirth = new DateOnly(2005, 12, 22),
                    Phone = "0357173933",
                    Email = "doctor03@gmail.com",
                    Description = "Bác sĩ chuyên điều trị tủy răng.",
                    AccountId = doctorAccount3.AccountId
                });
            }

            // Lễ tân 1
            var receptionistAccount1 = GetOrCreateAccount(
                context,
                userName: "giahan",
                password: "123456",
                role: AccountRole.Receptionist);

            if (!context.Receptionists.Any(r => r.AccountId == receptionistAccount1.AccountId))
            {
                context.Receptionists.Add(new Receptionist
                {
                    FullName = "Nguyễn Gia Hân",
                    Gender = Gender.Female,
                    DateOfBirth = new DateOnly(2005, 10, 27),
                    Phone = "0902000001",
                    Email = "receptionist01@gmail.com",
                    Description = "Nhân viên lễ tân.",
                    AccountId = receptionistAccount1.AccountId
                });
            }

            // Lễ tân 2
            var receptionistAccount2 = GetOrCreateAccount(
                context,
                userName: "vankhanh",
                password: "123456",
                role: AccountRole.Receptionist);

            if (!context.Receptionists.Any(r => r.AccountId == receptionistAccount2.AccountId))
            {
                context.Receptionists.Add(new Receptionist
                {
                    FullName = "Nguyễn Vân Khánh",
                    Gender = Gender.Female,
                    DateOfBirth = new DateOnly(2005, 12, 22),
                    Phone = "0902000002",
                    Email = "reception02@gmail.com",
                    Description = "Nhân viên lễ tân.",
                    AccountId = receptionistAccount2.AccountId
                });
            }

            context.SaveChanges();
        }

        private static Account GetOrCreateAccount(
            AppDbContext context,
            string userName,
            string password,
            AccountRole role)
        {
            var account = context.Accounts
                .FirstOrDefault(a => a.UserName == userName);

            if (account != null)
            {
                if (account.Role != role)
                {
                    throw new InvalidOperationException(
                        $"Tài khoản '{userName}' đã tồn tại nhưng không đúng vai trò khởi tạo.");
                }

                return account;
            }

            account = new Account
            {
                UserName = userName,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                Role = role,
                Status = AccountStatus.Active,
                CreatedDate = DateTime.Now
            };

            context.Accounts.Add(account);
            context.SaveChanges();

            return account;
        }

        // 2. Phương thức thanh toán
        private static void SeedPaymentMethods(AppDbContext context)
        {
            var paymentMethods = new List<PaymentMethod>
            {
                new PaymentMethod
                {
                    PaymentMethodName = "Tiền mặt",
                    Description = "Thanh toán trực tiếp bằng tiền mặt.",
                    IsCash = true,
                    Status = PaymentMethodStatus.Active
                },
                new PaymentMethod
                {
                    PaymentMethodName = "Chuyển khoản",
                    Description = "Thanh toán bằng hình thức chuyển khoản.",
                    IsCash = false,
                    Status = PaymentMethodStatus.Active
                }
            };

            foreach (var item in paymentMethods)
            {
                bool exists = context.PaymentMethods
                    .Any(p => p.PaymentMethodName.ToLower() == item.PaymentMethodName.ToLower());

                if (!exists)
                    context.PaymentMethods.Add(item);
            }

            context.SaveChanges();
        }

        // 3. Dịch vụ
        private static void SeedServices(AppDbContext context)
        {
            var services = new List<Service>
            {
                new Service
                {
                    ServiceName = "Khám răng tổng quát",
                    Description = "Khám và đánh giá tình trạng răng miệng tổng quát.",
                    UnitPrice = 100000,
                    IsLongTerm = false,
                    Status = ServiceStatus.Active
                },
                new Service
                {
                    ServiceName = "Cạo vôi răng",
                    Description = "Làm sạch mảng bám và cao răng.",
                    UnitPrice = 200000,
                    IsLongTerm = false,
                    Status = ServiceStatus.Active
                },
                new Service
                {
                    ServiceName = "Trám răng",
                    Description = "Phục hồi răng sâu hoặc răng bị tổn thương bằng vật liệu trám.",
                    UnitPrice = 250000,
                    IsLongTerm = false,
                    Status = ServiceStatus.Active
                },
                new Service
                {
                    ServiceName = "Nhổ răng",
                    Description = "Thực hiện nhổ răng theo chỉ định của bác sĩ.",
                    UnitPrice = 300000,
                    IsLongTerm = false,
                    Status = ServiceStatus.Active
                },
                new Service
                {
                    ServiceName = "Điều trị tủy răng",
                    Description = "Điều trị tủy răng theo nhiều buổi khi cần thiết.",
                    UnitPrice = 1500000,
                    IsLongTerm = true,
                    Status = ServiceStatus.Active
                },
                new Service
                {
                    ServiceName = "Niềng răng",
                    Description = "Điều trị chỉnh nha theo kế hoạch nhiều buổi.",
                    UnitPrice = 30000000,
                    IsLongTerm = true,
                    Status = ServiceStatus.Active
                },
                new Service
                {
                    ServiceName = "Tẩy trắng răng",
                    Description = "Cải thiện màu sắc răng bằng phương pháp tẩy trắng.",
                    UnitPrice = 2500000,
                    IsLongTerm = false,
                    Status = ServiceStatus.Active
                }
            };

            foreach (var item in services)
            {
                bool exists = context.Services
                    .Any(s => s.ServiceName.ToLower() == item.ServiceName.ToLower());

                if (!exists)
                    context.Services.Add(item);
            }

            context.SaveChanges();
        }

        // 4. Nhà cung cấp
        private static void SeedSuppliers(AppDbContext context)
        {
            var suppliers = new List<Supplier>
            {
                new Supplier
                {
                    SupplierName = "Công ty Thiết bị Nha khoa Đăng Dương",
                    Phone = "02838000001",
                    Address = "Quận 10, TP. Hồ Chí Minh",
                    Email = "dangduong@gmail.com",
                    Note = "Nhà cung cấp vật tư và thuốc nha khoa.",
                    IsActive = true
                },
                new Supplier
                {
                    SupplierName = "Công ty Dược phẩm An Khang",
                    Phone = "02838000002",
                    Address = "Quận 3, TP. Hồ Chí Minh",
                    Email = "ankhang@gmail.com",
                    Note = "Cung cấp thuốc và vật tư y tế.",
                    IsActive = true
                },
                new Supplier
                {
                    SupplierName = "Nha khoa Hải Nam Việt Nam",
                    Phone = "02838000003",
                    Address = "TP. Thủ Đức, TP. Hồ Chí Minh",
                    Email = "hainam@gmail.com",
                    Note = "Cung cấp sản phẩm hỗ trợ điều trị nha khoa.",
                    IsActive = true
                }
            };

            foreach (var item in suppliers)
            {
                bool exists = context.Suppliers
                    .Any(s => s.SupplierName.ToLower() == item.SupplierName.ToLower());

                if (!exists)
                    context.Suppliers.Add(item);
            }

            context.SaveChanges();
        }

        // 5. Thuốc
        private static void SeedMedicines(AppDbContext context)
        {
            var medicines = new List<Medicine>
            {
                new Medicine
                {
                    MedicineName = "Paracetamol 500mg",
                    Unit = "Viên",
                    UnitPrice = 1500,
                    QuantityInStock = 100,
                    Description = "Thuốc giảm đau, hạ sốt.",
                    Status = MedicineStatus.Active
                },
                new Medicine
                {
                    MedicineName = "Amoxicillin 500mg",
                    Unit = "Viên",
                    UnitPrice = 3000,
                    QuantityInStock = 100,
                    Description = "Kháng sinh dùng theo chỉ định.",
                    Status = MedicineStatus.Active
                },
                new Medicine
                {
                    MedicineName = "Ibuprofen 400mg",
                    Unit = "Viên",
                    UnitPrice = 2500,
                    QuantityInStock = 100,
                    Description = "Thuốc giảm đau và chống viêm.",
                    Status = MedicineStatus.Active
                },
                new Medicine
                {
                    MedicineName = "Metronidazole 250mg",
                    Unit = "Viên",
                    UnitPrice = 1500,
                    QuantityInStock = 100,
                    Description = "Thuốc kháng khuẩn dùng theo chỉ định.",
                    Status = MedicineStatus.Active
                },
                new Medicine
                {
                    MedicineName = "Cephalexin 500mg",
                    Unit = "Viên",
                    UnitPrice = 2500,
                    QuantityInStock = 100,
                    Description = "Kháng sinh dùng theo chỉ định.",
                    Status = MedicineStatus.Active
                },
                new Medicine
                {
                    MedicineName = "Alpha Chymotrypsin 4.2mg",
                    Unit = "Viên",
                    UnitPrice = 3000,
                    QuantityInStock = 80,
                    Description = "Hỗ trợ giảm phù nề theo chỉ định.",
                    Status = MedicineStatus.Active
                },
                new Medicine
                {
                    MedicineName = "Vitamin C 500mg",
                    Unit = "Viên",
                    UnitPrice = 1000,
                    QuantityInStock = 120,
                    Description = "Bổ sung vitamin C.",
                    Status = MedicineStatus.Active
                },
                new Medicine
                {
                    MedicineName = "Dung dịch súc miệng Chlorhexidine 0.12%",
                    Unit = "Chai",
                    UnitPrice = 75000,
                    QuantityInStock = 30,
                    Description = "Dung dịch súc miệng hỗ trợ vệ sinh răng miệng.",
                    Status = MedicineStatus.Active
                }
            };

            foreach (var item in medicines)
            {
                bool exists = context.Medicines
                    .Any(m => m.MedicineName.ToLower() == item.MedicineName.ToLower());

                if (!exists)
                    context.Medicines.Add(item);
            }

            context.SaveChanges();
        }

        // 6. Bệnh nhân 
        private static void SeedPatients(AppDbContext context)
        {
            var patients = new List<Patient>
            {
                new Patient
                {
                    FullName = "Nguyễn Ngọc Anh",
                    Gender = Gender.Female,
                    DateOfBirth = new DateOnly(2000, 2, 18),
                    Phone = "0911000001",
                    Email = "patient01@example.com",
                    Address = "Quận 1, TP. Hồ Chí Minh",
                    Note = null
                },
                new Patient
                {
                    FullName = "Hoàng Vân Anh",
                    Gender = Gender.Female,
                    DateOfBirth = new DateOnly(1998, 7, 25),
                    Phone = "0911000002",
                    Email = "patient02@example.com",
                    Address = "Quận 5, TP. Hồ Chí Minh",
                    Note = null
                },
                new Patient
                {
                    FullName = "Trương Mỹ Duyên",
                    Gender = Gender.Female,
                    DateOfBirth = new DateOnly(1989, 10, 6),
                    Phone = "0911000003",
                    Email = "patient03@example.com",
                    Address = "Quận Bình Thạnh, TP. Hồ Chí Minh",
                    Note = null
                },
                new Patient
                {
                    FullName = "Trần Lan Hương",
                    Gender = Gender.Female,
                    DateOfBirth = new DateOnly(2002, 4, 12),
                    Phone = "0911000004",
                    Email = "patient04@example.com",
                    Address = "Quận Tân Bình, TP. Hồ Chí Minh",
                    Note = null
                },
                new Patient
                {
                    FullName = "Bùi Thu Hương",
                    Gender = Gender.Female,
                    DateOfBirth = new DateOnly(1995, 12, 3),
                    Phone = "0911000005",
                    Email = "patient05@example.com",
                    Address = "Quận Gò Vấp, TP. Hồ Chí Minh",
                    Note = null
                },
                new Patient
                {
                    FullName = "Lê Huyền",
                    Gender = Gender.Female,
                    DateOfBirth = new DateOnly(2005, 4, 23),
                    Phone = "0911000006",
                    Email = "patient05@example.com",
                    Address = "Quận Bình Thạnh, TP. Hồ Chí Minh",
                    Note = null
                },
                new Patient
                {
                    FullName = "Nguyễn Thành Tài",
                    Gender = Gender.Male,
                    DateOfBirth = new DateOnly(1999, 1, 14),
                    Phone = "0911000007",
                    Email = "patient07@example.com",
                    Address = "Quận 12, TP. Hồ Chí Minh",
                    Note = null
                },
                new Patient
                {
                    FullName = "Đặng Nhựt Tân",
                    Gender = Gender.Male,
                    DateOfBirth = new DateOnly(1988, 12, 12),
                    Phone = "0911000008",
                    Email = "patient08@example.com",
                    Address = "Quận 11, TP. Hồ Chí Minh",
                    Note = null
                },
                new Patient
                {
                    FullName = "Giang Nhật Nguyên",
                    Gender = Gender.Male,
                    DateOfBirth = new DateOnly(2005, 6, 1),
                    Phone = "0911000009",
                    Email = "patient09@example.com",
                    Address = "Quận Tân Phú, TP. Hồ Chí Minh",
                    Note = null
                }
            };

            foreach (var item in patients)
            {
                bool exists = context.Patients
                    .Any(p => p.Phone == item.Phone);

                if (!exists)
                    context.Patients.Add(item);
            }

            context.SaveChanges();
        }
    }
}
