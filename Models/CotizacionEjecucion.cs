using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class CotizacionEjecucion
    {
        public int Cotizacion { get; set; }
        public int Ejecucion { get; set; }

        public virtual Cotizacion CotizacionNavigation { get; set; } = null!;
        public virtual Ejecucion EjecucionNavigation { get; set; } = null!;
    }
}
