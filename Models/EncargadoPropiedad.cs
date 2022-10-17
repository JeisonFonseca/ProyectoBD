using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class EncargadoPropiedad
    {
        public string CedulaEncargado { get; set; } = null!;
        public int CodigoPropiedad { get; set; }

        public virtual Encargado CedulaEncargadoNavigation { get; set; } = null!;
        public virtual Propiedad CodigoPropiedadNavigation { get; set; } = null!;
    }
}
