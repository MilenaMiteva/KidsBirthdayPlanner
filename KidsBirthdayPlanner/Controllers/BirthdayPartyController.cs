using KidsBirthdayPlanner.Models;
using KidsBirthdayPlanner.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;



namespace KidsBirthdayPlanner.Controllers
{
    public class BirthdayPartyController : Controller
    {
        private readonly KidsBirthdayPlannerContext context;

        public BirthdayPartyController(KidsBirthdayPlannerContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var parties = await context.BirthdayParties
                .Include(p => p.Theme)
                .Include(p => p.Balloon)
                .Select(p => new BirthdayPartyViewModel
                {
                    Id = p.Id,
                    ThemeId = p.ThemeId,
                    CakeId = p.CakeId,
                    BalloonId = p.BalloonId,
                    Date = p.Date,
                    GuestsCount = p.GuestsCount
                })
                .ToListAsync();

            return View(parties);
        }

        public async Task<IActionResult> Details(int id)
        {
            var party = await context.BirthdayParties
                .Where(p => p.Id == id)
                .Select(p => new BirthdayPartyViewModel
                {
                    Id = p.Id,
                    ThemeId = p.ThemeId,
                    CakeId = p.CakeId,
                    BalloonId = p.BalloonId,
                    Date = p.Date,
                    GuestsCount = p.GuestsCount
                })
                .FirstOrDefaultAsync();

            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> Create()
        {
            var model = new BirthdayPartyViewModel
            {
                 Cakes = await context.Cakes
                .OrderBy(c => c.Type)
                .ThenBy(c => c.Flavor)
                .Select(c => new SelectListItem
                {
                 Value = c.Id.ToString(),
                 Text = c.Type + " - " + c.Flavor
                })
                .ToListAsync(),


                Balloons = await context.Balloons
                    .OrderBy(b => b.Type)
                    .ThenBy(b => b.Color)
                    .Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Type + " - " + b.Color

                    }).ToListAsync(),
                    Themes = await context.Themes
                    .OrderBy(t => t.Name)
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.Name
                    }).ToListAsync()
            };


            return View(model);
        }



        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(BirthdayPartyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var party = new BirthdayParty
            {
                ThemeId = model.ThemeId,
                CakeId = model.CakeId,
                BalloonId = model.BalloonId,
                BalloonQuantity = model.BalloonQuantity,
                Date = model.Date,
                GuestsCount = model.GuestsCount
            };

            await context.BirthdayParties.AddAsync(party);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var party = await context.BirthdayParties.FindAsync(id);

            if (party == null)
                return NotFound();

            var model = new BirthdayPartyViewModel
            {
                Id = party.Id,
                ThemeId = party.ThemeId,
                CakeId = party.CakeId,
                BalloonId = party.BalloonId,
                Date = party.Date,
                GuestsCount = party.GuestsCount
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BirthdayPartyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var party = await context.BirthdayParties.FindAsync(model.Id);

            if (party == null)
                return NotFound();

            party.ThemeId = model.ThemeId;
            party.CakeId = model.CakeId;
            party.BalloonId = model.BalloonId;
            party.Date = model.Date;
            party.GuestsCount = model.GuestsCount;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var party = await context.BirthdayParties.FindAsync(id);

            if (party == null)
            {
                return NotFound();
            }

            var model = new BirthdayPartyViewModel
            {
                Id = party.Id,
                ThemeId = party.ThemeId,
                CakeId = party.CakeId,
                BalloonId = party.BalloonId,
                Date = party.Date,
                GuestsCount = party.GuestsCount

            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var party = await context.BirthdayParties.FindAsync(id);

            if (party == null)
            {
                return NotFound();
            }

            context.BirthdayParties.Remove(party);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
