using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Aves = new HashSet<Ave>();
            Bovinos = new HashSet<Bovino>();
            Chanchos = new HashSet<Chancho>();
            EncargadoAves = new HashSet<EncargadoAve>();
            EncargadoPerros = new HashSet<EncargadoPerro>();
            Perros = new HashSet<Perro>();
        }

        public int Identificador { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Ave> Aves { get; set; }
        public virtual ICollection<Bovino> Bovinos { get; set; }
        public virtual ICollection<Chancho> Chanchos { get; set; }
        public virtual ICollection<EncargadoAve> EncargadoAves { get; set; }
        public virtual ICollection<EncargadoPerro> EncargadoPerros { get; set; }
        public virtual ICollection<Perro> Perros { get; set; }
    }
}
