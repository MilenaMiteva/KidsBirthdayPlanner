using System.Diagnostics;
using KidsBirthdayPlanner.Data;
using KidsBirthdayPlanner.Services.Interfaces;
using KidsBirthdayPlanner.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KidsBirthdayPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IBirthdayPartyService birthdayPartyService;

        public HomeController(ILogger<HomeController> logger, IBirthdayPartyService birthdayPartyService)
        {
            _logger = logger;
            this.birthdayPartyService = birthdayPartyService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<BirthdayPartyViewModel> latestParties = await birthdayPartyService.GetLatestAsync(3);

            return View(latestParties);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult NotFoundPage()
        {
            return View("NotFound");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
