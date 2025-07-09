using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{

    public class VueloController : Controller
	{
		Sistema s = Sistema.Instancia();
		public IActionResult Index()
		{
            string rol = HttpContext.Session.GetString("tipoUsuario");
            int? id = HttpContext.Session.GetInt32("idLogueado");

            // Validación: si no está logueado o no es cliente, lo redirigimos al login
            if (string.IsNullOrEmpty(rol) || rol != "Cliente" || id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            IEnumerable<Vuelo> vuelos = s.ListarVuelos();
			return View(vuelos);
		}

		public IActionResult Comprar(int id)
		{
            string rol = HttpContext.Session.GetString("tipoUsuario");
            int? idLogueado = HttpContext.Session.GetInt32("idLogueado");

            // Validación: si no está logueado o no es cliente, lo redirigimos al login
            if (string.IsNullOrEmpty(rol) || rol != "Cliente" || idLogueado == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Vuelo pBuscado = s.GetVuelo(id);
			return View(pBuscado);
		}

		[HttpPost]
        public IActionResult Comprar(int vueloId, DateTime fecha, Equipaje equipaje)
		{
			Vuelo v = s.GetVuelo(vueloId);
			ViewBag.Exito = false;
			if (HttpContext.Session.GetString("tipoUsuario") == "Cliente")
			{
				int id = HttpContext.Session.GetInt32("idLogueado").Value;
				Cliente cliente = s.ObtenerClienteId(id);
                Pasaje nuevoPasaje = new Pasaje()
                {
                    Vuelo = v,
                    Fecha = fecha,
                    Cliente = cliente,
                    Equipaje = equipaje,


                };
                try
				{
					s.AltaPasaje(nuevoPasaje);
                    ViewBag.Msg = "Pasaje comprado con éxito.";
                    ViewBag.Exito = true;	
                    return RedirectToAction("VerPasajeCliente", "Pasaje");
				}
				catch (Exception ex)
				{
					ViewBag.Msg = ex.Message;
					ViewBag.Exito = false;
                    return View(v); // o View(nuevoPasaje) si querés mantener el form con datos
				}
			}
            return RedirectToAction("Index","Home");
        }

		public IActionResult BuscarRuta()
		{
            string rol = HttpContext.Session.GetString("tipoUsuario");
            int? id = HttpContext.Session.GetInt32("idLogueado");

            // Validación: si no está logueado o no es cliente, lo redirigimos al login
            if (string.IsNullOrEmpty(rol) || rol != "Cliente" || id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new List<Vuelo>()); 
		}

		[HttpPost]
        public IActionResult BuscarRuta(string salida, string llegada)
        {
			ViewBag.Exito = false;
            if (string.IsNullOrWhiteSpace(salida) || string.IsNullOrWhiteSpace(llegada))
            {
                ViewBag.Msg = "Por favor, ingrese ambos codigos IATA de los aeropuertos.";
				ViewBag.Exito = false;
                return View();
            }

            List<Vuelo> vuelos = s.ObtenerVuelosPorRuta(salida, llegada);

            if (vuelos.Count == 0)
            {
                ViewBag.Msg = "No se encontraron vuelos para la ruta seleccionada.";
				ViewBag.Exito = false;
                return View();
            }
            return View(vuelos);
        }

    }
}
