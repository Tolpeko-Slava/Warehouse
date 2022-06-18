using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db;
        ProductRepository productRepository;

        public HomeController(ProductContext context)
        {
            productRepository = new ProductRepository();
            db = context;
        }
        public IActionResult Index()
        {
            var table = productRepository.GetProduct(db);      
            return View(table);
        }
    }
}