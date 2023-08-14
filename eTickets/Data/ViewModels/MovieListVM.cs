using eTickets.Models;

namespace eTickets.Data.ViewModels
{
    public class MovieListVM
    {

        public IQueryable<Movie> MovieList { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}

