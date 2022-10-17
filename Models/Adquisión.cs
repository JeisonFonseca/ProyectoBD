using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Adquisión
    {
        public Adquisión()
        {
            Bovinos = new HashSet<Bovino>();
        }

        public int Identificador { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Bovino> Bovinos { get; set; }
    }
}
