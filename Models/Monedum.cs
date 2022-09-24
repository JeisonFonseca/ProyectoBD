using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Monedum
    {
        public Monedum()
        {
            Clientes = new HashSet<Cliente>();
            Cotizacions = new HashSet<Cotizacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public double Valor { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
    }
}
