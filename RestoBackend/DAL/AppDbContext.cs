using Microsoft.EntityFrameworkCore;
using RestoBackend.Models;

namespace RestoBackend.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Bio>Bios { get; set; }
        public DbSet<About>Abouts { get; set; }
        public DbSet<Slider>Sliders { get; set; }
        public DbSet<SpecialRecipe>SpecialRecipes { get; set; }
        public DbSet<Team>Teams { get; set; }
        public DbSet<Menu>Menus { get; set; }
    }
}
