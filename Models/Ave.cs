using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Ave
    {
        public Ave()
        {
            EncargadoAves = new HashSet<EncargadoAve>();
        }

        public string Nombre { get; set; } = null!;
        public DateTime? FechaLlegada { get; set; }
        public int Sexo { get; set; }
        public string Raza { get; set; } = null!;

        public virtual Sexo SexoNavigation { get; set; } = null!;
        public virtual ICollection<EncargadoAve> EncargadoAves { get; set; }
    }
}
