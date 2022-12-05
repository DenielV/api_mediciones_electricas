using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            OrdenProductos = new HashSet<OrdenProducto>();
            Pruebas = new HashSet<Prueba>();
        }

        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdTestPlan { get; set; }

        public  Producto IdProductoNavigation { get; set; }
        public  TestPlan IdTestPlanNavigation { get; set; }
        public  ICollection<OrdenProducto> OrdenProductos { get; set; }
        public  ICollection<Prueba> Pruebas { get; set; }
    }
}
