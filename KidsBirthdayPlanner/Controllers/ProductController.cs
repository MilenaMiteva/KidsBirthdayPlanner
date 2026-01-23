using Microsoft.AspNetCore.Mvc;

namespace KidsBirthdayPlanner.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "All Products";
            return View();
        }
        public IActionResult Details(int id)
        {
            if(id <= 0)
            {
                return Content("Invalid product id.");
            }
            ViewBag.ProductId = id;
            return View();
        }

    }
}
