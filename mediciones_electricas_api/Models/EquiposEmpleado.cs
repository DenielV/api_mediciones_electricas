using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class EquiposEmpleado
    {
        public int? IdEquipo { get; set; }
        public int? IdEmpleado { get; set; }
        public int Id { get; set; }

        public  Empleado IdEmpleadoNavigation { get; set; }
        public  Equipo IdEquipoNavigation { get; set; }
    }
}
