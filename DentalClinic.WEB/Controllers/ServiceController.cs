using DentalClinic.BLL;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.WEB.Controllers
{
    public class ServiceController : Controller
    {
        private readonly Service_BLL _serviceBLL;

        public ServiceController(Service_BLL serviceBLL)
        {
            _serviceBLL = serviceBLL;
        }

        public IActionResult Index()
        {
            var result = _serviceBLL.GetAll();

            if (!result.IsSuccess || result.Data == null)
            {
                return View(new List<DentalClinic.DTO.ServiceDto>());
            }

            return View(result.Data);
        }
    }
}