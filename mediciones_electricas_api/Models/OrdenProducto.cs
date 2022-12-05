using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class OrdenProducto
    {
        public int Id { get; set; }
        public int? IdOrden { get; set; }
        public int? IdProducto { get; set; }
        public int? IdModelo { get; set; }
        public string Serie { get; set; }

        public  Modelo IdModeloNavigation { get; set; }
        public  Orden IdOrdenNavigation { get; set; }
        public  Producto IdProductoNavigation { get; set; }
    }
}
