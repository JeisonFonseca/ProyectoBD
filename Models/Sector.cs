using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Sector
    {
        public Sector()
        {
            Clientes = new HashSet<Cliente>();
            Contactos = new HashSet<Contacto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Contacto> Contactos { get; set; }
    }
}
