using DentalClinic.BLL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.WEB.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly Appointment_BLL _appointmentBLL;

        public AppointmentController(
            Appointment_BLL appointmentBLL)
        {
            _appointmentBLL = appointmentBLL;
        }

        // =========================
        // HIỂN THỊ TRANG ĐẶT LỊCH
        // =========================
        [HttpGet]
        public IActionResult Index()
        {
            if (!IsPatientLoggedIn())
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            LoadDoctors();

            return View();
        }

        // =========================
        // XỬ LÝ ĐẶT LỊCH ONLINE
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(
            OnlineAppointmentCreateDto dto)
        {
            if (!IsPatientLoggedIn())
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            int patientId =
                HttpContext.Session
                    .GetInt32("PatientId")!.Value;

            if (!ModelState.IsValid)
            {
                LoadDoctors();
                return View(dto);
            }

            var result =
                _appointmentBLL.CreateOnline(
                    patientId,
                    dto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(
                    string.Empty,
                    result.Message);

                LoadDoctors();
                return View(dto);
            }

            TempData["SuccessMessage"] =
                result.Message;

            return RedirectToAction(
                "MyAppointments");
        }

        // =========================
        // LỊCH HẸN CỦA TÔI
        // =========================
        [HttpGet]
        public IActionResult MyAppointments()
        {
            if (!IsPatientLoggedIn())
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            int patientId =
                HttpContext.Session
                    .GetInt32("PatientId")!.Value;

            var result =
                _appointmentBLL.GetByPatientId(patientId);

            if (!result.IsSuccess || result.Data == null)
            {
                return View(
                    new List<AppointmentListDto>());
            }

            return View(result.Data);
        }

        // HỦY LỊCH HẸN
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(int id)
        {
            if (!IsPatientLoggedIn())
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            int patientId =
                HttpContext.Session
                    .GetInt32("PatientId")!.Value;

            var result =
                _appointmentBLL.CancelByPatient(
                    id,
                    patientId);

            TempData["SuccessMessage"] =
                result.Message;

            return RedirectToAction(
                "MyAppointments");
        }

        // =========================
        // LOAD DANH SÁCH BÁC SĨ
        // =========================
        private void LoadDoctors()
        {
            var result =
                _appointmentBLL.GetDoctorsLookup();

            ViewBag.Doctors =
                result.IsSuccess && result.Data != null
                    ? result.Data
                    : new List<LookupItemDto>();
        }

        // =========================
        // KIỂM TRA ĐĂNG NHẬP
        // =========================
        private bool IsPatientLoggedIn()
        {
            return HttpContext.Session
                .GetInt32("PatientId")
                .HasValue;
        }
    }
}