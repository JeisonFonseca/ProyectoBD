using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Encargado
    {
        public Encargado()
        {
            CedulaEmpleados = new HashSet<Empleado>();
        }

        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apelllido2 { get; set; } = null!;

        public virtual EncargadoAve? EncargadoAve { get; set; }
        public virtual EncargadoBovino? EncargadoBovino { get; set; }
        public virtual EncargadoChancho? EncargadoChancho { get; set; }
        public virtual EncargadoPerro? EncargadoPerro { get; set; }
        public virtual EncargadoPropiedad? EncargadoPropiedad { get; set; }

        public virtual ICollection<Empleado> CedulaEmpleados { get; set; }
    }
}
