using AutoMapper;
using mediciones_electricas_api.Dtos.Puestos;
using mediciones_electricas_api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private readonly mediciones_electricasContext _context;
        private IMapper _mapper;

        public PuestoController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<PuestoController>
        [HttpGet]
        public List<DtoPuesto> listaPuestos(string descripcion="")
        {
            var puestos=_context.Puestos.Where(p=>p.Descripcion.ToLower().StartsWith(descripcion.ToLower())).ToList();
            return _mapper.Map<List<DtoPuesto>>(puestos);
        }

        [HttpGet("{id}")]
        public IActionResult puestoXid(int id)
        {
            if (id < 1)
                return StatusCode(StatusCodes.Status400BadRequest);
            var puesto = _context.Puestos.Find(id);
            return StatusCode(StatusCodes.Status200OK, _mapper.Map<DtoPuesto>(puesto));
        }
        // GET api/<PuestoController>/5
        [NonAction]
        [HttpGet("{id}")]
        public Puesto Get(int id)
        {
            if (id < 1)
                return null;
            var puesto = _context.Puestos.Find(id);
            return puesto;
        }

        // POST api/<PuestoController>
        [HttpPost]
        public IActionResult CrearNuevo(DtoPuestoNuevoEditar request)
        {
            if (request == null || string.IsNullOrEmpty(request?.Descripcion) || string.IsNullOrEmpty(request?.Salario.ToString()))
                return StatusCode(StatusCodes.Status404NotFound);
            _context.Add(_mapper.Map<Puesto>(request));
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<PuestoController>/5
        [HttpPut("{id}")]
        public IActionResult Editar(int id, DtoPuestoNuevoEditar request)
        {
            var puesto= Get(id);
            _mapper.Map(request, puesto);
            _context.Puestos.Update(puesto);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        // DELETE api/<PuestoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var puesto = Get(id);
            if(puesto == null)
                return StatusCode(StatusCodes.Status404NotFound);
            _context.Puestos.Remove(puesto);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
