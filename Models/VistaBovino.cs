using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class VistaBovino
    {
        public int Identificador { get; set; }
        public string Nombre { get; set; } = null!;
        public string Raza { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
        public string Sex { get; set; } = null!;
        public DateTime? FechaMonta { get; set; }
        public int? Madre { get; set; }
        public int? Padre { get; set; }
        public string Tipo { get; set; } = null!;
    }
}
