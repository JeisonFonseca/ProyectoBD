using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Propiedad
    {
        public Propiedad()
        {
            EncargadoPropiedads = new HashSet<EncargadoPropiedad>();
        }

        public int CodigoEscritura { get; set; }
        public string Descripcion { get; set; } = null!;
        public short Area { get; set; }
        public DateTime FechaCompra { get; set; }

        public virtual ICollection<EncargadoPropiedad> EncargadoPropiedads { get; set; }
    }
}
