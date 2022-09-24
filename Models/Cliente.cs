using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ActividadClientes = new HashSet<ActividadCliente>();
            Contactos = new HashSet<Contacto>();
            CotizacionClientes = new HashSet<CotizacionCliente>();
            TareaClientes = new HashSet<TareaCliente>();
        }

        public int Cedula { get; set; }
        public string NombreCuenta { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string? ContactoPrincipal { get; set; }
        public string Telefono { get; set; } = null!;
        public string SitioWeb { get; set; } = null!;
        public string? InformacionAdicional { get; set; }
        public int Moneda { get; set; }
        public int Sector { get; set; }
        public int Zona { get; set; }
        public int Asesor { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Monedum MonedaNavigation { get; set; } = null!;
        public virtual Sector SectorNavigation { get; set; } = null!;
        public virtual Zona ZonaNavigation { get; set; } = null!;
        public virtual ICollection<ActividadCliente> ActividadClientes { get; set; }
        public virtual ICollection<Contacto> Contactos { get; set; }
        public virtual ICollection<CotizacionCliente> CotizacionClientes { get; set; }
        public virtual ICollection<TareaCliente> TareaClientes { get; set; }
    }
}
