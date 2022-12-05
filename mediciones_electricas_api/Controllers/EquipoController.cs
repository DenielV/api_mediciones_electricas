using AutoMapper;
using mediciones_electricas_api.Dtos.Equipos;
using mediciones_electricas_api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {

        private readonly mediciones_electricasContext _context;
        private IMapper _mapper;
        public EquipoController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<EquipoController>
        [HttpGet]
        public List<DtoEquipo> listaEquipos(string Descripcion="")
        {
            var lista = _context.Equipos.Where(equipo => equipo.Descripcion.ToLower().StartsWith(Descripcion.ToLower())).ToList();
            var listaEquipos=_mapper.Map<List<DtoEquipo>>(lista);
            return listaEquipos;
        }

        [HttpGet("{id}")]
        public DtoEquipo equipoXid(int id)
        {
            if (id < 1)
                return null;
            var equipo = _context.Equipos.Find(id);
            return _mapper.Map<DtoEquipo>(equipo);

        }
        // GET api/<EquipoController>/5
        [NonAction]
        [HttpGet]
        public Equipo EquipoPorId(int id)
        {
            if (id < 1)
                return null;
            var equipo = _context.Equipos.Find(id);
            return equipo;
        }

        // POST api/<EquipoController>
        [HttpPost]
        public IActionResult CrearEquipo( DtoEquipoNuevoEditar request)
        {
            if(string.IsNullOrEmpty(request.Descripcion))
                return StatusCode(StatusCodes.Status400BadRequest);
            _context.Add(_mapper.Map<Equipo>(request));
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<EquipoController>/5
        [HttpPut("{id}")]
        public IActionResult Editar(int id,  DtoEquipoNuevoEditar request)
        {

            if (string.IsNullOrEmpty(request.Descripcion))
                return StatusCode(StatusCodes.Status400BadRequest);
            var equipo = EquipoPorId(id);
            _mapper.Map(request, equipo);
            _context.Equipos.Update(equipo);           
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        // DELETE api/<EquipoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var equipo = _mapper.Map<Equipo>(EquipoPorId(id));
            _context.Equipos.Remove(equipo);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
