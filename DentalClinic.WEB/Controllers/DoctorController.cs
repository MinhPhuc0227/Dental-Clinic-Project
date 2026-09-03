using DentalClinic.BLL;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.WEB.Controllers
{
    public class DoctorController : Controller
    {
        private readonly Doctor_BLL _doctorBLL;

        public DoctorController(Doctor_BLL doctorBLL)
        {
            _doctorBLL = doctorBLL;
        }

        public IActionResult Index()
        {
            var result = _doctorBLL.GetAll();

            if (!result.IsSuccess || result.Data == null)
            {
                return View(new List<DentalClinic.DTO.DoctorDto>());
            }

            return View(result.Data);
        }

        public IActionResult Details(int id)
        {
            var result = _doctorBLL.GetById(id);

            if (!result.IsSuccess || result.Data == null)
            {
                return NotFound();
            }

            return View(result.Data);
        }
    }
}