using eTickets.Models;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class ProducerVM
    {

        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public IFormFile ProfilePicture { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name = "Biographygraphy")]
        [Required(ErrorMessage = "Biographygraphy is required")]
        public string Biography { get; set; }

        //Relationships
        public List<Movie>? Movies { get; set; }
    }
}

