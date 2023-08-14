﻿using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

 
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorVM actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.AddNewActorAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetActorByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            var response = new ActorVM()
            {
                Id = actorDetails.Id,
                FullName = actorDetails.FullName,
                Biography = actorDetails.Biography
            };

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActorVM actor)
        {
            if (id != actor.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateActorAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
