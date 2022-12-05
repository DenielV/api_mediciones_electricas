using AutoMapper;
using mediciones_electricas_api.Dtos.Empleados;
using mediciones_electricas_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {

        private readonly mediciones_electricasContext _context;
        private readonly IMapper _mapper;

        public EmpleadosController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<DtoEmpleado> listaEmpleadosResumen(string nombre="", string apellido="")
        {
            var empleados= _context.Empleados.Where(emp => emp.Nombre.ToLower().StartsWith(nombre.ToLower()) && emp.Apellido.ToLower().StartsWith(apellido.ToLower())).ToList();
            return _mapper.Map<List<DtoEmpleado>>(empleados);
        }

        [HttpGet("Detalle/{id}")]
     public Empleado empleadoDetalle(int id)
        {
            var empleado = _context.Empleados.Include(emp => emp.IdPuestoNavigation).Include(emp => emp.Pruebas).Include(emp=>emp.EquiposEmpleados).Where(emp=>emp.Id==id).First();
            return empleado;
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public IActionResult CrearNuevo(DtoEmpleadoNuevoEditar request)
        {
            List<Equipo> lista = new List<Equipo>();
            if (request == null)
                return StatusCode(StatusCodes.Status400BadRequest);
            var empleado = _mapper.Map<Empleado>(request);
            _context.Add(empleado);
            _context.SaveChanges();
            for (int i = 0; i < request.listaEquipos.Count; i++)
            {
                EquiposEmpleado relacion = new EquiposEmpleado { IdEmpleado = empleado.Id, IdEquipo = request.listaEquipos[i] };
                _context.Add(relacion);
            }
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);

        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public IActionResult Editar(int id, DtoEmpleadoNuevoEditar request)
        {
            List<Equipo> lista = new List<Equipo>();
            request.listaEquipos.ForEach(id => lista.Add(_context.Equipos.Find(id)));
            var empleado = empleadoDetalle(id);
            _mapper.Map(request, empleado);
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var empleado = empleadoDetalle(id);
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
