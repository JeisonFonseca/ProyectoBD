using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class MotivoContacto
    {
        public MotivoContacto()
        {
            Contactos = new HashSet<Contacto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Contacto> Contactos { get; set; }
    }
}
