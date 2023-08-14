using eTickets.Models;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class ActorVM
    {
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public IFormFile ProfilePicture { get; set; }


        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biographygraphy")]
        [Required(ErrorMessage = "Biography is required")]
        public string Biography{ get; set; }

        //relationships
        public List<Actor_Movie>? Actors_Movies { get; set; }
    }
}
