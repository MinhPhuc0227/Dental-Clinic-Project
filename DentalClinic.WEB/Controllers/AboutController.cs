using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.WEB.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}