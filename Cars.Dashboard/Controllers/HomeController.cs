using Cars.Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cars.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Asus zen book",
                Price = 1000,
                Date = DateTime.UtcNow.AddHours(5)
            },
            new Product
            {
                Id = 2,
                Name = "Asus TUF gaming",
                Price = 1200,
                Date = DateTime.UtcNow.AddHours(5)
            }
        };

        public HomeController(ILogger<HomeController> logger)
            => _logger = logger;

        public IActionResult Index()
            => View(products);

        public IActionResult Contact()
            => View();
    }
}
