using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        ProductContext db;
        ProductRepository productRepository;
        UserRepository userRepository;

        public HomeController(ProductContext context)
        {
            userRepository = new UserRepository();
            productRepository = new ProductRepository();
            db = context;
        }

        [Route("")]
        public IActionResult Index()
        {
            var table = productRepository.GetProduct(db);      
            return View(table);
        }

        [Route("Authorization")]
        [HttpGet]
        public IActionResult Authorization()
        {
            ViewBag.Authorization = false;
            ViewBag.Authorization = false;
            return View();
        }

        [Route("Authorization")]
        [HttpPost]
        public IActionResult Authorization(string name,string password)
        {
            UserClass user = new UserClass() { Login = name, Password = password};
            if(userRepository.FindUserLogin(db, user))
            {
                ViewBag.Authorization = true;
                return View();
            }
            {
                ViewBag.Authorization = false;
                ViewBag.AuthorizationPost = true;
                return View();
            }
            // var user = userRepository.GetUsers(db);
        }
    }
}