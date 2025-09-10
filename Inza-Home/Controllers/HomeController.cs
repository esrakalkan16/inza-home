using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
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
            var collections = DataManager.GetCollections();
            return View(collections);
        }
        public IActionResult Collections()
        {
            var collections = DataManager.GetCollections();
            return View(collections);
        }
        public IActionResult CollectionDetail(int id)
        {
   
            var collection = DataManager.GetCollections().FirstOrDefault(c => c.Id == id);
            if (collection == null)
                return NotFound();

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

        [HttpPost]
        public async Task<IActionResult> ContactForm([FromForm] ContactFormDto dto)
        {
            if (!ModelState.IsValid)
                return Json(new { ok = false, message = "Form hatalý dolduruldu." });

            try
            {

                using (MailMessage mailMessage = new MailMessage())
                {
                    string Mail = "info@inzahome.com";

                    mailMessage.From = new MailAddress(Mail, "Inza Home Web");
                    mailMessage.Subject = "Inza Home Müþteri Ýletiþim Formu";
                    mailMessage.Body = $@"Ad: {dto.FullName}
                          Tel: {dto.Phone}
                          Mail: {dto.Email}
                          Mesaj: {dto.Message}";
                    mailMessage.IsBodyHtml = false;

                    // Alýcý = sizin kendi info adresiniz olabilir, dto.Email müþteriye gitmesin
                    mailMessage.To.Add("info@inzahome.com");

                    using (SmtpClient smtp = new SmtpClient("mail.kurumsaleposta.com", 587))
                    {
                        smtp.EnableSsl = false;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(Mail, "RaDus246RaDus");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(mailMessage);
                    }
                }
                Console.WriteLine("Mail baþarýyla gönderildi!");

                return Json(new { ok = true, message = "Teþekkürler! Mesajýnýz alýndý." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Genel Hata: {ex.Message}");
                return Json(new { ok = false, message = "Mail gönderilemedi: " + ex.Message });
            }
        }
        public class ContactFormDto
        {
            [Required, StringLength(120)]
            public string FullName { get; set; }
            [Required, StringLength(40)]
            public string Phone { get; set; }
            [Required, EmailAddress, StringLength(120)]
            public string Email { get; set; }
            [Required, StringLength(4000)]
            public string Message { get; set; }
        }

    }

}