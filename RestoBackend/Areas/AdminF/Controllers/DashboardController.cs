using Microsoft.AspNetCore.Mvc;

namespace RestoBackend.Areas.AdminF.Controllers
{
    [Area("AdminF")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
