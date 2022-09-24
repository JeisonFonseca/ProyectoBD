using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class ActividadCliente
    {
        public int Id { get; set; }
        public long Cliente { get; set; }
        public string Descripcion { get; set; } = null!;
        public long Asesor { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Cliente ClienteNavigation { get; set; } = null!;
    }
}
