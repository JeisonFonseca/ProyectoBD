using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class CotizacionCliente
    {
        public int Cotizacion { get; set; }
        public long Asesor { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Cotizacion CotizacionNavigation { get; set; } = null!;
    }
}
