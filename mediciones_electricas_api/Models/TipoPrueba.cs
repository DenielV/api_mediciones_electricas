namespace mediciones_electricas_api.Models
{
    public class TipoPrueba
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Prueba> Pruebas { get; set; }
    }
}
