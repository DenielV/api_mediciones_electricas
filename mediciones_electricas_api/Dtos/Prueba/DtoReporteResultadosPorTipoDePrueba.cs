namespace mediciones_electricas_api.Dtos.Prueba
{
    public class DtoReporteResultadosPorTipoDePrueba
    {
        public string TipoDePrueba { get; set; }
        public List<DtoPrueba> Pruebas { get; set; }
    }
}
