using KidsBirthdayPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidsBirthdayPlanner.Controllers
{
    public class ProductController : Controller
    {
      

      public IActionResult Index()
      {
        var products = new List<ProductViewModel>
        {
          new ProductViewModel { Id = 1, Name = "Cake" },
          new ProductViewModel { Id = 2, Name = "Balloons" }
        };

        return View(products);   
      }

        public IActionResult Details(int id)
        {
            var products = new List<ProductViewModel>
            {
                new ProductViewModel { Id = 1, Name = "Cake" },
                new ProductViewModel { Id = 2, Name = "Balloons" }
            };
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

    }
}
