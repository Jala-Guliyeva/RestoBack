using Microsoft.AspNetCore.Mvc;
using RestoBackend.DAL;
using RestoBackend.ViewModels;
using System.Linq;

namespace RestoBackend.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVm = new HomeVM();
            homeVm.abouts = _context.Abouts.FirstOrDefault();
            homeVm.bios = _context.Bios.FirstOrDefault();
            homeVm.sliders = _context.Sliders.FirstOrDefault();
            homeVm.specialRecipes = _context.SpecialRecipes.ToList();
            homeVm.teams = _context.Teams.ToList();
            homeVm.menus = _context.Menus.ToList();
            return View(homeVm);
        }
    }
}
