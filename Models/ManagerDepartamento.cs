using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class ManagerDepartamento
    {
        public int CedulaEmpleadoManager { get; set; }
        public int CodigoDepartamento { get; set; }

        public virtual Usuario CedulaEmpleadoManagerNavigation { get; set; } = null!;
        public virtual Departamento CodigoDepartamentoNavigation { get; set; } = null!;
    }
}
