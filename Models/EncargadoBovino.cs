using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class EncargadoBovino
    {
        public string CedulaEncargado { get; set; } = null!;
        public int IdentificadorBovino { get; set; }

        public virtual Encargado CedulaEncargadoNavigation { get; set; } = null!;
        public virtual Bovino IdentificadorBovinoNavigation { get; set; } = null!;
    }
}
