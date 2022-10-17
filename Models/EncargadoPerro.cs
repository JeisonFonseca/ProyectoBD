using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class EncargadoPerro
    {
        public string CedulaEncargado { get; set; } = null!;
        public string IdentificadorPerro { get; set; } = null!;
        public int Sexo { get; set; }
        public DateTime? FechaLlegada { get; set; }

        public virtual Encargado CedulaEncargadoNavigation { get; set; } = null!;
        public virtual Perro IdentificadorPerroNavigation { get; set; } = null!;
        public virtual Sexo SexoNavigation { get; set; } = null!;
    }
}
