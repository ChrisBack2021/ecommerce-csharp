using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;
        public CinemasController(ICinemaService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int pg = 1)
        {
            var allCinemas = await _service.GetAllAsync();

            List<Cinema> cinemas = allCinemas.ToList();

            const int pageSize = 6;
            if (pg < 1)
                pg = 1;

            int movieCount = cinemas.Count();

            var pager = new Pager(movieCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = cinemas.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaVM cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddNewCinemaAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        //Get Cinema/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null)
                return View("NotFound");  
            return View(cinemaDetails);
        }

        //Edit Cinema/Details/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetCinemaByIdAsync(id);
            if (cinemaDetails == null)
                return View("NotFound");

            var response = new CinemaVM()
            {
                Id = cinemaDetails.Id,
                Name = cinemaDetails.Name,
                Description = cinemaDetails.Description,
            };

            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CinemaVM cinema)
        {
            if (id != cinema.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
                return View(cinema);
            await _service.UpdateCinemaAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
