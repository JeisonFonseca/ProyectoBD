using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class VistaPorcinosGeneral
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime? FechaLlegada { get; set; }
        public double? PesoLlegada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public double? PesoSalida { get; set; }
        public int Sexo { get; set; }
        public string Dueno { get; set; } = null!;
    }
}
