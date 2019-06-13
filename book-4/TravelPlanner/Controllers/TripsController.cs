using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelPlanner.Data;
using TravelPlanner.Models;
using TravelPlanner.Models.ViewModels;

namespace TravelPlanner.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TripsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
       {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Trips
        [Authorize]

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.Trips.Include(t => t.Client).Where(c => c.Client.AgentId == user.Id).OrderBy(t=>t.StartDate).Where(t=>t.EndDate > DateTime.Now);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: PastTrips
        [Authorize]

        public async Task<IActionResult> PastTrips()
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.Trips.Include(t => t.Client).Where(c => c.Client.AgentId == user.Id).OrderBy(t => t.StartDate).Where(t => t.EndDate < DateTime.Now);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trips/Details/5
        [Authorize]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //allows you to check if client belongs to this current user
            var user = await GetCurrentUserAsync();


            var trip = await _context.Trips
                .Include(t => t.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null || trip.Client.AgentId != user.Id)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        [Authorize]

        public async Task<IActionResult> Create()
        {
            var currentUser = await GetCurrentUserAsync();

            TripViewModel tripModel = new TripViewModel();
            SelectList Clients = new SelectList(_context.Clients.Where(c => c.AgentId == currentUser.Id), "Id",  "FullName");
            tripModel.Clients = Clients;

            return View(tripModel);
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> Create( TripViewModel tripModel)
        {
            var currentUser = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                
                _context.Add(tripModel.trip);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            SelectList Clients = new SelectList(_context.Clients.Where(c => c.AgentId == currentUser.Id), "Id", "FullName");
            tripModel.Clients = Clients;
            return View(tripModel);
        }

        // GET: Trips/Edit/5
        [Authorize]

        public async Task<IActionResult> Edit(int? id, TripViewModel tripModel)
        {
            var currentUser = await GetCurrentUserAsync();

            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            SelectList Clients = new SelectList(_context.Clients.Where(c => c.AgentId == currentUser.Id), "Id", "FirstName");
            tripModel.Clients = Clients;
            return View(tripModel);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> Edit(int id, TripViewModel tripModel)
        {  var currentUser = await GetCurrentUserAsync();

            if (id != tripModel.trip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripModel.trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(tripModel.trip.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            SelectList Clients = new SelectList(_context.Clients.Where(c=>c.AgentId ==currentUser.Id), "Id", "FirstName");
            tripModel.Clients = Clients;
            return View(tripModel);
        }

        // GET: Trips/Delete/5
        [Authorize]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.Id == id);
        }
    }
}
