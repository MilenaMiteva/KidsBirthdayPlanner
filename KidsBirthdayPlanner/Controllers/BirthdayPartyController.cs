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
        public async Task<IActionResult> Index()
        {
            var parties = await service.GetAllAsync();
            return View(parties);
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
        
        public async Task<IActionResult> Create()
        {
            var model = await service.GetCreateModelAsync();
            return View(model);
        }

        [HttpPost]
        
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
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
