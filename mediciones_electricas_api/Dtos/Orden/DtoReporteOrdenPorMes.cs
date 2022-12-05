namespace mediciones_electricas_api.Dtos.Orden
{
    public class DtoReporteOrdenPorMes
    {
        public string Mes { get; set; }
        public List<DtoOrden> Ordenes { get; set; }
    }
}
