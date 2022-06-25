using RestoBackend.Models;
using System.Collections;
using System.Collections.Generic;

namespace RestoBackend.ViewModels
{
    public class HomeVM
    {

        public  Bio bios { get; set; }
        public About abouts { get; set; }
        public Slider sliders { get; set; }
        public IEnumerable <SpecialRecipe>specialRecipes { get; set; }
        public IEnumerable <Team>teams { get; set; }
        public IEnumerable<Menu>menus { get; set; }
    }
}
