using LittleFormApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net;

namespace LittleFormApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(ProductRepository.Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(new List<string>()
            {
				"Hoodie",
		        "Blouse",
		        "Boots",
                "Hat"
			});
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ProductRepository.AddProduct(product);
            return RedirectToAction("Index");
        } 

        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            return View(ProductRepository.Products.Where(item=>item.Id==id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ProductRepository.UpdateProduct(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Search(string search) 
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return View();
            }
            return View("Index",ProductRepository.Products.Where(item=>item.Name.Contains(search)));
        }
    }
}
