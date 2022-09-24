using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class ActividadCotizacion
    {
        public int Id { get; set; }
        public int Cotizacion { get; set; }
        public string Descripcion { get; set; } = null!;
        public long Asesor { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Cotizacion CotizacionNavigation { get; set; } = null!;
    }
}
