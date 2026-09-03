using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.WEB.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string fullName, string email, string message)
        {
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(message))
            {
                ViewBag.ErrorMessage = "Vui lòng nhập đầy đủ thông tin.";
                return View();
            }

            ViewBag.SuccessMessage = "Cảm ơn bạn đã liên hệ với Phòng khám Nha khoa MP.";

            return View();
        }
    }
}