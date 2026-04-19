using KidsBirthdayPlanner.Services.Interfaces;
using KidsBirthdayPlanner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidsBirthdayPlanner.Controllers
{
    [Authorize]
    public class BirthdayPartyController : Controller
    {
        private readonly IBirthdayPartyService service;

        public BirthdayPartyController(IBirthdayPartyService service)
        {
            this.service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(string? searchTerm, int page = 1)
        {
            int pageSize = 3;

            var result = await service.GetAllAsync(searchTerm, page, pageSize);

            var model = new BirthdayPartyListViewModel
            {
                Parties = result.Parties,
                SearchTerm = searchTerm,
                CurrentPage = page,
                TotalPages = result.TotalPages
            };

            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = await service.GetByIdAsync(id);

            if (model == null)
            { 
                return NotFound(); 
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")] // Only Admins can create birthday parties

        public async Task<IActionResult> Create()
        {
            var model = await service.GetCreateModelAsync();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BirthdayPartyViewModel model)
        {
            if (!ModelState.IsValid)
            { 
                model = await service.GetCreateModelAsync();
                return View(model); 
            }

            await service.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")] // Only Admins can edit birthday parties


        public async Task<IActionResult> Edit(int id)
        {
            var model = await service.GetEditAsync(id);

            if (model == null)
            { 
                return NotFound();
            }

            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BirthdayPartyViewModel model)
        {
            if (!ModelState.IsValid)
            { 
                return View(model);
            }

            await service.EditAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")] // Only Admins can delete birthday parties


        public async Task<IActionResult> Delete(int id)
        {
            var model = await service.GetDeleteAsync(id);

            if (model == null)
            { 
                return NotFound(); 
            }

            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
