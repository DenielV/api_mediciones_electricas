using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            EquiposEmpleados = new HashSet<EquiposEmpleado>();
            Pruebas = new HashSet<Prueba>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdPuesto { get; set; }
        public int Turno { get; set; }
        public string Contraseña { get; set; }

        public  Puesto IdPuestoNavigation { get; set; }
        public  virtual ICollection<EquiposEmpleado> EquiposEmpleados { get; set; }
        public  ICollection<Prueba> Pruebas { get; set; }
    }
}
