using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class FamiliaProducto
    {
        public FamiliaProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
