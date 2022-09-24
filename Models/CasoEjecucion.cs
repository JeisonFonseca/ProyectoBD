using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class CasoEjecucion
    {
        public int Proyecto { get; set; }
        public int Caso { get; set; }

        public virtual Caso CasoNavigation { get; set; } = null!;
        public virtual Ejecucion ProyectoNavigation { get; set; } = null!;
    }
}
