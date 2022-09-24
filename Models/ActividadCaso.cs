using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class ActividadCaso
    {
        public int Id { get; set; }
        public int Caso { get; set; }
        public string Descripcion { get; set; } = null!;
        public long Asesor { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Caso CasoNavigation { get; set; } = null!;
    }
}
