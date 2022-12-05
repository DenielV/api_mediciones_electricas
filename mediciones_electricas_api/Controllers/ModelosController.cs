using AutoMapper;
using mediciones_electricas_api.Dtos.Modelos;
using mediciones_electricas_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly mediciones_electricasContext _context;
        private readonly IMapper _mapper;

        public ModelosController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<Modelo> listadoModelos()
        {
            return _context.Modelos.Include(m=>m.IdProductoNavigation).Include(m=>m.IdTestPlanNavigation).ToList();
        }

        [HttpGet("{id}")]
        public Modelo Get(int id)
        {
            return _context.Modelos.Include(m => m.IdProductoNavigation).Include(m => m.IdProductoNavigation).ToList().Where(m => m.Id == id).First();
        }

        [HttpPost]
        public IActionResult Post(DtoModeloNuevoEditar request)
        {
            _context.Add(_mapper.Map<Modelo>(request));
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public void Editar(int id,  DtoModeloNuevoEditar request)
        {
            var modelo = Get(id);
            _mapper.Map(request, modelo);
            _context.Modelos.Update(modelo);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var modelo = Get(id);
            _context.Modelos.Remove(modelo);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
