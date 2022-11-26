using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Bovino
    {
        public Bovino()
        {
            EncargadoBovinos = new HashSet<EncargadoBovino>();
            InverseMadreNavigation = new HashSet<Bovino>();
            InversePadreNavigation = new HashSet<Bovino>();
        }

        public int Identificador { get; set; }
        public string Nombre { get; set; } = null!;
        public int Raza { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Sexo { get; set; }
        public DateTime? FechaMonta { get; set; }
        public int? Madre { get; set; }
        public int? Padre { get; set; }
        public int TipoAdquisición { get; set; }
        public string? Dueno { get; set; }

        public virtual Encargado? DuenoNavigation { get; set; }
        public virtual Bovino? MadreNavigation { get; set; }
        public virtual Bovino? PadreNavigation { get; set; }
        public virtual Raza RazaNavigation { get; set; } = null!;
        public virtual Sexo SexoNavigation { get; set; } = null!;
        public virtual Adquisión TipoAdquisiciónNavigation { get; set; } = null!;
        public virtual ICollection<EncargadoBovino> EncargadoBovinos { get; set; }
        public virtual ICollection<Bovino> InverseMadreNavigation { get; set; }
        public virtual ICollection<Bovino> InversePadreNavigation { get; set; }
    }
}
