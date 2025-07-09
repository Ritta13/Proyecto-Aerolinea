using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract  class Usuario : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Email { get; set; }
        public string Password { get; set; }


        public Usuario()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Usuario(string email, string password) 
        {
            Id = UltimoId;
            UltimoId++;
            Email = email;
            Password = password;
            Validar();
        }

         // ******************** METODOS DE VALIDAR ************************
        public void Validar()
        {
            ValidarEmail();
            ValidarPassword();
        }

        private void ValidarEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("El Email no puede ser vacio");
            }
            else if (!Email.Contains("@"))
            {
                throw new Exception("El Email no es valido, debe contener @");
            }
        }
        private void ValidarPassword()
        {
            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("El Password no puede ser vacio");
            }
            if (Password.Length < 8)
            {
                throw new Exception("El Password debe tener al menos 8 caracteres");
            }
        }

        // ************** METODO DE EQUALS SUBSCRITO *******************
        public override bool Equals(object obj)
        {
            return obj is Usuario usuario &&
                   Email == usuario.Email &&
                   Password == usuario.Password;
        }


        // ***************** METODO DE HASHCODE SUBSCRITO ****************
        public virtual string ToString()
        {
            return $"Email: {Email} - ";
        }

        // ***************** METODO PARA OBTENER EL ROL DEL USUARIO ****************
        public abstract string GetTipoUsuario();
    }
}
