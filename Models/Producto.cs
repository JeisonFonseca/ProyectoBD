using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Producto
    {
        public Producto()
        {
            CotizacionProductos = new HashSet<CotizacionProducto>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public int FamiliaProducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }
        public double PrecioEstandar { get; set; }

        public virtual FamiliaProducto FamiliaProductoNavigation { get; set; } = null!;
        public virtual ICollection<CotizacionProducto> CotizacionProductos { get; set; }
    }
}
