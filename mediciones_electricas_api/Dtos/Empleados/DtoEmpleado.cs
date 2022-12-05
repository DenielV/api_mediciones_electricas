namespace mediciones_electricas_api.Dtos.Empleados
{
    public class DtoEmpleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdPuesto { get; set; }
        public int Turno { get; set; }
    }
}
