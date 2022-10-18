using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            CedulaEncargados = new HashSet<Encargado>();
        }

        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string Rol { get; set; } = null!;

        public virtual ICollection<Encargado> CedulaEncargados { get; set; }
    }
}
