using mediciones_electricas_api.Dtos.Empleados;
using mediciones_electricas_api.Dtos.Equipos;
using mediciones_electricas_api.Dtos.LineaProduccion;
using mediciones_electricas_api.Dtos.Modelos;
using mediciones_electricas_api.Dtos.TipoPrueba;

namespace mediciones_electricas_api.Dtos.Prueba
{
    public class DtoPrueba
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

        public DtoTipoPrueba IdTipoPruebaNavigation { get; set; }
        public DtoEmpleado IdEmpleadoNavigation { get; set; }
        public DtoEquipo IdEquipoNavigation { get; set; }
        public DtoLineaProduccion IdLineaProdNavigation { get; set; }
        public DtoModelo IdModeloNavigation { get; set; }
    }
}
