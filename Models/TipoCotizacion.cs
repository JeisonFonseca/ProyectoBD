using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class TipoCotizacion
    {
        public TipoCotizacion()
        {
            Cotizacions = new HashSet<Cotizacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
    }
}
