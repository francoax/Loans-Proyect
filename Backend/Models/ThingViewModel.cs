using Backend.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ThingViewModel
    {
        public int Id { get; set; }
        public List<SelectListItem>? Categories { get; set; }

        [Display(Name = "Category")]
        public string? CategoryDescription{ get; set; }   

        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(20, ErrorMessage = "Solo puede tener 20 caracteres")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La categoria es requerida")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        
    }
}
