using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Contacto
    {
        public Contacto()
        {
            ActividadContactos = new HashSet<ActividadContacto>();
            TareaContactos = new HashSet<TareaContacto>();
        }

        public int Id { get; set; }
        public int Cliente { get; set; }
        public int TipoContacto { get; set; }
        public int MotivoContacto { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public int Direccion { get; set; }
        public int Sector { get; set; }
        public int Zona { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual Cliente ClienteNavigation { get; set; } = null!;
        public virtual Direccion DireccionNavigation { get; set; } = null!;
        public virtual MotivoContacto MotivoContactoNavigation { get; set; } = null!;
        public virtual Sector SectorNavigation { get; set; } = null!;
        public virtual TipoContacto TipoContactoNavigation { get; set; } = null!;
        public virtual Zona ZonaNavigation { get; set; } = null!;
        public virtual ContactoCliente? ContactoCliente { get; set; }
        public virtual ICollection<ActividadContacto> ActividadContactos { get; set; }
        public virtual ICollection<TareaContacto> TareaContactos { get; set; }
    }
}
