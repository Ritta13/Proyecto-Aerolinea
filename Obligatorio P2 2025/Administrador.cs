using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario, IValidable
    {
        public string Apodo { get; set; }


        public Administrador()
        {

        }

        public Administrador(string email, string password, string apodo) : base(email, password)
        {
            Apodo = apodo;
            
        }


        // ******************** METODO DE VALIDAR *****************
        public void Validar()
        {
            ValidarApodo();
        }

        private void ValidarApodo()
        {
            if (string.IsNullOrEmpty(Apodo))
            {
                throw new Exception("El Apodo no puede ser vacio");
            }
        }

        //*********************** METODO PARA USAR A FUTURO *************************
        public void ModificarPuntosClientePremium(ClientePremium premium, int nuevosPuntos)
        {
            premium.Puntos = nuevosPuntos;
        }

        //************************ METODO PARA USAR A FUTURO *****************************
        public void ModificarElegibleOcasional(ClienteOcasional ocasional, bool elegible)
        {
            ocasional.ElegibleRegalo = elegible;
        }

        // *********************** METODO PARA OBTENER ROL *****************************
        public override string GetTipoUsuario()
        {
            return "Administrador";
        }
    }



}
