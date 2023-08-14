using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface ICinemaService : IEntityBaseRepository<Cinema>
    {
        Task<Cinema> GetCinemaByIdAsync(int id);
        Task AddNewCinemaAsync(CinemaVM data);

        Task UpdateCinemaAsync(CinemaVM data);

        string UploadFile(CinemaVM data);
    }
}
