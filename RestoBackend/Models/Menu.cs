using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestoBackend.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public  string Image { get; set; }
        [Required]
        [NotMapped]
        
        public IFormFile Photo { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Maxsimum 50 olmalidi")]
        public string SubTitle { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
