using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IProducersService : IEntityBaseRepository<Producer>
    {
        Task<Producer> GetProducerByIdAsync(int id);

        Task AddNewProducerAsync(ProducerVM data);

        Task UpdateProducerAsync(ProducerVM data);

        string UploadFile(ProducerVM data);
    }
}
