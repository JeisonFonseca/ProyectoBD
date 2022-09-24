using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class CotizacionProducto
    {
        public int Cotizacion { get; set; }
        public int CodigoProducto { get; set; }
        public int CantidadProducto { get; set; }

        public virtual Producto CodigoProductoNavigation { get; set; } = null!;
        public virtual Cotizacion CotizacionNavigation { get; set; } = null!;
    }
}
