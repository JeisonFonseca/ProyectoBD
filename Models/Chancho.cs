using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Chancho
    {
        public Chancho()
        {
            EncargadoChanchos = new HashSet<EncargadoChancho>();
        }

        public string Nombre { get; set; } = null!;
        public DateTime? FechaLlegada { get; set; }
        public int Sexo { get; set; }

        public virtual Sexo SexoNavigation { get; set; } = null!;
        public virtual ICollection<EncargadoChancho> EncargadoChanchos { get; set; }
    }
}
