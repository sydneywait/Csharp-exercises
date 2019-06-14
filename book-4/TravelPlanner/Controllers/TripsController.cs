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

        public async Task<IActionResult> Index(string searchString)
        {
            var user = await GetCurrentUserAsync();

            //var applicationDbContext = _context.ClientTrip.Include(ct => ct.client)
            //    .Include(ct => ct.trip)
            //    .ThenInclude(t => t.TripLocations)
            //    .ThenInclude(tl=>tl.location)
            //    .Where(ct => ct.client.AgentId == user.Id)
            //    .Where(ct => ct.isArchived == false)
            //    .OrderBy(ct => ct.trip.StartDate)
            //    .Where(ct => ct.trip.EndDate > DateTime.Now);

            var applicationDbContext = _context.Trips.Include(t => t.ClientTrips)
                .ThenInclude(ct => ct.client)
                .Include(t => t.TripLocations)
                .ThenInclude(tl => tl.location)
                .Where(t => t.isArchived == false)
                .OrderBy(t => t.StartDate)
                .Where(t => t.EndDate > DateTime.Now);


            if (searchString != null)
            {
                //Check to see if any of the locations in any of the trips match the search string.
                applicationDbContext = applicationDbContext.Where(t=>t.TripLocations.Any(tl=>tl.location.Name.Contains(searchString))); 
                    

            }
        
    

            return View(await applicationDbContext.ToListAsync());
        }
        //// GET: PastTrips
        //[Authorize]

        //public async Task<IActionResult> PastTrips()
        //{
        //    var user = await GetCurrentUserAsync();

        //    var applicationDbContext = _context.Trips.Include(t => t.Client).Where(c => c.Client.AgentId == user.Id).OrderBy(t => t.StartDate).Where(t => t.EndDate < DateTime.Now);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        //// GET: Trips/Details/5
        //[Authorize]

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    //allows you to check if client belongs to this current user
        //    var user = await GetCurrentUserAsync();


        //    var trip = await _context.Trips
        //        .Include(t => t.Client)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (trip == null || trip.Client.AgentId != user.Id)
        //    {
        //        return NotFound();
        //    }

        //    return View(trip);
        //}

        // GET: Trips/Create
        [Authorize]

        public async Task<IActionResult> Create()
        {
            var currentUser = await GetCurrentUserAsync();

            TripViewModel tripModel = new TripViewModel();
            SelectList Clients = new SelectList(_context.Clients.Where(c => c.AgentId == currentUser.Id && c.isArchived == false), "Id", "FullName");

            SelectList Locations = new SelectList(_context.Locations, "Id", "Name");

            tripModel.Clients = Clients;
            tripModel.Locations = Locations;


            return View(tripModel);
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> Create(TripViewModel tripModel)
        {
            var currentUser = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {

                _context.Add(tripModel.trip);
                await _context.SaveChangesAsync();


                foreach (int locationId in tripModel.selectedLocations)
                {
                    TripLocation tripLocation = new TripLocation()
                    {
                        TripId = tripModel.trip.Id, //Need inserted id
                        LocationId = locationId
                    };
                    _context.Add(tripLocation);
                }

                foreach (int clientId in tripModel.selectedClients)
                {
                    ClientTrip clientTrip = new ClientTrip()
                    {
                        TripId = tripModel.trip.Id, //Need inserted id
                        ClientId = clientId
                    };
                    _context.Add(clientTrip);
                }


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            SelectList Clients = new SelectList(_context.Clients.Where(c => c.AgentId == currentUser.Id && c.isArchived == false), "Id", "FullName");
            SelectList Locations = new SelectList(_context.Locations, "Id", "Name");
            tripModel.Clients = Clients;
            tripModel.Locations = Locations;

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

            var trip = _context.Trips
                .Include(t=>t.ClientTrips)
                .Include(t=>t.TripLocations)
                .FirstOrDefault(t=>t.Id == id);
                


            if (trip == null)
            {
                return NotFound();
            }
            SelectList Clients = new SelectList(_context.Clients.Where(c => c.AgentId == currentUser.Id && c.isArchived == false), "Id", "FullName");
            SelectList Locations = new SelectList(_context.Locations, "Id", "Name");
            tripModel.Clients = Clients;
            tripModel.Locations = Locations;
            tripModel.trip = trip;

            foreach(TripLocation tl in trip.TripLocations)
            {
                tripModel.selectedLocations.Add(tl.LocationId);

            }

            foreach (ClientTrip ct in trip.ClientTrips)
            {
                tripModel.selectedClients.Add(ct.ClientId);

            }

            return View(tripModel);
        }

        //// POST: Trips/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]

        //public async Task<IActionResult> Edit(int id, TripViewModel tripModel)
        //{
        //    var currentUser = await GetCurrentUserAsync();

        //    if (id != tripModel.trip.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tripModel.trip);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TripExists(tripModel.trip.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    SelectList Clients = new SelectList(_context.Clients.Where(c => c.AgentId == currentUser.Id && c.isArchived == false), "Id", "FullName");
        //    tripModel.Clients = Clients;
        //    return View(tripModel);
        //}

        //// GET: Trips/Delete/5
        //[Authorize]

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var trip = await _context.Trips
        //        .Include(t => t.Client)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (trip == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(trip);
        //}

        //// POST: Trips/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize]

        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var trip = await _context.Trips.FindAsync(id);

        //    //Archive trip 
        //    trip.isArchived = true;
        //    _context.Trips.Update(trip);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TripExists(int id)
        //{
        //    return _context.Trips.Any(e => e.Id == id);
        //}

        ////GET: Trips/Report 
        //[Authorize]

        //public async Task<IActionResult> Report()
        //{

        //    TripReportViewModel reportModel = new TripReportViewModel();
        //    var user = await GetCurrentUserAsync();

        //    var tripReport = await _context.Trips
        //        .Where(t => t.Client.AgentId == user.Id)
        //        .GroupBy(t => t.StartDate.ToString("MMMM"))
        //        .Select(g => new TripReport()
        //        {
        //            month = g.Key,
        //            TripCount = g.Count()
        //        }).ToListAsync();


        //    var clientReport = await _context.Trips.Include(t => t.Client)
        //        .Where(t => t.Client.AgentId == user.Id)
        //        .GroupBy(t =>
        //       new
        //       {
        //           t.Client.FirstName,
        //           t.Client.LastName,

        //       })
        //        .Select(g => new ClientReport()
        //        {
        //            client = new Client()
        //            {
        //                FirstName = g.Key.FirstName,
        //                LastName = g.Key.LastName
        //            },
        //            TripCount = g.Count()
        //        })
        //        .ToListAsync();



        //    var busyClients = clientReport.OrderByDescending(g => g.TripCount).Take(5).ToList();
        //    var busyMonths = tripReport.OrderByDescending(g => g.TripCount).Take(3).ToList();

        //    reportModel.BusyMonths = busyMonths;
        //    reportModel.BusyClients = busyClients;


        //    return View(reportModel);
        //}
    }
}
