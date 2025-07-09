using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
    {
        Sistema s = Sistema.Instancia();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new ClienteOcasional());
        }

        [HttpPost]
        public IActionResult Create(ClienteOcasional ocasional)
        {   
            ViewBag.Exito = false;
            if (!s.VerificarClienteExistencia(ocasional.Documento, ocasional.Email))
            { 

            try
            {
               
                s.AltaCliente(ocasional);
                ViewBag.Msg = "Cliente Ocasional creado correctamente";
                ViewBag.Exito = true;

                }
            catch (Exception e)
            {
                ViewBag.Msg = e.Message;
                ViewBag.Exito = false;
               
            }

            }
            else
            {
                ViewBag.Msg = "El cliente ya existe verfique documento y email";
                ViewBag.Exito = false;
            }
            return View(ocasional);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            bool bandera = false;
            Usuario pLogueada = s.Login(email, pass);
            if (pLogueada != null && pLogueada is Cliente c && c.Eliminar == false || pLogueada is Administrador)
            {
                
                //encontrè la persona lo redirijo al index home
                //setear variable de session con el dato del usuario logueado
                HttpContext.Session.SetInt32("idLogueado", pLogueada.Id);
                HttpContext.Session.SetString("tipoUsuario", pLogueada.GetTipoUsuario());
                if (pLogueada is Cliente cliente)
                {
                    HttpContext.Session.SetString("rolLogueado", cliente.GetRol());
                    return RedirectToAction("Index", "Perfil");
                }
                else if(pLogueada is Administrador)
                {
                    return RedirectToAction("Index", "Administrador");
                }       
            }
            

            ViewBag.Msg = "Login incorrecto";
            return View();
        }

        public IActionResult Logout()
        {
            //remueve todas las variables de session del usuario
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
            //Remueve unicamente la variable de session idLogueado
            //HttpContext.Session.Remove("idLogueado");

        }


    }

}
