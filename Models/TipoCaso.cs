using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class TipoCaso
    {
        public TipoCaso()
        {
            Casos = new HashSet<Caso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Caso> Casos { get; set; }
    }
}
