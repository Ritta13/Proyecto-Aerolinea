using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace WebApp.Controllers
{
    public class PerfilController : Controller
    {
        Sistema s = Sistema.Instancia();
        public IActionResult index()
        {
            int? idUsuarioLogueado = HttpContext.Session.GetInt32("idLogueado");
            string tipoUsuario = HttpContext.Session.GetString("tipoUsuario");
            string rol = HttpContext.Session.GetString("rolLogueado");

            Usuario u = s.GetUsuario(idUsuarioLogueado);

            if (u == null)
            {
                ViewBag.Msg = "No se ha encontrado el usuario logueado. Por favor, inicie sesión nuevamente.";
                return RedirectToAction("Index", "Home");
            }

            if (u is Cliente c)
            {
                ViewBag.Nombre = c.Nombre;
                ViewBag.Documento = c.Documento;
                ViewBag.TipoUsuario = tipoUsuario;
                ViewBag.Rol = rol;
                ViewBag.EsOcasional = false;

                if (c is ClientePremium cp)
                {
                    ViewBag.EsPremium = true;
                    ViewBag.Puntos = cp.GetPuntos(); // o cp.Puntos si lo hacés público
                }
                else if (c is ClienteOcasional co)
                {
                    ViewBag.EsOcasional = true;
                    ViewBag.ElegibleRegalo = co.ElegibleRegalo;
                }

                else
                {
                    ViewBag.EsPremium = false;
                }
                
                

                ViewBag.TipoUsuario = tipoUsuario;
                ViewBag.Rol = rol;

                return View();
            }
            return View();
        }
    }
}
