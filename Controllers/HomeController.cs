using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;
using System.Net.Http;
using System.Collections.Generic;

namespace Warehouse.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        ProductContext db;
        ProductRepository productRepository;
        UserRepository userRepository;
        HttpClient client;
        List<ExchangeRates> exchangeRates;

        public HomeController(ProductContext context)
        {
            client = new HttpClient();
            userRepository = new UserRepository();
            productRepository = new ProductRepository();
            db = context;
        }

        private async void GaveRates()
        {
            GetRates getRates = new GetRates();
            if (exchangeRates == null)
            {
                exchangeRates = await getRates.GetRatesAsync("https://www.nbrb.by/api/exrates/rates?periodicity=0", client);
            }
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            GaveRates();
            var table = productRepository.GetProduct(db);      
            return View(table);
        }

        [Route("")]
        [HttpPost]
        public IActionResult Index(int[] check)
        {
            foreach (var checkItem in check)
            {
                productRepository.DeleteProduct(db, productRepository.GetProductById(db, checkItem));
            }
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

        [Route("AddNewProduct")]
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View();
        }

        [Route("AddNewProduct")]
        [HttpPost]
        public IActionResult AddNewProduct(string name, int number)
        {
            Product product = new Product() { Name = name, NumberProduct = number};
            productRepository.SaveProduct(db, product);
            return RedirectToAction("Index");
           // return View();
        }
    }
}