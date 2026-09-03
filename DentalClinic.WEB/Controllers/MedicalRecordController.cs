using DentalClinic.BLL;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.WEB.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly MedicalRecord_BLL _medicalRecordBLL;

        public MedicalRecordController(
            MedicalRecord_BLL medicalRecordBLL)
        {
            _medicalRecordBLL = medicalRecordBLL;
        }

        [HttpGet]
        public IActionResult History()
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

            var history =
                _medicalRecordBLL
                    .GetPatientHistoryByPatientId(patientId);

            return View(history);
        }

        private bool IsPatientLoggedIn()
        {
            return HttpContext.Session
                .GetInt32("PatientId")
                .HasValue;
        }
    }
}