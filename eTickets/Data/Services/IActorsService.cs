using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        Task<Actor> GetActorByIdAsync(int id);
        Task AddNewActorAsync(ActorVM data);

        Task UpdateActorAsync(ActorVM data);

        string UploadFile(ActorVM data);

    }
}
