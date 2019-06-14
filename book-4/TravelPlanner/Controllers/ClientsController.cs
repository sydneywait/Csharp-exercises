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

namespace TravelPlanner.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ClientsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: Clients
        [Authorize]
        public async Task<IActionResult> Index(string searchString)
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Clients.Include(c => c.Agent)
                .Where(c => c.AgentId == user.Id).Where(c => c.isArchived == false);

            if (searchString != null)
            {
                applicationDbContext = applicationDbContext.Where(c => c.FirstName.Contains(searchString) || c.LastName.Contains(searchString));
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Clients/Details/5
        [Authorize]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //allows you to check if client belongs to this current user
            var user = await GetCurrentUserAsync();

            var client = await _context.Clients
                .Include(c => c.Agent)
                .Include(c => c.ClientTrips)
                .ThenInclude(ct=>ct.trip)
                .ThenInclude(t=>t.TripLocations)
                .ThenInclude(tl=>tl.location)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null || client.AgentId != user.Id)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        [Authorize]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber")] Client client)
        {
            var currentUser = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                client.AgentId = currentUser.Id;

                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        [Authorize]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Add the user id back to the post
                    var currentUser = await GetCurrentUserAsync();
                    client.AgentId = currentUser.Id;
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        [Authorize]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Agent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients
                     .Include(c => c.ClientTrips)
                     .FirstOrDefaultAsync(c => c.Id == id);

            //If a client does not have any trips, delete them
            if (client.ClientTrips.Count() == 0)
            {
                _context.Clients.Remove(client);

            }
            else
            {

                //If a client has trips, archive client rather than delete
                client.isArchived = true;

                //Also archive all of their trips
                foreach (ClientTrip ct in client.ClientTrips)
                {
                    ct.isArchived = true;
                }
                _context.Clients.Update(client);

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }

    }
}
