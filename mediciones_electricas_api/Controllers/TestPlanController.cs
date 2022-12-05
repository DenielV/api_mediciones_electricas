using AutoMapper;
using mediciones_electricas_api.Dtos.TestPlan;
using mediciones_electricas_api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mediciones_electricas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestPlanController : ControllerBase
    {
        private readonly mediciones_electricasContext _context;
        private IMapper _mapper;
        public TestPlanController(mediciones_electricasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<TestPlanController>
        [HttpGet]
        public List<DtoTestPlan> listadoTestPlan(string nombre="")
        {
            var testplan = _context.TestPlans.Where(t => t.Nombre.ToLower().StartsWith(nombre.ToLower())).ToList();
            var listaTestplan = _mapper.Map<List<DtoTestPlan>>(testplan);
            return listaTestplan;
        }

        [HttpGet("{id}")]
        public DtoTestPlan testPlanXId(int id)
        {
            if (id < 1)
                return null;
            var testPlan = _context.TestPlans.Find(id);
            return _mapper.Map<DtoTestPlan>(testPlan);
        }

        [NonAction]
        [HttpGet]
        public TestPlan testPlanPorId(int id)
        {
            if (id < 1)
                return null;
            var testPlan = _context.TestPlans.Find(id);
            return testPlan;
        }

        // POST api/<TestPlanController>
        [HttpPost]
        public IActionResult CrearNuevo( DtoTestPlanNuevoEditar request)
        {
            if (request==null||string.IsNullOrEmpty(request?.Nombre))
                return StatusCode(StatusCodes.Status400BadRequest);
            _context.Add(_mapper.Map<TestPlan>(request));
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<TestPlanController>/5
        [HttpPut("{id}")]
        public IActionResult Editar(int id,  DtoTestPlanNuevoEditar request)
        {
            if (string.IsNullOrEmpty(request.Nombre))
                return StatusCode(StatusCodes.Status400BadRequest);
            var testPlan = testPlanPorId(id);
            _mapper.Map(request, testPlan);
            _context.TestPlans.Update(testPlan);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        // DELETE api/<TestPlanController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var testPlan = testPlanPorId(id);
            _context.TestPlans.Remove(testPlan);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
