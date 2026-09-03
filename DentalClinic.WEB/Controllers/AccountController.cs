using DentalClinic.BLL;
using DentalClinic.DTO;
using DentalClinic.MODEL;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly Account_BLL _accountBLL;
        private readonly Patient_BLL _patientBLL;

        public AccountController(
            Account_BLL accountBLL,
            Patient_BLL patientBLL)
        {
            _accountBLL = accountBLL;
            _patientBLL = patientBLL;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterPatientDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = _accountBLL.RegisterPatient(dto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(
                    string.Empty,
                    result.Message);

                return View(dto);
            }

            TempData["SuccessMessage"] =
                "Đăng ký tài khoản thành công. Vui lòng đăng nhập.";

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = _accountBLL.Login(dto);

            if (!result.IsSuccess || result.Data == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    result.Message);

                return View(dto);
            }

            var account = result.Data;

            if (account.Role != AccountRole.Patient)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Tài khoản này không được sử dụng để đăng nhập website.");

                return View(dto);
            }

            if (!account.PatientId.HasValue)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Tài khoản chưa được liên kết với hồ sơ bệnh nhân.");

                return View(dto);
            }

            HttpContext.Session.SetInt32(
                "AccountId",
                account.AccountId);

            HttpContext.Session.SetInt32(
                "PatientId",
                account.PatientId.Value);

            HttpContext.Session.SetString(
                "UserName",
                account.UserName);

            HttpContext.Session.SetString(
                "FullName",
                account.FullName);

            return RedirectToAction(
                "Index",
                "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(
                "Index",
                "Home");
        }

        // =========================
        // KIỂM TRA BỆNH NHÂN ĐÃ ĐĂNG NHẬP
        // =========================
        private bool IsPatientLoggedIn()
        {
            return HttpContext.Session
                .GetInt32("PatientId")
                .HasValue;
        }

        // =========================
        // XEM HỒ SƠ
        // =========================
        [HttpGet]
        public IActionResult Profile()
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
                _patientBLL.GetById(patientId);

            if (!result.IsSuccess || result.Data == null)
            {
                return NotFound();
            }

            return View(result.Data);
        }

        // =========================
        // CẬP NHẬT HỒ SƠ
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(PatientDto dto)
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

            // Không cho client tự đổi PatientId
            dto.PatientId = patientId;

            var updateDto = new UpdatePatientDto
            {
                PatientId = patientId,
                FullName = dto.FullName,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                Phone = dto.Phone,
                Email = dto.Email,
                Address = dto.Address,
                Note = dto.Note
            };

            var result =
                _patientBLL.Update(updateDto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(
                    string.Empty,
                    result.Message);

                return View(dto);
            }

            HttpContext.Session.SetString(
                "FullName",
                dto.FullName);

            TempData["SuccessMessage"] =
                "Cập nhật thông tin thành công.";

            return RedirectToAction("Profile");
        }
    }
}