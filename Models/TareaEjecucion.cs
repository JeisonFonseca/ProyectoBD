using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class TareaEjecucion
    {
        public int Id { get; set; }
        public int Ejecucion { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime? FechaFinalizacion { get; set; }
        public int EstadoTarea { get; set; }
        public long Asesor { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Ejecucion EjecucionNavigation { get; set; } = null!;
        public virtual EstadoTarea EstadoTareaNavigation { get; set; } = null!;
    }
}
