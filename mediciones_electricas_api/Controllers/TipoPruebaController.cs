using AutoMapper;
using mediciones_electricas_api.Dtos.TipoPrueba;
using mediciones_electricas_api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPruebaController : ControllerBase
    {
        private readonly mediciones_electricasContext _context;
        private readonly IMapper _mapper;

        public TipoPruebaController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<TipoPruebaController>
        [HttpGet("[action]")]
        public List<DtoTipoPrueba> Get()
        {
            var tipoPrueba = _context.TipoPrueba.ToList();
            return _mapper.Map<List<DtoTipoPrueba>>(tipoPrueba);
        }

        // GET api/<TipoPruebaController>/5
        [HttpGet("[action]/{id}")]
        public DtoTipoPrueba Get(int id)
        {
            var tipoPrueba = _context.TipoPrueba.Find(id);
            return _mapper.Map<DtoTipoPrueba>(tipoPrueba);
        }

        // POST api/<TipoPruebaController>
        [HttpPost("[action]")]
        public IActionResult CrearNuevo(DtoTipoPruebaNuevoEditar request)
        {
            if (request == null)
                return StatusCode(StatusCodes.Status400BadRequest);
            var tipoPrueba = _mapper.Map<TipoPrueba>(request);
            _context.Add(tipoPrueba);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);

        }

        // PUT api/<TipoPruebaController>/5
        [HttpPut("[action]/{id}")]
        public IActionResult Editar(int id, DtoTipoPruebaNuevoEditar request)
        {
            var tipoPrueba = _context.TipoPrueba.Find(id);
            tipoPrueba = _mapper.Map(request, tipoPrueba);
            _context.TipoPrueba.Update(tipoPrueba);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        // DELETE api/<TipoPruebaController>/5
        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var tipoPrueba = _context.TipoPrueba.Find(id);
            _context.TipoPrueba.Remove(tipoPrueba);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
