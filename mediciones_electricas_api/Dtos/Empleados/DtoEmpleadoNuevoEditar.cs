namespace mediciones_electricas_api.Dtos.Empleados
{
    public class DtoEmpleadoNuevoEditar
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdPuesto { get; set; }
        public int Turno { get; set; }
        public string Contraseña { get; set; }
        public List<int> listaEquipos { get; set; } 
    }
}
