using Microsoft.AspNetCore.Mvc;

namespace informatic_asp_mvc.Controllers
{
    public class HomeDashboardController : Controller
    {
        public IActionResult HomeDashboard()
        {
            return View();
        }
    }
}
