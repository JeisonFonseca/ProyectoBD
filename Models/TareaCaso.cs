using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class TareaCaso
    {
        public int Id { get; set; }
        public int Caso { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime? FechaFinalizacion { get; set; }
        public int EstadoTarea { get; set; }
        public int Asesor { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Caso CasoNavigation { get; set; } = null!;
        public virtual EstadoTarea EstadoTareaNavigation { get; set; } = null!;
    }
}
