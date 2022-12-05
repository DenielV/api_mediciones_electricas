using mediciones_electricas_api.Dtos.Productos;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using mediciones_electricas_api.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly Models.mediciones_electricasContext _context;
        private readonly IMapper _mapper;

        public ProductosController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<DtoProducto> listadoProductos()
        {
            return _mapper.Map<List<DtoProducto>>(_context.Productos);
        }

        [HttpGet("{id}")]
        public Producto Get(int id)
        {
            var producto= _context.Productos.Include(p => p.Modelos).Include(p => p.EquiposProductos).FirstOrDefault(p => p.Id == id);
            return producto;
        }

        // POST api/<ProductosController>
        [HttpPost]
        public IActionResult CrearNuevo( DtoProductoNuevoEditar request)
        {
            if (request == null)
                StatusCode(StatusCodes.Status400BadRequest);
            _context.Add(_mapper.Map<Producto>(request));
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK); 
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, DtoProductoNuevoEditar request)
        {
            var producto = Get(id);
            _mapper.Map(request, producto);
            _context.Productos.Update(producto);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);

        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = Get(id);
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);

        }
    }
}
