using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.Instancia();
        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
