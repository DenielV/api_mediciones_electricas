using mediciones_electricas_api.Dtos.TipoPrueba;

namespace mediciones_electricas_api.Dtos.Prueba
{
    public class DtoGraficaResultadosPorTipoDePrueba
    {
        public int idTipoPrueba { get; set; }
        public DtoTipoPrueba idTipoPruebaNavigation { get; set; }
        public int Buenas { get; set; }
        public int Fallas { get; set; }
    }
}
