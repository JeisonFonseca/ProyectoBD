using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class VistaPropiedadDueno
    {
        public int CodigoEscritura { get; set; }
        public string Descripcion { get; set; } = null!;
        public short Area { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
