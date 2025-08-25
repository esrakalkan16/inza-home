using System.Diagnostics;
using Inza_Home.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inza_Home.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Collections()
        {

            var collections = new List<CollectionModel>
            {
                new CollectionModel { Id = 1, Name = "Beren Koleksiyonu", CoverImage = "/Images/Koleksiyonlar/Beren/Beren.png"  },
                new CollectionModel { Id = 2, Name = "Gonca Koleksiyonu", CoverImage = "/Images/Koleksiyonlar/Gonca/Gonca.png" },
                 new CollectionModel { Id = 3, Name = "Beren Koleksiyonu", CoverImage = "/Images/Koleksiyonlar/Beren/Beren.png"  },
                new CollectionModel { Id = 4, Name = "Gonca Koleksiyonu", CoverImage = "/Images/Koleksiyonlar/Gonca/Gonca.png" }

            };

            return View(collections);
        }

        public IActionResult AboutUs()
        {
            return View();
        }



        public IActionResult CollectionDetail(int id)
        {
            var collection = new CollectionModel();

            if (id == 1 || id == 3)
            {
                collection = new CollectionModel
                {
                    Id = 1,
                    Name = "Beren Koleksiyonu",
                    Description = "Beren Koleksiyonu modern tasarýmýyla dikkat çekiyor...",
                    CoverImage = "/Images/Koleksiyonlar/Beren/Beren.png",
                    Images = new List<string>
            {
                "/Images/Koleksiyonlar/Beren/Beren.png",
                "/Images/Koleksiyonlar/Beren/2.png",
                "/Images/Koleksiyonlar/Beren/3.png",
                "/Images/Koleksiyonlar/Beren/4.png",
                "/Images/Koleksiyonlar/Beren/5.png",
                "/Images/Koleksiyonlar/Beren/6.png",
                "/Images/Koleksiyonlar/Beren/7.png",
                "/Images/Koleksiyonlar/Beren/8.png",
                "/Images/Koleksiyonlar/Beren/9.png",
                "/Images/Koleksiyonlar/Beren/10.png"
            }
                };
            }
            else if (id == 2 || id == 4)
            {
                collection = new CollectionModel
                {
                    Id = 2,
                    Name = "Gonca Koleksiyonu",
                    Description = "Gonca Koleksiyonu þýklýðýyla yaþam alanýnýza deðer katar...",
                    CoverImage = "/Images/Koleksiyonlar/Gonca/Gonca.png",
                    Images = new List<string>
            {
                "/Images/Koleksiyonlar/Gonca/Gonca.png",
                "/Images/Koleksiyonlar/Gonca/2.png",
                "/Images/Koleksiyonlar/Gonca/3.png",
                "/Images/Koleksiyonlar/Gonca/4.png",
                "/Images/Koleksiyonlar/Gonca/5.png",
                "/Images/Koleksiyonlar/Gonca/6.png",
                "/Images/Koleksiyonlar/Gonca/7.png",
                "/Images/Koleksiyonlar/Gonca/8.png",
                "/Images/Koleksiyonlar/Gonca/9_highres.png",
                "/Images/Koleksiyonlar/Gonca/10.png"
            }
                };
            }

            return View(collection);
        }

        public class CollectionModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string CoverImage { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public List<string> Images { get; set; } = new List<string>();
        }

        public IActionResult ChangeLanguages(string LANG)
        {
            SessionHelper.SetSessionValue("LANG", LANG);    
            return RedirectToAction("Index", "Home");
        }
    }

}