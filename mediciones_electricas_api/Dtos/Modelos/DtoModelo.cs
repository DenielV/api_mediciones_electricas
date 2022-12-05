using mediciones_electricas_api.Dtos.Productos;
using mediciones_electricas_api.Dtos.TestPlan;

namespace mediciones_electricas_api.Dtos.Modelos
{
    public class DtoModelo
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdTestPlan { get; set; }

        public DtoProducto IdProductoNavigation { get; set; }
        public DtoTestPlan IdTestPlanNavigation { get; set; }
    }
}
