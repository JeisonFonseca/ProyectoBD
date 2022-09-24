using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class TareaCliente
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime? FechaFinalizacion { get; set; }
        public int EstadoTarea { get; set; }
        public int Asesor { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Cliente ClienteNavigation { get; set; } = null!;
        public virtual EstadoTarea EstadoTareaNavigation { get; set; } = null!;
    }
}
