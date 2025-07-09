using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdministradorController : Controller
    {
        Sistema s = Sistema.Instancia();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult VerPasaje()
        {
            string rol = HttpContext.Session.GetString("tipoUsuario");
            int? id = HttpContext.Session.GetInt32("idLogueado");

            // Validación: si no está logueado o no es cliente, lo redirigimos al login
            if (string.IsNullOrEmpty(rol) || rol != "Administrador" || id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Pasaje> pasajes = s.ObtenerPasajes();
            OrdenarFecha orden = new OrdenarFecha("Fecha");
            pasajes.Sort(orden);
            return View(pasajes);
        }


        public IActionResult VerClientes()
        {
            string rol = HttpContext.Session.GetString("tipoUsuario");
            int? id = HttpContext.Session.GetInt32("idLogueado");

            // Validación: si no está logueado o no es cliente, lo redirigimos al login
            if (string.IsNullOrEmpty(rol) || rol != "Administrador" || id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cliente> clientes = s.ObtenerClientesUsuario();
            return View(clientes);
        }

        [HttpPost]
        public IActionResult VerClientes(int documento, int puntos, bool elegible)
        {
            Cliente cliente = s.ObtenerClientePorDocumento(documento);

            if (cliente is ClientePremium premium)
            {
                premium.Puntos = puntos;
            }
            else if (cliente is ClienteOcasional ocasional)
            {
                ocasional.ElegibleRegalo = elegible;
            }

            return RedirectToAction("VerClientes");
        }


        public IActionResult Edit()
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Edit(int id, string nombre)
        {
            Cliente c = s.ObtenerIdPremium(id);
            if (c != null)
            {
                
                s.EditarCliente(c, nombre); 
                ViewBag.Message = "Cliente editado correctamente.";
                return RedirectToAction("VerClientes");
            }
            else
            {
                ViewBag.Error = "Cliente no encontrado.";
                return View();
            }
        }
        public IActionResult Delate(int id)
        {
            Cliente c = s.ObtenerClienteId(id);
            if (c != null)
            {
                s.Delate(c);
                ViewBag.Message = "Cliente Eliminado correctamente.";
                return RedirectToAction("VerClientes");
                
            }
            else
            {
                ViewBag.Error = "Cliente no encontrado.";
                return View();
            }
        }
    }
}
