using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClienteOcasional : Cliente, IValidable
    {
        public bool ElegibleRegalo { get; set; }

        public ClienteOcasional()
        { 
        }

        public ClienteOcasional(int documento, string nombre, string nacionalidad, string email, string password, bool elegibleRegalo,bool eliminar) : base(documento, nombre, nacionalidad, email, password, eliminar) 
        {
            ElegibleRegalo = elegibleRegalo;
        }

        //*************** METODO CALCULAR COSOTO EQUIPAJE ******************
        public override double CalcularEquipaje(Equipaje equipaje)
        {
            double costo = 0;
            if(equipaje == Equipaje.Cabina)
            {
                costo = costo * 0.10;
            }
            else if (equipaje == Equipaje.Bodega)
            {
                costo = costo * 0.20;
            }
            return costo;
        }


        //********************** METODO DE VALIDAR **********************
        public override string ToString()
        {
            return "Cliente Ocasional - " + base.ToString() + " Elegible Regalo: " + ElegibleRegalo;
        }

        // ***************** METODO ABSTRACTO PARA OBTENER EL ROL DEL CLIENTE ****************
        public override string GetRol()
        {
            return "CO";
        }

    }
}
