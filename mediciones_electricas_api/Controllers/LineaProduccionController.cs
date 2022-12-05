using AutoMapper;
using mediciones_electricas_api.Dtos.LineaProduccion;
using mediciones_electricas_api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineaProduccionController : ControllerBase
    {
        private readonly mediciones_electricasContext _context;
        private IMapper _mapper;
        public LineaProduccionController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<LineaProduccionController>
        [HttpGet]
        public List<DtoLineaProduccion> listadoLineas(string nombre = "", string area = "")
        {
            var lineas = _context.LineaProduccions.Where(l => l.Nombre.ToLower().StartsWith(nombre.ToLower()) && l.Area.ToLower().StartsWith(area.ToLower())).ToList();
            var lineasMapeadas = _mapper.Map<List<DtoLineaProduccion>>(lineas);
            return lineasMapeadas;
        }
        [HttpGet("{id}")]
        public DtoLineaProduccion lineaxId(int id)
        {
            if (id < 1)
                return null;
            var linea = _mapper.Map<DtoLineaProduccion>(_context.LineaProduccions.Find(id));
            return linea;
        }
        // GET api/<LineaProduccionController>/5

        [NonAction]
        [HttpGet]
        public LineaProduccion lineaPorId(int id)
        {
            if (id < 1)
                return null;
            var linea = _context.LineaProduccions.Find(id);
            return linea;
        }

        // POST api/<LineaProduccionController>
        [HttpPost]
        public IActionResult CrearNuevo(DtoLineaProduccionNuevoEditar request)
        {
            if (string.IsNullOrEmpty(request.Nombre) || string.IsNullOrEmpty(request.Area))
                return StatusCode(StatusCodes.Status400BadRequest);
            _context.Add(_mapper.Map<LineaProduccion>(request));
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<LineaProduccionController>/5
        [HttpPut("{id}")]
        public IActionResult Editar(int id, DtoLineaProduccionNuevoEditar request)
        {
            if (string.IsNullOrEmpty(request.Nombre) || string.IsNullOrEmpty(request.Area))
                return StatusCode(StatusCodes.Status400BadRequest);
            var linea = lineaPorId(id);
            _mapper.Map(request, linea);

            _context.LineaProduccions.Update(linea);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);

        }

        // DELETE api/<LineaProduccionController>/5
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var linea = lineaPorId(id);
            _context.LineaProduccions.Remove(linea);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
