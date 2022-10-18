using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Encargado
    {
        public Encargado()
        {
            EncargadoPropiedads = new HashSet<EncargadoPropiedad>();
            CedulaEmpleados = new HashSet<Empleado>();
            IdentificadorBovinos = new HashSet<Bovino>();
        }

        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;

        public virtual EncargadoAve? EncargadoAve { get; set; }
        public virtual EncargadoChancho? EncargadoChancho { get; set; }
        public virtual EncargadoPerro? EncargadoPerro { get; set; }
        public virtual ICollection<EncargadoPropiedad> EncargadoPropiedads { get; set; }

        public virtual ICollection<Empleado> CedulaEmpleados { get; set; }
        public virtual ICollection<Bovino> IdentificadorBovinos { get; set; }
    }
}
