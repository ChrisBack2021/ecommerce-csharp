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
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index(int pg = 1)
        {
            var allProducers = await _service.GetAllAsync();
            List<Producer> producers = allProducers.ToList();

            const int pageSize = 6;
            if (pg < 1)
                pg = 1;

            int movieCount = producers.Count();

            var pager = new Pager(movieCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = producers.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProducerVM producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddNewProducerAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        //GET: producers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetProducerByIdAsync(id);
            if (producerDetails == null) return View("NotFound");





            return View(producerDetails);
        }

        //GET: producers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetProducerByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            var response = new ProducerVM()
            {
                Id = producerDetails.Id,
                FullName = producerDetails.FullName,
                Biography = producerDetails.Biography
            };

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,ProducerVM producer)
        {
            if (id != producer.Id)
            {
                return View("NotFound");
            }


            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.UpdateProducerAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //GET: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete") ]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        
    }

}
