using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Perro
    {
        public Perro()
        {
            EncargadoPerros = new HashSet<EncargadoPerro>();
        }

        public string Nombre { get; set; } = null!;
        public DateTime? FechaLlegada { get; set; }
        public int Sexo { get; set; }

        public virtual Sexo SexoNavigation { get; set; } = null!;
        public virtual ICollection<EncargadoPerro> EncargadoPerros { get; set; }
    }
}
