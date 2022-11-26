using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class EncargadoChancho
    {
        public string CedulaEncargado { get; set; } = null!;
        public int IdentificadorChancho { get; set; }

        public virtual Encargado CedulaEncargadoNavigation { get; set; } = null!;
        public virtual Chancho IdentificadorChanchoNavigation { get; set; } = null!;
    }
}
