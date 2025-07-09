using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class OrdenarFecha : IComparer<Pasaje>
    {

        public string Criterio { get; set; }

        public OrdenarFecha(string criterio)
        {
            Criterio = criterio;
            
        }

        public int Compare(Pasaje x, Pasaje y)
        {
            if (Criterio.Equals("Fecha"))
            {
                return x.Fecha.CompareTo(y.Fecha);
            }
            return -x.Fecha.CompareTo(y.Fecha);

        }
    }
}

