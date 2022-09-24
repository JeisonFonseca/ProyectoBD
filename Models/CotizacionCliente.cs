using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class CotizacionCliente
    {
        public int Id { get; set; }
        public int Cotizacion { get; set; }
        public long Asesor { get; set; }
        public long Cliente { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Cliente ClienteNavigation { get; set; } = null!;
        public virtual Cotizacion CotizacionNavigation { get; set; } = null!;
    }
}
