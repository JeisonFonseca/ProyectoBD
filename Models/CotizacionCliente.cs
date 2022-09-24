using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class CotizacionCliente
    {
        public int Id { get; set; }
        public int Cotizacion { get; set; }
        public int Asesor { get; set; }
        public int Cliente { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Cliente ClienteNavigation { get; set; } = null!;
        public virtual Cotizacion CotizacionNavigation { get; set; } = null!;
    }
}
