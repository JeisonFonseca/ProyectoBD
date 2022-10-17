using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class BovinoProduccion
    {
        public int IdentificadorBovino { get; set; }
        public int IdentificadorProduccion { get; set; }

        public virtual Bovino IdentificadorBovinoNavigation { get; set; } = null!;
        public virtual ProduccionLeche IdentificadorProduccionNavigation { get; set; } = null!;
    }
}
