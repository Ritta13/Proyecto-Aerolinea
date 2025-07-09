using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Cliente : Usuario, IValidable
    {
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

        public bool Eliminar { get; set; }


        public Cliente()
        {
        
        }

        public Cliente(int documento, string nombre, string nacionalidad, string email, string password, bool eliminar) : base(email, password)
        {
            Documento = documento;
            Nombre = nombre;
            Nacionalidad = nacionalidad;
            Eliminar = eliminar;
        }

        //********************** METODOS DE VALIDAR **********************
        public void Validar()
        {
            ValidarDocumento();
            ValidarNombre();
            ValidarNacionalidad();
            base.Validar();


        }
        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El Nombre no puede ser vacio");
            }
        }

        private void ValidarDocumento()
        {
            if (Documento == 0)
            {
                throw new Exception("El Documento no puede ser vacio");
            }
        }
        private void ValidarNacionalidad()
        {
            if (string.IsNullOrEmpty(Nacionalidad))
            {
                throw new Exception("La Nacionalidad no puede ser vacia");
            }


        }

        // *************** METODO ABSTRACTO QUE SE HEREDA A LAS CLASES HIJAS ***************

        public abstract double CalcularEquipaje(Equipaje equipaje);

        public override string ToString()
        {
            return base.ToString() + $" Nombre: {Nombre}, Nacionalidad: {Nacionalidad} -  ";


        }

        // ***************** METODO DE EQUALS SUBSCRITO *******************
        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                 Id == cliente.Id &&
                 Documento == cliente.Documento &&
                 Email == cliente.Email;
        }

        // ***************** METODO PARA OBTENER EL ROL DEL USUARIO ****************
        public override string GetTipoUsuario()
        {
            return "Cliente";
        }

        // ***************** METODO ABSTRACTO PARA OBTENER EL ROL DEL CLIENTE ****************
        public abstract string GetRol();


        // ***************** METODO ABSTRACTO PARA OBTENER LOS PUNTOS DEL CLIENTE ****************
        public virtual int GetPuntos() => 0;

    }
}
