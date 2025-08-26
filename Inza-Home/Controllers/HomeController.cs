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
            var slides = new List<CollectionModel>
    {
        new CollectionModel { Id = 3, Name = "Gonca", Description = HelperFunctions.Translate("Zamansýz, yumuþak hatlar"), CoverImage = "Gonca.png" },
        new CollectionModel { Id = 1, Name = "Beren", Description = HelperFunctions.Translate("Modern ve konforlu"), CoverImage = "Beren.png" },
        new CollectionModel { Id = 2, Name = "Sude",  Description = HelperFunctions.Translate("Sade & sýcak dokular"), CoverImage = "Sude.png" },
        new CollectionModel { Id = 4, Name = "Cemre", Description = HelperFunctions.Translate("Minimal çizgiler"), CoverImage = "Cemre.png" }
    };

            return View(slides);
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

        public IActionResult Contact()
        {
            return View();
        }   

        public IActionResult Collections()
        {

            var collections = new List<CollectionModel>
            {
                new CollectionModel { Id = 1, Name = "Beren Koleksiyonu", CoverImage = "/Images/Koleksiyonlar/Beren/Beren.png"  },
                new CollectionModel { Id = 2, Name = "Sude Koleksiyonu", CoverImage = "/Images/Koleksiyonlar/Sude/Sude.png" },
                 new CollectionModel { Id = 3, Name = "Gonca Koleksiyonu", CoverImage = "/Images/Koleksiyonlar/Gonca/Gonca.png"  },
                new CollectionModel { Id = 4, Name = "Cemre Koleksiyonu", CoverImage = "/Images/Koleksiyonlar/Cemre/Cemre.png" }

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

            switch (id)
            {
                case 1:
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
                    break;

                case 2:
                    collection = new CollectionModel
                    {
                        Id = 2,
                        Name = "Sude Koleksiyonu",
                        Description = "Sade & sýcak dokular",
                        CoverImage = "/Images/Koleksiyonlar/Sude/Sude.png",
                        Images = new List<string>
                {
                    "/Images/Koleksiyonlar/Sude/Sude.png",
                    "/Images/Koleksiyonlar/Sude/2.png",
                    "/Images/Koleksiyonlar/Sude/3.png"
                }
                    };
                    break;

                case 3:
                    collection = new CollectionModel
                    {
                        Id = 3,
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
                    break;

                case 4:
                    collection = new CollectionModel
                    {
                        Id = 4,
                        Name = "Cemre Koleksiyonu",
                        Description = "Minimal çizgiler",
                        CoverImage = "/Images/Koleksiyonlar/Cemre/Cemre.png",
                        Images = new List<string>
                {
                    "/Images/Koleksiyonlar/Cemre/Cemre.png",
                    "/Images/Koleksiyonlar/Cemre/2.png",
                    "/Images/Koleksiyonlar/Cemre/3.png"
                }
                    };
                    break;
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