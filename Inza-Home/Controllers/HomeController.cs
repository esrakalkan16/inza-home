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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {


            return View(CollectionRepository.Collections);
        }
        public IActionResult Collections()
        {



            return View(CollectionRepository.Collections);
        }
        public IActionResult CollectionDetail(int id)
        {
   
            var collection = CollectionRepository.Collections.FirstOrDefault(c => c.Id == id);
            if (collection == null)
            {
                return NotFound();
            }
            return View(collection);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Catalog()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ChangeLanguages(string LANG,string returnUrl)
        {
            SessionHelper.SetSessionValue("LANG", LANG);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            // yoksa anasayfa
            return RedirectToAction("Index", "Home");
        }
        public static class CollectionRepository
        {
        public static List<CollectionModel> Collections = new()
         {
        new CollectionModel
        {
            Id = 1,
            Name = "Asya",
            Description = HelperFunctions.Translate("Asya Koleksiyonu, do�u k�lt�r�n�n estetik inceliklerini modern ya�am alanlar�na ta��r. Sade formlar� ve zarif dokular� ile evinize huzur ve sofistike bir atmosfer katar."),
            CoverImage = "/Images/Koleksiyonlar-2/Asya/Asya.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Asya/Asya.jpg",
                "/Images/Koleksiyonlar-2/Asya/2.jpg",
                "/Images/Koleksiyonlar-2/Asya/3.jpg",
                "/Images/Koleksiyonlar-2/Asya/4.jpg",
                "/Images/Koleksiyonlar-2/Asya/5.jpg",
                "/Images/Koleksiyonlar-2/Asya/6.jpg",
                "/Images/Koleksiyonlar-2/Asya/7.jpg",
                "/Images/Koleksiyonlar-2/Asya/8.jpg"
            }
        },
        new CollectionModel
        {
            Id = 2,
            Name = "Beren",
            Description = HelperFunctions.Translate("Beren Koleksiyonu, modern ya�am�n enerjisini ve konforunu bir araya getirir. Minimal �izgileri ve i�levsel tasar�m�yla evinizin her k��esine sofistike bir dokunu� ekler."),
            CoverImage = "/Images/Koleksiyonlar-2/Beren/Beren.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Beren/Beren.jpg",
                "/Images/Koleksiyonlar-2/Beren/2.jpg",
                "/Images/Koleksiyonlar-2/Beren/3.jpg",
                "/Images/Koleksiyonlar-2/Beren/4.jpg",
                "/Images/Koleksiyonlar-2/Beren/5.jpg",
                "/Images/Koleksiyonlar-2/Beren/6.jpg",
                "/Images/Koleksiyonlar-2/Beren/7.jpg",
                "/Images/Koleksiyonlar-2/Beren/8.jpg",
                "/Images/Koleksiyonlar-2/Beren/9.jpg",
                "/Images/Koleksiyonlar-2/Beren/10.jpg",
                "/Images/Koleksiyonlar-2/Beren/11.jpg",
                "/Images/Koleksiyonlar-2/Beren/12.jpg",
                "/Images/Koleksiyonlar-2/Beren/13.jpg",
                "/Images/Koleksiyonlar-2/Beren/14.jpg"
            }
        },
        new CollectionModel
        {
            Id = 3,
            Name = "Cemre",
            Description = HelperFunctions.Translate("Cemre Koleksiyonu, yal�n �izgileriyle ��kl��� �n plana ��kar�r. Ferah tasar�m�yla ya�am alanlar�n�za modern ve dengeli bir g�r�n�m kazand�r�r."),
            CoverImage = "/Images/Koleksiyonlar-2/Cemre/Cemre.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Cemre/Cemre.jpg",
                "/Images/Koleksiyonlar-2/Cemre/2.jpg",
                "/Images/Koleksiyonlar-2/Cemre/3.jpg",
                "/Images/Koleksiyonlar-2/Cemre/4.jpg",
                "/Images/Koleksiyonlar-2/Cemre/5.jpg",
                "/Images/Koleksiyonlar-2/Cemre/6.jpg",
                "/Images/Koleksiyonlar-2/Cemre/7.jpg",
                "/Images/Koleksiyonlar-2/Cemre/8.jpg",
                "/Images/Koleksiyonlar-2/Cemre/9.jpg",
                "/Images/Koleksiyonlar-2/Cemre/10.jpg",
                "/Images/Koleksiyonlar-2/Cemre/11.jpg",
                "/Images/Koleksiyonlar-2/Cemre/12.jpg",
                "/Images/Koleksiyonlar-2/Cemre/13.jpg"
            }
        },
        new CollectionModel
        {
            Id = 4,
            Name = "Cemre2",
            Description = HelperFunctions.Translate("Cemre2 Koleksiyonu, �zg�n detaylar�yla klasik ve modern tasar�m� birle�tirir. Rahatl��� �n planda tutan yap�s�yla estetik ve i�levselli�i ayn� anda sunar."),
            CoverImage = "/Images/Koleksiyonlar-2/Cemre2/Cemre2.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Cemre2/Cemre2.jpg",
                "/Images/Koleksiyonlar-2/Cemre2/2.jpg",
                "/Images/Koleksiyonlar-2/Cemre2/3.jpg",
                "/Images/Koleksiyonlar-2/Cemre2/4.jpg",
                "/Images/Koleksiyonlar-2/Cemre2/5.jpg",
                "/Images/Koleksiyonlar-2/Cemre2/6.jpg",
                "/Images/Koleksiyonlar-2/Cemre2/7.jpg",
                "/Images/Koleksiyonlar-2/Cemre2/8.jpg"
            }
        },
        new CollectionModel
        {
            Id = 5,
            Name = "Ceren",
            Description = HelperFunctions.Translate("Ceren Koleksiyonu, s�cak tonlar� ve zarif hatlar�yla ya�am alanlar�n�za do�al bir ��kl�k getirir. Yumu�ak dokular�yla evinizde samimi ve huzurlu bir ortam olu�turur."),
            CoverImage = "/Images/Koleksiyonlar-2/Ceren/Ceren.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Ceren/Ceren.jpg",
                "/Images/Koleksiyonlar-2/Ceren/2.jpg",
                "/Images/Koleksiyonlar-2/Ceren/3.jpg",
                "/Images/Koleksiyonlar-2/Ceren/4.jpg",
                "/Images/Koleksiyonlar-2/Ceren/5.jpg",
                "/Images/Koleksiyonlar-2/Ceren/6.jpg",
                "/Images/Koleksiyonlar-2/Ceren/7.jpg",
                "/Images/Koleksiyonlar-2/Ceren/8.jpg",
                "/Images/Koleksiyonlar-2/Ceren/9.jpg",
                "/Images/Koleksiyonlar-2/Ceren/10.jpg"
            }
        },
        new CollectionModel
        {
            Id = 6,
            Name = "Defne",
            Description = HelperFunctions.Translate("Defne Koleksiyonu, do�all��� ve zarafeti bir arada sunar. �nce detaylar� ve modern tasar�m�yla evinizin ruhuna taze bir dokunu� katar."),
            CoverImage = "/Images/Koleksiyonlar-2/Defne/Defne.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Defne/Defne.jpg",
                "/Images/Koleksiyonlar-2/Defne/2.jpg",
                "/Images/Koleksiyonlar-2/Defne/3.jpg",
                "/Images/Koleksiyonlar-2/Defne/4.jpg",
                "/Images/Koleksiyonlar-2/Defne/5.jpg",
                "/Images/Koleksiyonlar-2/Defne/6.jpg",
                "/Images/Koleksiyonlar-2/Defne/7.jpg",
                "/Images/Koleksiyonlar-2/Defne/8.jpg",
                "/Images/Koleksiyonlar-2/Defne/9.jpg",
                "/Images/Koleksiyonlar-2/Defne/10.jpg"
            }
        },
        new CollectionModel
        {
            Id = 7,
            Name = "Elif",
            Description = HelperFunctions.Translate("Elif Koleksiyonu, yal�n esteti�i ve fonksiyonel tasar�m�yla modern ya�am alanlar�na uyum sa�lar. Rahat dokusu ve zamans�z formuyla her ortama de�er katar."),
            CoverImage = "/Images/Koleksiyonlar-2/Elif/Elif.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Elif/Elif.jpg",
                "/Images/Koleksiyonlar-2/Elif/2.jpg",
                "/Images/Koleksiyonlar-2/Elif/3.jpg",
                "/Images/Koleksiyonlar-2/Elif/4.jpg",
                "/Images/Koleksiyonlar-2/Elif/5.jpg",
                "/Images/Koleksiyonlar-2/Elif/6.jpg"
            }
        },
        new CollectionModel
        {
            Id = 8,
            Name = "Gonca",
            Description = HelperFunctions.Translate("Gonca Koleksiyonu, zarif ve yumu�ak hatlar�yla ya�am alanlar�n�za s�cakl�k katar. Do�al tonlar� ve ��k detaylar�yla modern evlere uyum sa�lar, zamans�z tasar�m�yla her d�neme e�lik eder."),
            CoverImage = "/Images/Koleksiyonlar-2/Gonca/Gonca.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Gonca/Gonca.jpg",
                "/Images/Koleksiyonlar-2/Gonca/2.jpg",
                "/Images/Koleksiyonlar-2/Gonca/3.jpg",
                "/Images/Koleksiyonlar-2/Gonca/4.jpg",
                "/Images/Koleksiyonlar-2/Gonca/5.jpg",
                "/Images/Koleksiyonlar-2/Gonca/6.jpg",
                "/Images/Koleksiyonlar-2/Gonca/7.jpg",
                "/Images/Koleksiyonlar-2/Gonca/8.jpg",
                "/Images/Koleksiyonlar-2/Gonca/9.jpg"
            }
        },
        new CollectionModel
        {
            Id = 9,
            Name = "Madrid",
            Description = HelperFunctions.Translate("Madrid Koleksiyonu, Avrupa esintilerini modern yorumlarla birle�tirir. ��k ve estetik detaylar�yla evinizde sofistike bir atmosfer olu�turur."),
            CoverImage = "/Images/Koleksiyonlar-2/Madrid/Madrid.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Madrid/Madrid.jpg",
                "/Images/Koleksiyonlar-2/Madrid/2.jpg",
                "/Images/Koleksiyonlar-2/Madrid/3.jpg",
                "/Images/Koleksiyonlar-2/Madrid/4.jpg",
                "/Images/Koleksiyonlar-2/Madrid/5.jpg",
                "/Images/Koleksiyonlar-2/Madrid/6.jpg",
                "/Images/Koleksiyonlar-2/Madrid/7.jpg",
                "/Images/Koleksiyonlar-2/Madrid/8.jpg",
                "/Images/Koleksiyonlar-2/Madrid/9.jpg"
            }
        },
        new CollectionModel
        {
            Id = 10,
            Name = "Polo",
            Description = HelperFunctions.Translate("Polo Koleksiyonu, g��l� �izgileri ve modern tarz�yla dikkat �eker. Konforlu oturma d�zenleri ve dengeli formu ile ��kl�k ve i�levselli�i bir arada sunar."),
            CoverImage = "/Images/Koleksiyonlar-2/Polo/Polo.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Polo/Polo.jpg",
                "/Images/Koleksiyonlar-2/Polo/2.jpg",
                "/Images/Koleksiyonlar-2/Polo/3.jpg",
                "/Images/Koleksiyonlar-2/Polo/4.jpg",
                "/Images/Koleksiyonlar-2/Polo/5.jpg",
                "/Images/Koleksiyonlar-2/Polo/6.jpg",
                "/Images/Koleksiyonlar-2/Polo/7.jpg",
                "/Images/Koleksiyonlar-2/Polo/8.jpg",
                "/Images/Koleksiyonlar-2/Polo/9.jpg",
                "/Images/Koleksiyonlar-2/Polo/10.jpg",
                "/Images/Koleksiyonlar-2/Polo/11.jpg"
            }
        },
        new CollectionModel
        {
            Id = 11,
            Name = "Sude",
            Description = HelperFunctions.Translate("Sude Koleksiyonu, do�all���n huzurunu sade tasar�mlarla bulu�turur. Ferah oturma d�zenleri ve yumu�ak dokular�yla g�nl�k ya�am�n�za s�cak bir atmosfer kazand�r�r."),
            CoverImage = "/Images/Koleksiyonlar-2/Sude/Sude.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Sude/Sude.jpg",
                "/Images/Koleksiyonlar-2/Sude/2.jpg",
                "/Images/Koleksiyonlar-2/Sude/3.jpg",
                "/Images/Koleksiyonlar-2/Sude/4.jpg",
                "/Images/Koleksiyonlar-2/Sude/5.jpg",
                "/Images/Koleksiyonlar-2/Sude/6.jpg",
                "/Images/Koleksiyonlar-2/Sude/7.jpg",
                "/Images/Koleksiyonlar-2/Sude/8.jpg",
                "/Images/Koleksiyonlar-2/Sude/9.jpg",
                "/Images/Koleksiyonlar-2/Sude/10.jpg",
                "/Images/Koleksiyonlar-2/Sude/11.jpg",
                "/Images/Koleksiyonlar-2/Sude/12.jpg",
                "/Images/Koleksiyonlar-2/Sude/13.jpg",
                "/Images/Koleksiyonlar-2/Sude/14.jpg"
            }
        },
        new CollectionModel
        {
            Id = 12,
            Name = "Venedik",
            Description = HelperFunctions.Translate("Venedik Koleksiyonu, klasik Avrupa zarafetini modern ya�am alanlar�na ta��r. �hti�aml� detaylar� ve sofistike havas�yla evinizde prestijli bir ambiyans yarat�r."),
            CoverImage = "/Images/Koleksiyonlar-2/Venedik/Venedik.jpg",
            Images = new List<string>
            {
                "/Images/Koleksiyonlar-2/Venedik/Venedik.jpg",
                "/Images/Koleksiyonlar-2/Venedik/2.jpg",
                "/Images/Koleksiyonlar-2/Venedik/3.jpg",
                "/Images/Koleksiyonlar-2/Venedik/4.jpg",
                "/Images/Koleksiyonlar-2/Venedik/5.jpg",
                "/Images/Koleksiyonlar-2/Venedik/6.jpg",
                "/Images/Koleksiyonlar-2/Venedik/7.jpg",
                "/Images/Koleksiyonlar-2/Venedik/8.jpg",
                "/Images/Koleksiyonlar-2/Venedik/9.jpg",
                "/Images/Koleksiyonlar-2/Venedik/10.jpg",
                "/Images/Koleksiyonlar-2/Venedik/11.jpg"
            }
        }
    };
        }
        public class CollectionModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string CoverImage { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public List<string> Images { get; set; } = new List<string>();
        }
    }

}