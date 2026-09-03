using DentalClinic.App;
using DentalClinic.BLL;
using DentalClinic.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.APP
{
    internal static class Programn
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Khởi tạo dữ liệu mặc định
            DbInitializer.Seed();

            // =========================
            // 1. Tạo DI container
            // =========================
            var services = new ServiceCollection();
            services.AddSingleton<IServiceProvider>(sp => sp);

            // =========================
            // 2. Database
            // =========================
            services.AddScoped<AppDbContext>();

            // =========================
            // 3. DAL
            // =========================
            services.AddScoped<Account_DAL>();
            services.AddScoped<Appointment_DAL>();
            services.AddScoped<Dashboard_DAL>();
            services.AddScoped<Doctor_DAL>();
            services.AddScoped<Invoice_DAL>();
            services.AddScoped<MedicalRecord_DAL>();
            services.AddScoped<Medicine_DAL>();
            services.AddScoped<MedicineImport_DAL>();
            services.AddScoped<Patient_DAL>();
            services.AddScoped<PaymentMethod_DAL>();
            services.AddScoped<Receptionist_DAL>();
            services.AddScoped<Service_DAL>();
            services.AddScoped<Supplier_DAL>();
            services.AddScoped<Visit_DAL>();

            // =========================
            // 4. BLL
            // =========================
            services.AddScoped<Account_BLL>();
            services.AddScoped<Appointment_BLL>();
            services.AddScoped<Dashboard_BLL>();
            services.AddScoped<Doctor_BLL>();
            services.AddScoped<Invoice_BLL>();
            services.AddScoped<MedicalRecord_BLL>();
            services.AddScoped<Medicine_BLL>();
            services.AddScoped<MedicineImport_BLL>();
            services.AddScoped<Patient_BLL>();
            services.AddScoped<PaymentMethod_BLL>();
            services.AddScoped<Receptionist_BLL>();
            services.AddScoped<Service_BLL>();
            services.AddScoped<Supplier_BLL>();
            services.AddScoped<Visit_BLL>();

            // =========================
            // 5. Form
            // =========================
            services.AddTransient<Form_Login>();
            services.AddTransient<Form_Admin>();
            services.AddTransient<Form_Doctor>();
            services.AddTransient<Form_Receptionist>();

            services.AddTransient<UC_Account>();
            services.AddTransient<Dialog_Account>();
            services.AddTransient<Dialog_Admin>();
            services.AddTransient<UC_Medicine>();
            services.AddTransient<Dialog_Medicine>();
            services.AddTransient<Dialog_MedicineImport>();
            services.AddTransient<Dialog_MedicineImportHistory>();
            services.AddTransient<UC_Supplier>();
            // =========================
            // 6. Build DI container
            // =========================
            using var serviceProvider = services.BuildServiceProvider();

            // Tạo scope cho ứng dụng WinForms
            using var scope = serviceProvider.CreateScope();

            // Lấy Form_Login từ DI
            var loginForm = scope.ServiceProvider
                .GetRequiredService<Form_Login>();

            Application.Run(loginForm);
        }
    }
}