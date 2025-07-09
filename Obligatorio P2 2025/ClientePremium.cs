using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClientePremium : Cliente, IValidable
    {
        public int Puntos { get; set; }


        public ClientePremium(int documento, string nombre, string nacionalidad, string email, string password, int puntos, bool eliminar) : base(documento, nombre, nacionalidad, email, password, eliminar)
        {
            Puntos = puntos;
            Validar();
        }


        public void Valiar()
        {
            ValidarPuntos();
        }

        // *********************** METODO CALCULAR COSTO  EQUIPAJE  ***********************
        public override double CalcularEquipaje(Equipaje equipaje)
        {
            double costo = 0;
            if (equipaje == Equipaje.Bodega)
            {
                costo = costo * 0.05;
            }
            return costo;
        }

        //*********************** METODO DE VALIDAR PUNTOS ***********************
        private void ValidarPuntos()
        {
            if (Puntos < 0)
            {
                throw new Exception("Los puntos no pueden ser negativos");
            }
        }

        // *********************** METODO DE TO STRING ***********************
        public override string ToString()
        {
            return "ClientePremium - " + base.ToString() + " Puntos: " + Puntos;
        }

        // ***************** METODO ABSTRACTO PARA OBTENER EL ROL DEL CLIENTE ****************
        public override string GetRol()
        {
            return "CP";

        }

        // ***************** METODO ABSTRACTO PARA OBTENER LOS PUNTOS DEL CLIENTE ****************
        public override int GetPuntos() => Puntos;
    }
}
