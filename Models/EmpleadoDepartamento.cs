using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class EmpleadoDepartamento
    {
        public long CedulaEmpleado { get; set; }
        public int CodigoDepartamento { get; set; }

        public virtual Usuario CedulaEmpleadoNavigation { get; set; } = null!;
        public virtual Departamento CodigoDepartamentoNavigation { get; set; } = null!;
    }
}
