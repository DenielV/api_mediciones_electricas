using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class Prueba
    {
        public bool Resultado { get; set; }
        public decimal valor { get; set; }
        public DateTime Fecha { get; set; }
        public int IdModelo { get; set; }
        public string Serie { get; set; }
        public int IdLineaProd { get; set; }
        public int IdEmpleado { get; set; }
        public int IdEquipo { get; set; }
        public int Id { get; set; }
        public int idTipoPrueba { get; set; }

        public TipoPrueba IdTipoPruebaNavigation { get; set; }
        public  Empleado IdEmpleadoNavigation { get; set; }
        public  Equipo IdEquipoNavigation { get; set; }
        public  LineaProduccion IdLineaProdNavigation { get; set; }
        public  Modelo IdModeloNavigation { get; set; }
    }
}
