using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cinema Logo")]
        [Required]
        public string Logo { get; set; }
        [Display(Name = "Cinema Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Cinema description")]
        [Required]
        public string Description { get; set; }

        // Relationships
        public List<Movie>? Movies { get; set; }
    }
}
