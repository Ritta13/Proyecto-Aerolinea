using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Avion : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Fabricante { get; set; }
        public string Modelo { get; set; }  
        public int CantAsientos { get; set; }
        public double AlcanceKm { get; set; }
        public double CostoOperacionKm { get; set; }


        public Avion() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Avion(string fabricante, string modelo, int cantAsientos, double alcanceKm, double costoOperacionKm)
        {
            Id = UltimoId;
            UltimoId++;
            Fabricante = fabricante;
            Modelo = modelo;
            CantAsientos = cantAsientos;
            AlcanceKm = alcanceKm;
            CostoOperacionKm = costoOperacionKm;
           
        }

        // ********************* METODO DE VALIDAR *******************
        public void Validar() 
        {
            ValidarFabricante();
            ValidarModelo();
            ValidarCantAsientos();
            ValidarAlcanze();   
            ValidarCostoOperacion();    

        }

        private void ValidarFabricante()
        {
            if(string.IsNullOrEmpty(Fabricante))
            {
                throw new Exception("El Fabricante no debe ser vacio");
            }
        }

        private void ValidarModelo()
        {
            if(string.IsNullOrEmpty(Modelo))
            {
                throw new Exception("El Modelo no puede ser vacio");
            }
        }

        private void ValidarCantAsientos()
        {
            if (CantAsientos == 0)
            {
                throw new Exception("La Cantidad de asientos no puede ser vacio");
            }
        }

        private void ValidarAlcanze()
        {
            if (AlcanceKm == 0)
            {
                throw new Exception("El Alcance no puede ser vacio");
            }
        }

        private void ValidarCostoOperacion()
        {
            if (CostoOperacionKm == 0)
            {
                throw new Exception("El Costo de operacion no puede ser vacio");
            }
        }
    }
}
