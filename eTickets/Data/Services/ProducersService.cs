using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProducersService(AppDbContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddNewProducerAsync(ProducerVM data)
        {
            string stringFilename = UploadFile(data);

            var newProducer = new Producer()
            {
                FullName = data.FullName,
                Biography = data.Biography,
                ProfilePicture = stringFilename
            };

            await _context.AddAsync(newProducer);
            await _context.SaveChangesAsync();
        }

        public async Task<Producer> GetProducerByIdAsync(int id)
        {
            var producerDetails = await _context.Producers.FirstOrDefaultAsync(x => x.Id == id);

            return producerDetails;
        }

        public async Task UpdateProducerAsync(ProducerVM data)
        {
            var dbProducer = await _context.Producers.FirstOrDefaultAsync(x => x.Id == data.Id);
            string stringFileName = UploadFile(data);

            if (dbProducer != null)
            {
                dbProducer.Biography = data.Biography;
                dbProducer.ProfilePicture = stringFileName;
                dbProducer.FullName = data.FullName;
                await _context.SaveChangesAsync();
            }
        }

        public string UploadFile(ProducerVM data)
        {
            string fileName = null;
            if (data.ProfilePicture != null)
            {
                string uploadDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + data.ProfilePicture.FileName;
                string filePath = Path.Combine(uploadDirectory, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    data.ProfilePicture.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}
