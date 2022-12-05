using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class Puesto
    {
        public Puesto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public decimal Salario { get; set; }
        public string Descripcion { get; set; }

        public  ICollection<Empleado> Empleados { get; set; }
    }
}
