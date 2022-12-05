using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class Equipo
    {
        public Equipo()
        {
            EquiposEmpleados = new HashSet<EquiposEmpleado>();
            EquiposProductos = new HashSet<EquiposProducto>();
            Pruebas = new HashSet<Prueba>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<EquiposEmpleado> EquiposEmpleados { get; set; }
        public  ICollection<EquiposProducto> EquiposProductos { get; set; }
        public  ICollection<Prueba> Pruebas { get; set; }
    }
}
