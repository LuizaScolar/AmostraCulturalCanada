using AmostraCulturalCanada.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AmostraCulturalCanada.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Historia()
        {
            return View();
        }

        public IActionResult Cultura()
        {
            return View();
        }

        public IActionResult Folclore()
        {
            return View();
        }

        public IActionResult Quiz()
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
    }
}
