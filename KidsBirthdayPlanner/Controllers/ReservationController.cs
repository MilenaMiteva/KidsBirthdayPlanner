using KidsBirthdayPlanner.Data;
using KidsBirthdayPlanner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KidsBirthdayPlanner.Models;
using System.Security.Claims;

namespace KidsBirthdayPlanner.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly KidsBirthdayPlannerContext context;

        public ReservationController(KidsBirthdayPlannerContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(int birthdayPartyId)
        {
            var party = await context.BirthdayParties
                .Include(p => p.Theme)
                .FirstOrDefaultAsync(p => p.Id == birthdayPartyId);

            if (party == null)
            {
                return NotFound();
            }

            var model = new ReservationViewModel
            {
                BirthdayPartyId = party.Id,
                PartyName = party.Theme.Name
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var party = await context.BirthdayParties
                    .Include(p => p.Theme)
                    .FirstOrDefaultAsync(p => p.Id == model.BirthdayPartyId);

                if (party != null)
                {
                    model.PartyName = party.Theme.Name;
                }

                return View(model);
            }

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var reservation = new Reservation
            {
                BirthdayPartyId = model.BirthdayPartyId,
                UserId = userId,
                ChildrenCount = model.ChildrenCount,
                Notes = model.Notes
            };

            await context.Reservations.AddAsync(reservation);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "BirthdayParty");
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}