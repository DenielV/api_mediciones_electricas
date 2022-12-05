using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class LineaProduccion
    {
        public LineaProduccion()
        {
            Pruebas = new HashSet<Prueba>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }

        public  ICollection<Prueba> Pruebas { get; set; }
    }
}
