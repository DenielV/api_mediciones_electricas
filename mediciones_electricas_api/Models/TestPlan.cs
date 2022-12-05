using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class TestPlan
    {
        public TestPlan()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public ICollection<Modelo> Modelos { get; set; }
    }
}
