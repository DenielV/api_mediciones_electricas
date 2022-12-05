using AutoMapper;
using mediciones_electricas_api.Dtos.Orden;
using mediciones_electricas_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly mediciones_electricasContext _context;
        private readonly IMapper _mapper;

        public OrdenController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public List<DtoGraficaOrdenCantidadPorMes> GraficaCantidadOrdenesPorMesDeEntrega()
        {
            List<DtoGraficaOrdenCantidadPorMes> result = new List<DtoGraficaOrdenCantidadPorMes>(); 
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            for (int i = 0; i < meses.Length; i++)
            {
                result.Add(new DtoGraficaOrdenCantidadPorMes
                {
                    Mes = meses[i],
                    Cantidad = _context.Ordens.Where(o => o.FechaEntrega.Value.Month == i + 1).Count()
                });
            }
            return result;
        }

        [HttpGet("[action]")]
        public List<DtoGraficaOrdenCantidadPorMes> GraficaCantidadOrdenesPorMesDeInicio()
        {
            List<DtoGraficaOrdenCantidadPorMes> result = new List<DtoGraficaOrdenCantidadPorMes>();
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            for (int i = 0; i < meses.Length; i++)
            {
                result.Add(new DtoGraficaOrdenCantidadPorMes
                {
                    Mes = meses[i],
                    Cantidad = _context.Ordens.Where(o => o.FechaInicio.Value.Month == i + 1).Count()
                });
            }
            return result;
        }
        [HttpGet("[action]")]
        public List<DtoReporteOrdenPorMes> ReporteOrdenesPorMesDeInicio()
        {
            List<DtoReporteOrdenPorMes> result = new List<DtoReporteOrdenPorMes>();
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            for (int i = 0; i < meses.Length; i++)
            {
                result.Add(new DtoReporteOrdenPorMes
                {
                    Mes = meses[i],
                    Ordenes = _mapper.Map<List<DtoOrden>>(_context.Ordens.Include(o => o.OrdenProductos).Where(o => o.FechaInicio.Value.Month == i + 1).AsEnumerable())
                });
            }
            return result;
        }
        [HttpGet("[action]")]
        public List<DtoReporteOrdenPorMes> ReporteOrdenesPorMesDeEntrega()
        {
            List<DtoReporteOrdenPorMes> result = new List<DtoReporteOrdenPorMes>();
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            for (int i = 0; i < meses.Length; i++)
            {
                result.Add(new DtoReporteOrdenPorMes
                {
                    Mes = meses[i],
                    Ordenes = _mapper.Map<List<DtoOrden>>(_context.Ordens.Include(o => o.OrdenProductos).Where(o => o.FechaEntrega.Value.Month == i + 1).AsEnumerable())
                });
            }
            return result;
        }

        // GET: api/<OrdenController>
        [HttpGet("[action]")]
        public List<DtoOrden> Get()
        {
            var Orden = _context.Ordens.ToList();
            return _mapper.Map<List<DtoOrden>>(Orden);
        }

        // GET api/<OrdenController>/5
        [HttpGet("[action]/{id}")]
        public DtoOrden Get(int id)
        {
            var Orden = _context.Ordens.Find(id);
            return _mapper.Map<DtoOrden>(Orden);
        }

        // POST api/<OrdenController>
        [HttpPost("[action]")]
        public IActionResult CrearNuevo(DtoOrdenNuevoEditar request)
        {
            if (request == null)
                return StatusCode(StatusCodes.Status400BadRequest);
            var Orden = _mapper.Map<Orden>(request);
            _context.Add(Orden);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);

        }

        // PUT api/<OrdenController>/5
        [HttpPut("[action]/{id}")]
        public IActionResult Editar(int id, DtoOrdenNuevoEditar request)
        {
            var Orden = _context.Ordens.Find(id);
            Orden = _mapper.Map(request, Orden);
            _context.Ordens.Update(Orden);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        // DELETE api/<OrdenController>/5
        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var Orden = _context.Ordens.Find(id);
            _context.Ordens.Remove(Orden);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
