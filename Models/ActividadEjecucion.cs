using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class ActividadEjecucion
    {
        public int Id { get; set; }
        public int Ejecucion { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Asesor { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Ejecucion EjecucionNavigation { get; set; } = null!;
    }
}
