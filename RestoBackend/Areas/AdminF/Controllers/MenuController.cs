using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestoBackend.DAL;
using RestoBackend.Extention;
using RestoBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoBackend.Areas.AdminF.Controllers
{
    [Area("AdminF")]
    public class MenuController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;

        public MenuController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Menu> menu = _context.Menus.ToList();
            return View(menu);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Menu dbMenu = await _context.Menus.FindAsync(id);
            if (dbMenu == null) return NotFound();
            return View(dbMenu);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Menu dbMenu =await  _context.Menus.FindAsync(id);
            if (dbMenu == null) return NotFound();
            _context.Menus.Remove(dbMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
  
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Menu dbMenu = await _context.Menus.FindAsync(id);
            if (dbMenu == null) return NotFound();
            return View(dbMenu);
        }
        [HttpPost]
        public async Task<IActionResult>Update(int? id,Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Menu dbMenu = await _context.Menus.FindAsync(id);

         
            if (dbMenu == null) return NotFound();
            dbMenu.SubTitle = menu.SubTitle;
            dbMenu.Title = menu.Title;
            dbMenu.Price = menu.Price;
            dbMenu.Image = menu.Image;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //jsda yazsaqbunusilmeliyik,yoxsaislemiir
        public async Task<IActionResult> Create(Menu menu)
        {
            //validationstate-requiredolanlar
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();

            }

            if (!menu.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Accept only image!");

                return View();
            }
            if (menu.Photo.ImageSize(1000000))
            {
                ModelState.AddModelError("Photo", "1mq yuxari olabilmez!");

                return View();
            }


            string fileName = await menu.Photo.SaveImage(_env,"assets/img");
            Menu newMenu = new Menu();
            newMenu.Image = fileName;
            newMenu.SubTitle = menu.SubTitle;
            newMenu.Title = menu.Title;
            newMenu.Price = menu.Price;
            await _context.Menus.AddAsync(newMenu);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
