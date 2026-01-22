using Microsoft.AspNetCore.Mvc;

namespace KidsBirthdayPlanner.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
