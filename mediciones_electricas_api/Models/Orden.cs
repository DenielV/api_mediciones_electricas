using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class Orden
    {
        public Orden()
        {
            OrdenProductos = new HashSet<OrdenProducto>();
        }

        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaEntrega { get; set; }

        public  ICollection<OrdenProducto> OrdenProductos { get; set; }
    }
}
