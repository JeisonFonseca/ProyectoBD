using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Direccion
    {
        public Direccion()
        {
            Casos = new HashSet<Caso>();
            Contactos = new HashSet<Contacto>();
        }

        public int Id { get; set; }
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public string Sennas { get; set; } = null!;

        public virtual ICollection<Caso> Casos { get; set; }
        public virtual ICollection<Contacto> Contactos { get; set; }
    }
}
