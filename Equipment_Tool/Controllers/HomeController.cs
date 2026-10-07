using Equipment_Tool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Equipment_Tool.Controllers
{
    public class HomeController : Controller
    {
        // Milestone 2: Home page
        public IActionResult Index()
        {
            return View();
        }

        // Milestone 3: Request form (GET shows empty form)
        [HttpGet("RequestForm")]
        public IActionResult RequestForm()
        {
            return View();
        }

        // Milestone 3: Request form (POST saves or redisplays with errors)
        [HttpPost("RequestForm")]
        [ValidateAntiForgeryToken]
        public IActionResult RequestForm(EquipmentRequest request)
        {
            if (ModelState.IsValid)
            {
                Repository.AddRequest(request);
                return View("Confirmation", request);
            }
            return View(request);
        }
        
        // Milestone 4: All equipment
        [HttpGet("AllEquipment")]
        public IActionResult AllEquipment()
        {
            return View(EquipmentRepository.AllEquipment);
        }

        // Milestone 4: Available equipment only
        [HttpGet("AvailableEquipment")]
        public IActionResult AvailableEquipment()
        {
            return View(EquipmentRepository.AvailableEquipment);
        }
        
        // Milestone 5: Admin page - URL only, not in the menu
        [HttpGet("Requests")]
        public IActionResult Requests()
        {
            return View(Repository.Requests);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}