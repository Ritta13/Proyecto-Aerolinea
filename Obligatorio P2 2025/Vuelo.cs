using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Dominio
{
    public class Vuelo : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string NumeroVuelo { get; set; }
        public Avion Avion { get; set; }
        public DateTime FrecuenciaDias { get; set; }
        public Ruta Ruta { get; set; }


        public Vuelo()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Vuelo(string numeroVuelo, Avion avion, DateTime frecuenciaDias, Ruta ruta)
        {
            Id = UltimoId;
            UltimoId++;
            NumeroVuelo = numeroVuelo;
            Avion = avion;
            FrecuenciaDias = frecuenciaDias;
            Ruta = ruta;

        }

        //**************** METODOS PAR VLAIDAR *************

        public void Validar()
        {
            ValidarAlcanceRuta();
            ValidarCodigoVuelo();
            ValidarFrecuenciaDias();

        }
        private void ValidarCodigoVuelo()
        {
            if (string.IsNullOrEmpty(NumeroVuelo))
            {
                throw new Exception("El Codigo de vuelo no puede estar vacío");
            }

            string patron = @"^[A-Za-z]{2}[0-9]{1,4}$";

            if (!Regex.IsMatch(NumeroVuelo, patron))
            {
                throw new Exception("El Codigo de vuelo es inválido. Debe tener 2 letras seguidas de 1 a 4 números");
            }

        }
        public void ValidarFrecuenciaDias()
        {
            if (FrecuenciaDias == null)
            {
                throw new Exception("La frecuencia de días no puede ser nula");
            }
        }

        private void ValidarAlcanceRuta()
        {
            if (Ruta == null)
            {
                throw new Exception("La ruta no puede ser nula");
            }
            if (Avion == null)
            {
                throw new Exception("El avión no puede ser nulo");
            }
            if (Avion.AlcanceKm < Ruta.Distancia)
            {
                throw new Exception("El avión no tiene alcance suficiente para cubrir la ruta");
            }
        }

        //************ METODO PARA CALCULAR EL PRECIO POR ASIENTO ************

        public double CalcularCostoPorAsiento()
        {
            double costoRuta = Ruta.CalcularCostoAeropuerto();
            double costoAvion = Avion.CostoOperacionKm * Ruta.Distancia;
            double costototal = costoRuta + costoAvion;
            double costoPorAsiento = costototal / Avion.CantAsientos;
            return costoPorAsiento;
        }

        public double CostoTazaVuelo()
        {
            return Ruta.AeropuertoSalida.CostoTazas + Ruta.AeropuertoLlegada.CostoTazas;
        }

        public override string ToString()
        {
            return $"Vuelo: {NumeroVuelo} - Avion: {Avion.Modelo} - Ruta: {Ruta} - Frecuencia: {FrecuenciaDias.ToString("yyyy-MM-dd")}";
        }
    }

}
