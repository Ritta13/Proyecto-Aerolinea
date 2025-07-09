using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pasaje : IValidable, IComparable<Pasaje>
    {

        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Vuelo Vuelo { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public Equipaje Equipaje { get; set; }
        public double Precio { get; set; }

        public Pasaje()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Pasaje(Vuelo vuelo, DateTime fecha, Cliente cliente, Equipaje equipaje, double precio)
        {
            Id = UltimoId;
            UltimoId++;
            Vuelo = vuelo;
            Fecha = fecha;
            Cliente = cliente;
            Equipaje = equipaje;
            Precio = precio;
        }


        // ************* METODO DE VALIDAR *************
        public void Validar()
        {
            ValidarPrecio();
            ValidarFechaVuelo();
            ValidarFrecuenciaVuelo();


        }



        public void ValidarFrecuenciaVuelo()
        {
            if (Vuelo == null)
            {
                throw new Exception("El vuelo no puede ser nulo.");
            }

            if (Fecha.DayOfWeek != Vuelo.FrecuenciaDias.DayOfWeek)
            {
                throw new Exception($"La fecha seleccionada ({Fecha:dddd}) no coincide con la frecuencia del vuelo ({Vuelo.FrecuenciaDias:dddd}).");
            }
        }


        public void ValidarFechaVuelo()
        {
            if (Fecha < DateTime.Now)
            {
                throw new Exception("La fecha del vuelo no puede ser menor a la fecha actual");
            }
        }

        private void ValidarPrecio()
        {
            if (Precio < 0)
            {
                throw new Exception("El precio no puede ser negativo");
            }
        }


        //******************** METODO CALCULAR PRECIO DE PASAJE ******************

        public void CalcularPrecio()
        {
            double costoAsiento = Vuelo.CalcularCostoPorAsiento();
            double costoConMargen = costoAsiento * 1.25;
            double porcentajeEquipaje = Cliente.CalcularEquipaje(Equipaje);
            double costoEquipaje = costoAsiento * porcentajeEquipaje;
            double costoTaza = Vuelo.CostoTazaVuelo();
            Precio = costoConMargen + costoEquipaje + costoTaza;
           

        }

        public override string ToString()
        {
            return $"Pasaje : {Id}, Pasajero : {Cliente.Nombre}, Precio : {Precio}, Fecha : {Fecha.ToString("yyyy-MM-dd")}, Vuelo : {Vuelo.NumeroVuelo}";
        }


        // ***************** METODO DE CompareTo  *******************
        public int CompareTo(Pasaje p)
        {
            return p.Precio.CompareTo(this.Precio);
        }
    }
}
