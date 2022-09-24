using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Probabilidad
    {
        public Probabilidad()
        {
            Cotizacions = new HashSet<Cotizacion>();
        }

        public int Id { get; set; }
        public double Valor { get; set; }

        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
    }
}
