namespace mediciones_electricas_api.Dtos.Orden
{
    public class DtoOrdenNuevoEditar
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public List<int> Productos { get; set; }
    }
}
