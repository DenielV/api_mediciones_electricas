using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class EquiposProducto
    {
        public int Id { get; set; }
        public int? IdEquipo { get; set; }
        public int? IdProducto { get; set; }

        public  Equipo? IdEquipoNavigation { get; set; }
        public  Producto? IdProductoNavigation { get; set; }
    }
}
