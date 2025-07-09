using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dominio
{
    public class Ruta : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Aeropuerto AeropuertoSalida { get; set; }
        public Aeropuerto AeropuertoLlegada { get; set; }
        public double Distancia { get; set; }

        public Ruta()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Ruta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada, double distancia)
        {
            Id = UltimoId;
            UltimoId++;
            AeropuertoSalida =aeropuertoSalida;
            AeropuertoLlegada =aeropuertoLlegada;
            Distancia = distancia;  
        }

        // *************************  METODO DE VALIDAR ****************************
        public void Validar()
        {
            ValidarDistancia();
        }

        private void ValidarDistancia()
        {
            if (Distancia <= 0)
            {
                throw new Exception("La distancia no puede ser menor o igual a 0");
            }
        }

        // ****************** CALCULAR COSTO AEROPUERTO *******************
        public double CalcularCostoAeropuerto()
        {
            
           return AeropuertoSalida.CostoOperaciones + AeropuertoLlegada.CostoOperaciones;
            
        }

        public override string ToString()
        {
            return $" Aeropuerto Salida: {AeropuertoSalida.CodigoIata} -  Aeropuerto Llegada: {AeropuertoLlegada.CodigoIata}";
        }
    }
}