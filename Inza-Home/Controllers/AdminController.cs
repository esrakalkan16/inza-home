using Inza_Home.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inza_Home.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Sliders

        public IActionResult Sliders()
        {
            try
            {
                var model = DataManager.GetCollections();
                return View("Sliders", model);
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        #endregion

    }
}
