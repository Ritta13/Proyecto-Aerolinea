using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PasajeController : Controller
    {
        Sistema s = Sistema.Instancia();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerPasajeCliente()
        {
            
            string rol = HttpContext.Session.GetString("tipoUsuario");
            int? id= HttpContext.Session.GetInt32("idLogueado");

            // Validación: si no está logueado o no es cliente, lo redirigimos al login
            if (string.IsNullOrEmpty(rol) || rol != "Cliente" || id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Pasaje> pasajes = s.ObtenerClientePasaje(id.Value);
            return View(pasajes);
        }
    }
}
