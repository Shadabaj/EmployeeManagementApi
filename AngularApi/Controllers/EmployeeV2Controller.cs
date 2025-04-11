using Microsoft.AspNetCore.Mvc;

namespace UIAPI.Controllers
{
    public class EmployeeV2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
