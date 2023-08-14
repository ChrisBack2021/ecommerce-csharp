using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ActorsService(AppDbContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddNewActorAsync(ActorVM data)
        {
            string stringFileName = UploadFile(data);

            var newActor = new Actor()
            {
                FullName = data.FullName,
                ProfilePicture = stringFileName,
                Biography = data.Biography,
            };

            await _context.Actors.AddAsync(newActor);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            var actorDetails = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);

            return actorDetails;
        }

        public async Task UpdateActorAsync(ActorVM data)
        {
            var dbActor = await _context.Actors.FirstOrDefaultAsync(n => n.Id == data.Id);

            string stringFileName = UploadFile(data);
            if (dbActor != null)
            {
                dbActor.FullName = data.FullName;
                dbActor.ProfilePicture = stringFileName;
                dbActor.Biography = data.Biography;

                await _context.SaveChangesAsync();
            }
        }

        public string UploadFile(ActorVM data)
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
