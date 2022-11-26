using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Encargado
    {
        public Encargado()
        {
            Bovinos = new HashSet<Bovino>();
            EncargadoBovinos = new HashSet<EncargadoBovino>();
            EncargadoChanchos = new HashSet<EncargadoChancho>();
            EncargadoPropiedads = new HashSet<EncargadoPropiedad>();
            CedulaEmpleados = new HashSet<Empleado>();
        }

        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;

        public virtual EncargadoAve? EncargadoAve { get; set; }
        public virtual EncargadoPerro? EncargadoPerro { get; set; }
        public virtual ICollection<Bovino> Bovinos { get; set; }
        public virtual ICollection<EncargadoBovino> EncargadoBovinos { get; set; }
        public virtual ICollection<EncargadoChancho> EncargadoChanchos { get; set; }
        public virtual ICollection<EncargadoPropiedad> EncargadoPropiedads { get; set; }

        public virtual ICollection<Empleado> CedulaEmpleados { get; set; }
    }
}
