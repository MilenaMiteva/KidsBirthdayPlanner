using Microsoft.AspNetCore.Mvc;

namespace KidsBirthdayPlanner.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}