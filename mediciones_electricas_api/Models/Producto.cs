using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class Producto
    {
        public Producto()
        {
            EquiposProductos = new HashSet<EquiposProducto>();
            Modelos = new HashSet<Modelo>();
            OrdenProductos = new HashSet<OrdenProducto>();
        }

        public int Id { get; set; }
        public string ListaParte { get; set; }
        public string Procedimiento { get; set; }
        public string Especificaciones { get; set; }
        public string Desviaciones { get; set; }

        public  ICollection<EquiposProducto> EquiposProductos { get; set; }
        public  ICollection<Modelo> Modelos { get; set; }
        public  ICollection<OrdenProducto> OrdenProductos { get; set; }
    }
}
