using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class ActividadContacto
    {
        public int Id { get; set; }
        public long Contacto { get; set; }
        public string Descripcion { get; set; } = null!;
        public long Asesor { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Contacto ContactoNavigation { get; set; } = null!;
    }
}
