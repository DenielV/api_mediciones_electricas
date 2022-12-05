namespace mediciones_electricas_api.Dtos.Prueba
{
    public class DtoPruebaNuevoEditar
    {
        public bool Resultado { get; set; }
        public decimal valor { get; set; }
        public DateTime Fecha { get; set; }
        public int IdModelo { get; set; }
        public string Serie { get; set; }
        public int IdLineaProd { get; set; }
        public int IdEmpleado { get; set; }
        public int IdEquipo { get; set; }
        public int idTipoPrueba { get; set; }
    }
}
