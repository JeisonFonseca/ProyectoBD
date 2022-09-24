using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class EstadoContacto
    {
        public EstadoContacto()
        {
            ContactoClientes = new HashSet<ContactoCliente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<ContactoCliente> ContactoClientes { get; set; }
    }
}
