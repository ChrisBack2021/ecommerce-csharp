using eTickets.Models;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class CinemaVM
    {
        public int Id { get; set; }
        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema Logo is required.")]
        public IFormFile Logo { get; set; }
        [Required(ErrorMessage = "Cinema name is required.")]
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        [Display(Name = "Cinema description")]
        [Required]
        public string Description { get; set; }

        // Relationships
        public List<Movie>? Movies { get; set; }
    }
}
