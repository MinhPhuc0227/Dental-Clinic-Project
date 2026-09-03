using DentalClinic.BLL;
using DentalClinic.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// Database
// ========================================
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// ========================================
// DAL
// ========================================
builder.Services.AddScoped<Account_DAL>();
builder.Services.AddScoped<Appointment_DAL>();
builder.Services.AddScoped<Dashboard_DAL>();
builder.Services.AddScoped<Doctor_DAL>();
builder.Services.AddScoped<Invoice_DAL>();
builder.Services.AddScoped<MedicalRecord_DAL>();
builder.Services.AddScoped<Medicine_DAL>();
builder.Services.AddScoped<MedicineImport_DAL>();
builder.Services.AddScoped<Patient_DAL>();
builder.Services.AddScoped<PaymentMethod_DAL>();
builder.Services.AddScoped<Receptionist_DAL>();
builder.Services.AddScoped<Service_DAL>();
builder.Services.AddScoped<Supplier_DAL>();
builder.Services.AddScoped<Visit_DAL>();

// ========================================
// BLL
// ========================================
builder.Services.AddScoped<Account_BLL>();
builder.Services.AddScoped<Appointment_BLL>();
builder.Services.AddScoped<Dashboard_BLL>();
builder.Services.AddScoped<Doctor_BLL>();
builder.Services.AddScoped<Invoice_BLL>();
builder.Services.AddScoped<MedicalRecord_BLL>();
builder.Services.AddScoped<Medicine_BLL>();
builder.Services.AddScoped<MedicineImport_BLL>();
builder.Services.AddScoped<Patient_BLL>();
builder.Services.AddScoped<PaymentMethod_BLL>();
builder.Services.AddScoped<Receptionist_BLL>();
builder.Services.AddScoped<Service_BLL>();
builder.Services.AddScoped<Supplier_BLL>();
builder.Services.AddScoped<Visit_BLL>();

// ========================================
// MVC
// ========================================
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// ========================================
// HTTP pipeline
// ========================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();