using KidsBirthdayPlanner.Data;
using KidsBirthdayPlanner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Details()
        {
            return View();
        }
    }
}