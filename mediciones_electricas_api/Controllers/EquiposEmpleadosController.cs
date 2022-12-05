using AutoMapper;
using mediciones_electricas_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposEmpleadosController : ControllerBase
    {

        private readonly mediciones_electricasContext _context;
        private readonly IMapper _mapper;

        public EquiposEmpleadosController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("[action]/{equipoId}")]
        public EquiposEmpleado EquipoEmpleados(int equipoId)
        {
            var equipoEmpleados = _context.EquiposEmpleados.Include(rel => rel.IdEmpleadoNavigation).Where(rel => rel.IdEquipo == equipoId).FirstOrDefault();
            return equipoEmpleados;
        }

        [HttpGet("[action]/{empleadoId}")]
        public EquiposEmpleado EmpleadoEquipos(int empleadoId)
        {
            var equipoEmpleados = _context.EquiposEmpleados.Include(rel => rel.IdEquipoNavigation).Where(rel => rel.IdEmpleado == empleadoId).FirstOrDefault();
            return equipoEmpleados;
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var equipoEmpleado = _context.EquiposEmpleados.Find(id);
            _context.EquiposEmpleados.Remove(equipoEmpleado);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("[action]/{empleadoId}/{equipoId}")]
        public IActionResult Delete(int empleadoId, int equipoId)
        {
            var equipoEmpleado = _context.EquiposEmpleados.Where(rel => rel.IdEmpleado == empleadoId && rel.IdEquipo == equipoId).FirstOrDefault();
            if(equipoEmpleado == null)
               return StatusCode(StatusCodes.Status404NotFound);
            _context.EquiposEmpleados.Remove(equipoEmpleado);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
