using eTickets.Data.Base;
using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Movie Description")]
        [MinLength(100, ErrorMessage = "The description must be atleast 100 characters long")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price in $")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Movie Poster URL is required")]
        [Display(Name = "Movie Poster URL")]
        public IFormFile ImageURL { get; set; }

        [Required(ErrorMessage = "Movie start date is required")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Movie end date is required")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Movie Category is required")]
        [Display(Name = "Select movie category")]
        public MovieCategory MovieCategory { get; set; }



        // Relationships
        [Required(ErrorMessage = "Movie actor(s) is required")]
        [Display(Name = "Select actor(s)")]
        public List<int> ActorIds { get; set; }
        [Required(ErrorMessage = "Movie cinema is required")]
        [Display(Name = "Select a cinema")]
        public int CinemaId { get; set; }
        [Required(ErrorMessage = "Movie producer is required")]
        [Display(Name = "Select a producer")]
        public int ProducerId { get; set; }


    }
}
