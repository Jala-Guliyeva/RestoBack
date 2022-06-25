using Microsoft.AspNetCore.Mvc;
using RestoBackend.DAL;
using RestoBackend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RestoBackend.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private AppDbContext _context;

        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Bio bio =  _context.Bios.FirstOrDefault();
            return View(await Task.FromResult(bio));
        }
    }
}
