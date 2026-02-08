namespace KidsBirthdayPlanner.Controllers
{
    using KidsBirthdayPlanner.Data;
    using KidsBirthdayPlanner.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

        public class EventController : Controller
        {
            private readonly ApplicationDbContext dbContext;

            public EventController(ApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IActionResult> Index()
            {
                var events = await dbContext.Events
                    .Include(e => e.PackageParty)
                    .ToListAsync();

                return View(events);
            }


           [HttpGet]
           public async Task<IActionResult> Create()
           {
            ViewBag.Packages = await dbContext.PackageParties
                .Select(p => new
                {
                    p.Id,
                    p.Name
                })
                .ToListAsync();

            return View();
           }  


            public async Task<IActionResult> Details(int id)
            {
                var eventEntity = await dbContext.Events
                    .Include(e => e.Guests)
                    .Include(e => e.PackageParty)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (eventEntity == null)
                {
                    return NotFound();
                }

                return View(eventEntity);
            }

            [HttpPost]
            public async Task<IActionResult> Delete(int id)
            {
                var eventEntity = await dbContext.Events.FindAsync(id);

                if (eventEntity == null)
                {
                    return NotFound();
                }

                dbContext.Events.Remove(eventEntity);
                await dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
    
}