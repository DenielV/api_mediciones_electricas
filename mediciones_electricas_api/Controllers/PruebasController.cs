using AutoMapper;
using mediciones_electricas_api.Dtos.Orden;
using mediciones_electricas_api.Dtos.Prueba;
using mediciones_electricas_api.Dtos.TipoPrueba;
using mediciones_electricas_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebasController : ControllerBase
    {
        private readonly mediciones_electricasContext _context;
        private readonly IMapper _mapper;

        public PruebasController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<PruebasController>
        [HttpGet("[action]")]
        public List<DtoGraficaResultadosPorTipoDePrueba> GraficaResultadosPorTipoDePrueba()
        {
            List<DtoGraficaResultadosPorTipoDePrueba> resultados = new List<DtoGraficaResultadosPorTipoDePrueba>();

            List<TipoPrueba> tiposPrueba = _context.TipoPrueba.ToList();

            foreach (var tipoPrueba in tiposPrueba)
            {
                DtoGraficaResultadosPorTipoDePrueba tipoPruebaResultados = new DtoGraficaResultadosPorTipoDePrueba { idTipoPrueba = tipoPrueba.ID};
                tipoPruebaResultados.idTipoPruebaNavigation = _mapper.Map<DtoTipoPrueba>(tipoPrueba);
                tipoPruebaResultados.Buenas = _context.Pruebas.Where(p => p.idTipoPrueba == tipoPrueba.ID && p.Resultado).Count();
                tipoPruebaResultados.Fallas = _context.Pruebas.Where(p => p.idTipoPrueba == tipoPrueba.ID && !p.Resultado).Count();
                resultados.Add(tipoPruebaResultados);
            }

            return resultados;
        }

        [HttpGet("[action]")]
        public List<DtoReporteResultadosPorTipoDePrueba> ReporteResultadosPorTipoDePrueba()
        {
            List<DtoReporteResultadosPorTipoDePrueba> resultados = new List<DtoReporteResultadosPorTipoDePrueba>();

            List<TipoPrueba> tiposPrueba = _context.TipoPrueba.ToList();

            foreach (var tipoPrueba in tiposPrueba)
            {
                DtoReporteResultadosPorTipoDePrueba tipoPruebaResultados = new DtoReporteResultadosPorTipoDePrueba { TipoDePrueba = tipoPrueba.Descripcion };
                tipoPruebaResultados.Pruebas = _mapper.Map <List<DtoPrueba>>(_context.Pruebas.Include(p => p.IdEquipoNavigation).Include(p => p.IdEmpleadoNavigation)
                .Include(p => p.IdLineaProdNavigation).Include(p => p.IdModeloNavigation).Where(p => p.idTipoPrueba == tipoPrueba.ID).AsEnumerable());
                resultados.Add(tipoPruebaResultados);
            }

            return resultados;
        }

        [HttpGet("[action]/{numSerie}")]
        public List<DtoPrueba> ReporteResultadosPorNumeroDeSerie(string numSerie)
        {
            var resultados = _context.Pruebas.Include(p => p.IdEquipoNavigation).Include(p => p.IdEmpleadoNavigation).Include(p => p.IdTipoPruebaNavigation)
                .Include(p => p.IdLineaProdNavigation).Include(p => p.IdModeloNavigation).Where(p => p.Serie == numSerie);
            return _mapper.Map<List<DtoPrueba>>(resultados.AsEnumerable());
        }

        // GET api/<PruebasController>/5
        [HttpGet("[action]/{id}")]
        public DtoPrueba ObtenerPrueba(int id)
        {
            var resultado = _context.Pruebas.Include(p => p.IdEquipoNavigation).Include(p => p.IdEmpleadoNavigation).Include(p => p.IdTipoPruebaNavigation)
                .Include(p => p.IdLineaProdNavigation).Include(p => p.IdModeloNavigation).FirstOrDefault(p => p.Id == id);
            return _mapper.Map<DtoPrueba>(resultado);
        }

        // POST api/<PruebasController>
        [HttpPost("[action]")]
        public IActionResult RegistrarPrueba([FromBody] DtoPruebaNuevoEditar request)
        {
            if (request == null)
                return StatusCode(StatusCodes.Status400BadRequest);
            var prueba = _mapper.Map<Prueba>(request);
            _context.Add(prueba);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<PruebasController>/5
        [HttpPut("[action]/{id}")]
        public IActionResult ModificarPrueba(int id, [FromBody] DtoPruebaNuevoEditar request)
        {
            var prueba = _context.Pruebas.Find(id);
            prueba = _mapper.Map(request, prueba);
            _context.Pruebas.Update(prueba);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        // DELETE api/<PruebasController>/5
        [HttpDelete("[action]/{id}")]
        public IActionResult EliminarPrueba(int id)
        {
            var prueba = _context.Pruebas.Find(id);
            _context.Pruebas.Remove(prueba);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
