using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class ContactoCliente
    {
        public long Contacto { get; set; }
        public long Asesor { get; set; }
        public int EstadoContacto { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Contacto ContactoNavigation { get; set; } = null!;
        public virtual EstadoContacto EstadoContactoNavigation { get; set; } = null!;
    }
}
