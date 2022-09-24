using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Ejecucions = new HashSet<Ejecucion>();
            EmpleadoDepartamentos = new HashSet<EmpleadoDepartamento>();
        }

        public int CodigoDepartamento { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ManagerDepartamento? ManagerDepartamento { get; set; }
        public virtual ICollection<Ejecucion> Ejecucions { get; set; }
        public virtual ICollection<EmpleadoDepartamento> EmpleadoDepartamentos { get; set; }
    }
}
