using System;
using System.Collections.Generic;

namespace mediciones_electricas_api.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        
    }
}
