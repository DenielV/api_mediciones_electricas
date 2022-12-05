namespace mediciones_electricas_api.Dtos.Orden
{
    public class DtoOrden
    {
        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaEntrega { get; set; }

        //public ICollection<DtoOrdenProducto> OrdenProductos { get; set; }
    }
}
