using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DentalClinic.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        // ConnectionString configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? conn = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
                optionsBuilder.UseSqlServer(conn ?? "Server=.\\SQLEXPRESS;Database=DentalClinicDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        // 1
        public DbSet<Account> Accounts { get; set; }
        // 2
        public DbSet<Appointment> Appointments { get; set; }
        // 3
        public DbSet<Doctor> Doctors { get; set; }
        // 4
        public DbSet<Invoice> Invoices { get; set; }
        // 5
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        // 6
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        // 7
        public DbSet<MedicalRecordService> MedicalRecordServices { get; set; }
        // 8
        public DbSet<Medicine> Medicines { get; set; }
        // 9
        public DbSet<Patient> Patients { get; set; }
        // 10
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        // 11
        public DbSet<Prescription> Prescriptions { get; set; }
        // 12
        public DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        // 13
        public DbSet<Receptionist> Receptionists { get; set; }
        // 14
        public DbSet<Service> Services { get; set; }
        // 15
        public DbSet<Visit> Visits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Account
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                // AccountId
                entity.HasKey(a => a.AccountId);

                // UserName
                entity.Property(a => a.UserName)
                      .IsRequired()
                      .HasMaxLength(50);

                // Password
                entity.Property(a => a.Password)
                      .IsRequired()
                      .HasMaxLength(255);

                // Role
                entity.Property(a => a.Role)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(20);

                // Status
                entity.Property(a => a.Status)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(20)
                      .HasDefaultValue(AccountStatus.Active);

                // CreatedDate
                entity.Property(a => a.CreatedDate)
                      .IsRequired()
                      .HasDefaultValueSql("GETDATE()");
            });

            // 2. Appointment
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                // AppointmentId
                entity.HasKey(a => a.AppointmentId);

                // AppointmentDateTime
                entity.Property(a => a.AppointmentDateTime)
                      .IsRequired();

                // Status
                entity.Property(a => a.Status)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(20)
                      .HasDefaultValue(AppointmentStatus.Scheduled);

                // Note
                entity.Property(a => a.Note)
                      .IsRequired(false)
                      .HasMaxLength(1000);

                // CreatedDate
                entity.Property(a => a.CreatedDate)
                      .IsRequired()
                      .HasDefaultValueSql("GETDATE()");

                // Relationship 1: Patient 
                entity.HasOne(a => a.Patient)
                      .WithMany()
                      .HasForeignKey(a => a.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relationship 2: Doctor 
                entity.HasOne(a => a.Doctor)
                      .WithMany()
                      .HasForeignKey(a => a.DoctorId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relationship 3: Receptionist
                entity.HasOne(a => a.Receptionist)
                      .WithMany()
                      .HasForeignKey(a => a.ReceptionistId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 3. Doctor
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                // DoctorId
                entity.HasKey(d => d.DoctorId);

                // FullName
                entity.Property(d => d.FullName)
                      .IsRequired()
                      .HasMaxLength(100);

                // Gender
                entity.Property(d => d.Gender)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(10);

                // DateOfBirth
                entity.Property(d => d.DateOfBirth)
                      .IsRequired()
                      .HasColumnType("date");

                // Phone
                entity.Property(d => d.Phone)
                      .IsRequired()
                      .HasMaxLength(15);

                // Email
                entity.Property(d => d.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                // Description
                entity.Property(d => d.Description)
                      .IsRequired(false)
                      .HasMaxLength(1000);

                // ProfileImage
                entity.Property(d => d.ProfileImage)
                      .IsRequired(false)
                      .HasMaxLength(255);

                // Relationship: Account 
                entity.HasOne(d => d.Account)
                      .WithOne(a => a.Doctor)
                      .HasForeignKey<Doctor>(d => d.AccountId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 4. Invoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                // InvoiceId
                entity.HasKey(i => i.InvoiceId);

                // InvoiceDateTime
                entity.Property(i => i.InvoiceDateTime)
                      .IsRequired()
                      .HasDefaultValueSql("GETDATE()");

                // TotalAmount
                entity.Property(i => i.TotalAmount)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                // AmountGiven
                entity.Property(i => i.AmountGiven)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                // ChangeAmount
                entity.Property(i => i.ChangeAmount)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                // PaymentStatus
                entity.Property(i => i.Status)
                      .HasConversion<string>()
                      .HasMaxLength(50)
                      .IsRequired();

                // Relationship 1: PaymentMethod
                entity.HasOne(i => i.PaymentMethod)
                      .WithMany()
                      .HasForeignKey(i => i.PaymentMethodId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);

                // Relationship 2: Visit
                entity.HasOne(i => i.Visit)
                      .WithMany(v => v.Invoices)
                      .HasForeignKey(i => i.VisitId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);

                // Relationship 3: Receptionist
                entity.HasOne(i => i.Receptionist)
                      .WithMany()
                      .HasForeignKey(i => i.ReceptionistId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 5. InvoiceDetail
            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("InvoiceDetail", table =>
                {
                    table.HasCheckConstraint(
                        "CK_InvoiceDetail_ExactlyOneItem",
                        "(MedicalRecordServiceId IS NOT NULL AND PrescriptionDetailId IS NULL) OR " +
                        "(MedicalRecordServiceId IS NULL AND PrescriptionDetailId IS NOT NULL)"
                    );
                });

                // InvoiceDetailId
                entity.HasKey(id => id.InvoiceDetailId);

                // ItemName
                entity.Property(id => id.ItemName)
                      .IsRequired()
                      .HasMaxLength(200);

                // Quantity
                entity.Property(id => id.Quantity)
                      .IsRequired();

                // UnitPrice
                entity.Property(id => id.UnitPrice)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                // TotalAmount:
                entity.Property(id => id.TotalAmount)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                // Relationship 1: Invoice 
                entity.HasOne(id => id.Invoice)
                      .WithMany(i => i.InvoiceDetails)
                      .HasForeignKey(id => id.InvoiceId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship 2: MedicalRecordService (Nullable)
                entity.HasOne(id => id.MedicalRecordService)
                      .WithMany()
                      .HasForeignKey(id => id.MedicalRecordServiceId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relationship 3: PrescriptionDetail (Nullable)
                entity.HasOne(id => id.PrescriptionDetail)
                      .WithMany()
                      .HasForeignKey(id => id.PrescriptionDetailId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 6. MedicalRecord
            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.ToTable("MedicalRecord");

                // MedicalRecordId
                entity.HasKey(m => m.MedicalRecordId);

                // ExaminationDateTime
                entity.Property(m => m.ExaminationDateTime)
                      .IsRequired()
                      .HasDefaultValueSql("GETDATE()");

                // Diagnosis
                entity.Property(m => m.Diagnosis)
                      .IsRequired()
                      .HasMaxLength(1000);

                // Conclusion
                entity.Property(m => m.Conclusion)
                      .IsRequired()
                      .HasMaxLength(1000);

                // Relationship: Visit
                entity.HasOne(m => m.Visit)
                      .WithOne(v => v.MedicalRecord)
                      .HasForeignKey<MedicalRecord>(m => m.VisitId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 7. MedicalRecordService
            modelBuilder.Entity<MedicalRecordService>(entity =>
            {
                entity.ToTable("MedicalRecordService");

                // MedicalRecordServiceId
                entity.HasKey(mrs => mrs.MedicalRecordServiceId);

                // Quantity
                entity.Property(mrs => mrs.Quantity)
                      .IsRequired();

                // UnitPrice
                entity.Property(mrs => mrs.UnitPrice)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                // TotalAmount
                entity.Property(mrs => mrs.TotalAmount)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                // Status
                entity.Property(mrs => mrs.Status)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(20)
                      .HasDefaultValue(MedicalRecordServiceStatus.Pending);

                // Note
                entity.Property(mrs => mrs.Note)
                      .IsRequired(false)
                      .HasMaxLength(1000);

                // Relationship 1: MedicalRecord 
                entity.HasOne(mrs => mrs.MedicalRecord)
                       .WithMany(mr => mr.MedicalRecordServices)
                       .HasForeignKey(mrs => mrs.MedicalRecordId)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Restrict);

                // Relationship 2: Service 
                entity.HasOne(mrs => mrs.Service)
                      .WithMany()
                      .HasForeignKey(mrs => mrs.ServiceId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 8. Medicine
            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                // MedicineId
                entity.HasKey(m => m.MedicineId);

                // MedicineName
                entity.Property(m => m.MedicineName)
                      .IsRequired()
                      .HasMaxLength(200);

                // Unit
                entity.Property(m => m.Unit)
                      .IsRequired()
                      .HasMaxLength(20);

                // UnitPrice
                entity.Property(m => m.UnitPrice)
                      .IsRequired()
                      .HasColumnType("decimal(18, 2)");

                // QuantityInStock
                entity.Property(m => m.QuantityInStock)
                      .IsRequired()
                      .HasDefaultValue(0);

                // Description
                entity.Property(m => m.Description)
                      .IsRequired(false)
                      .HasMaxLength(1000);

                // Status
                entity.Property(m => m.Status)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(20)
                      .HasDefaultValue(MedicineStatus.Active);
            });

            // 9. Patient
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                // PatientId
                entity.HasKey(p => p.PatientId);

                // FullName
                entity.Property(p => p.FullName)
                      .IsRequired()
                      .HasMaxLength(100);

                // Gender
                entity.Property(p => p.Gender)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(10);

                // DateOfBirth
                entity.Property(p => p.DateOfBirth)
                      .IsRequired()
                      .HasColumnType("date");

                // Phone
                entity.Property(p => p.Phone)
                      .IsRequired()
                      .HasMaxLength(15);

                // Email
                entity.Property(p => p.Email)
                      .IsRequired(false)
                      .HasMaxLength(100);

                // Address
                entity.Property(p => p.Address)
                      .IsRequired(false)
                      .HasMaxLength(255);

                // Note
                entity.Property(p => p.Note)
                      .IsRequired(false)
                      .HasMaxLength(1000);
            });

            // 10. PaymentMethod
            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                // PaymentMethodId
                entity.HasKey(pm => pm.PaymentMethodId);

                // PaymentMethodName
                entity.Property(pm => pm.PaymentMethodName)
                      .IsRequired()
                      .HasMaxLength(50);

                // Description
                entity.Property(pm => pm.Description)
                      .IsRequired(false)
                      .HasMaxLength(250);

                // IsCash
                entity.Property(pm => pm.IsCash)
                      .IsRequired();

                // Status
                entity.Property(pm => pm.Status)
                      .HasConversion<string>()
                      .HasMaxLength(50)
                      .IsRequired()
                      .HasDefaultValue(PaymentMethodStatus.Active);
            });

            // 11. Prescription
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescription");

                // PrescriptionId
                entity.HasKey(p => p.PrescriptionId);

                // CreatedDate
                entity.Property(p => p.CreatedDate)
                      .HasDefaultValueSql("GETDATE()");

                // Note
                entity.Property(p => p.Note)
                      .HasMaxLength(1000);

                // Relationship: MedicalRecord 
                entity.HasOne(p => p.MedicalRecord)
                      .WithOne(m => m.Prescription)
                      .HasForeignKey<Prescription>(p => p.MedicalRecordId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 12. PrescriptionDetail
            modelBuilder.Entity<PrescriptionDetail>(entity =>
            {
                entity.ToTable("PrescriptionDetail");

                // PrescriptionDetailId
                entity.HasKey(pd => pd.PrescriptionDetailId);

                // Dosage (morning, noon, afteroon, evening)
                entity.Property(pd => pd.Morning).IsRequired();
                entity.Property(pd => pd.Noon).IsRequired();
                entity.Property(pd => pd.Afternoon).IsRequired();
                entity.Property(pd => pd.Evening).IsRequired();

                // Days
                entity.Property(pd => pd.Days).IsRequired();

                // Quantity
                entity.Property(pd => pd.Quantity).IsRequired();

                // Instruction
                entity.Property(pd => pd.Instruction)
                      .HasMaxLength(200) 
                      .IsRequired(false); 

                // Relationship 1: Prescription
                entity.HasOne(pd => pd.Prescription)
                      .WithMany(p => p.PrescriptionDetails)
                      .HasForeignKey(pd => pd.PrescriptionId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade); 

                // Relationship 2: Medicine
                entity.HasOne(pd => pd.Medicine)
                      .WithMany()
                      .HasForeignKey(pd => pd.MedicineId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 13. Receptionist
            modelBuilder.Entity<Receptionist>(entity =>
            {
                entity.ToTable("Receptionist");

                // ReceptionistId
                entity.HasKey(r => r.ReceptionistId);

                // FullName
                entity.Property(r => r.FullName)
                      .IsRequired()
                      .HasMaxLength(100);

                // Gender
                entity.Property(r => r.Gender)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(10);

                // DateOfBirth
                entity.Property(r => r.DateOfBirth)
                      .IsRequired()
                      .HasColumnType("date");

                // Phone
                entity.Property(r => r.Phone)
                      .IsRequired()
                      .HasMaxLength(15);

                // Email
                entity.Property(r => r.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                // Description
                entity.Property(r => r.Description)
                      .IsRequired(false)
                      .HasMaxLength(1000); 

                // Relationship: Account 
                entity.HasOne(r => r.Account)
                      .WithOne(a => a.Receptionist)
                      .HasForeignKey<Receptionist>(r => r.AccountId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 14. Service
            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                // ServiceId 
                entity.HasKey(s => s.ServiceId);

                // ServiceName
                entity.Property(s => s.ServiceName)
                      .IsRequired()
                      .HasMaxLength(200);

                // Description
                entity.Property(s => s.Description)
                      .IsRequired(false)
                      .HasMaxLength(1000);

                // UnitPrice
                entity.Property(s => s.UnitPrice)
                      .IsRequired()
                      .HasColumnType("decimal(18, 2)");

                // Status
                entity.Property(s => s.Status)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(20)
                      .HasDefaultValue(ServiceStatus.Active);
            });

            // 15. Visit
            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("Visit");

                entity.HasKey(v => v.VisitId);

                // CheckInDateTime
                entity.Property(v => v.CheckInDateTime)
                      .IsRequired()
                      .HasDefaultValueSql("GETDATE()");

                // ReasonForVisit
                entity.Property(v => v.ReasonForVisit)
                      .IsRequired()
                      .HasMaxLength(1000);

                // Status
                entity.Property(v => v.Status)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(30)
                      .HasDefaultValue(VisitStatus.Waiting);

                // QueueNumber
                entity.Property(v => v.QueueNumber)
                      .IsRequired();

                // Relationship 1: Patient
                entity.HasOne(v => v.Patient)
                      .WithMany()
                      .HasForeignKey(v => v.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relationship 2: Appointment, nullable
                entity.HasOne(v => v.Appointment)
                      .WithOne(a => a.Visit)
                      .HasForeignKey<Visit>(v => v.AppointmentId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relationship 3: Doctor
                entity.HasOne(v => v.Doctor)
                      .WithMany()
                      .HasForeignKey(v => v.DoctorId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relationship 4: Receptionist
                entity.HasOne(v => v.Receptionist)
                      .WithMany()
                      .HasForeignKey(v => v.ReceptionistId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
