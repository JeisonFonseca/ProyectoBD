using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class OrigenCaso
    {
        public OrigenCaso()
        {
            Casos = new HashSet<Caso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Caso> Casos { get; set; }
    }
}
