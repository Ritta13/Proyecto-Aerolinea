using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Aeropuerto : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string CodigoIata { get; set; }
        public string Ciudad { get; set; }
        public double CostoOperaciones { get; set; }
        public double CostoTazas { get; set; }

        public Aeropuerto()
        {
            Id = UltimoId;
            UltimoId++;

        }
        public Aeropuerto(string codigoIata, string ciudad, double costoOperaciones, double costoTazas)
        {
            Id = UltimoId;
            UltimoId++;
            CodigoIata = codigoIata;
            Ciudad = ciudad;
            CostoOperaciones = costoOperaciones;
            CostoTazas = costoTazas;
        }

        // ********************** METODOS DE VALIDAR *********************
        public void Validar()
        {
            ValidarCodigoIata();
            ValidarCiudad();
            ValidarCostoOperaciones();
            ValidarCostoTaza();    
        }

        
        private void ValidarCodigoIata()
        {
            if (string.IsNullOrEmpty(CodigoIata))
            {
                throw new Exception("El Codigo no puede ser vacio");
            }
            if (CodigoIata.Length != 3)
            {
                throw new Exception("El Codigo debe contener 3 letras");
            }
            foreach (char c in CodigoIata)
            {
                if (!char.IsLetter(c))
                {
                    throw new Exception("El Codigo debe contener solo letras");
                }
            }
        }

        private void ValidarCiudad()
        {
            if (string.IsNullOrEmpty(Ciudad))
            {
                throw new Exception("La Ciudad no puede ser vacia");
            }
        }

        // ***************** METODOS DE EQUALS SUBCRITO ***********************

        public override bool Equals(object obj)
        {
            return obj is Aeropuerto aeropuerto &&
                   CodigoIata == aeropuerto.CodigoIata;
        }

        private void ValidarCostoTaza()
        {
            if (CostoTazas < 0)
            {
                throw new Exception("El Costo de Taza no puede ser menor a 0");
            }
        }

        private void ValidarCostoOperaciones()
        {
            if (CostoOperaciones < 0)
            {
                throw new Exception("El Costo de Operaciones no puede ser menor a 0");
            }
        }
    }
}
