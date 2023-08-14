using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CinemaService(AppDbContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddNewCinemaAsync(CinemaVM data)
        {
            string stringFileName = UploadFile(data);

            var newCinema = new Cinema()
            {
                Name = data.Name,
                Description = data.Description,
                Logo = stringFileName
            };

            await _context.Cinemas.AddAsync(newCinema);
            await _context.SaveChangesAsync();
        }

        public async Task<Cinema> GetCinemaByIdAsync(int id)
        {
            var cinemaDetails = await _context.Cinemas.FirstOrDefaultAsync(c => c.Id == id);

            return cinemaDetails;
        }

        public async Task UpdateCinemaAsync(CinemaVM data)
        {
            var dbCinema = await _context.Cinemas.FirstOrDefaultAsync(n => n.Id == data.Id);

            string stringFileName = UploadFile(data);
            if (dbCinema != null)
            {
                dbCinema.Logo = stringFileName;
                dbCinema.Name = data.Name;
                dbCinema.Description = data.Description;

                await _context.SaveChangesAsync();
            }

        }

        public string UploadFile(CinemaVM data)
        {
            string fileName = null;
            if (data.Logo != null)
            {
                string uploadDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + data.Logo.FileName;
                string filePath = Path.Combine(uploadDirectory, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    data.Logo.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}
