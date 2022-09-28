using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Cotizacion
    {
        public Cotizacion()
        {
            ActividadCotizacions = new HashSet<ActividadCotizacion>();
            CotizacionProductos = new HashSet<CotizacionProducto>();
            TareaCotizacions = new HashSet<TareaCotizacion>();
        }

        public int CodigoCotizacion { get; set; }
        public string NombreCotizacion { get; set; } = null!;
        public DateTime FechaCotizacion { get; set; }
        public DateTime MesAnnoPrytadoCierre { get; set; }
        public long CedulaCuenta { get; set; }
        public DateTime? FechaCierreReal { get; set; }
        public int EtapaCotiza { get; set; }
        public int Moneda { get; set; }
        public int Probabilidad { get; set; }
        public int OrdenCompra { get; set; }
        public int TipoCotizacion { get; set; }
        public string? Descripcion { get; set; }
        public int Zona { get; set; }
        public int Sector { get; set; }
        public int Factura { get; set; }
        public int PorqueSeDenego { get; set; }
        public string? ContraQuien { get; set; }

        public virtual EtapaCotizacion EtapaCotizaNavigation { get; set; } = null!;
        public virtual Monedum MonedaNavigation { get; set; } = null!;
        public virtual PorQueSeDenego PorqueSeDenegoNavigation { get; set; } = null!;
        public virtual Probabilidad ProbabilidadNavigation { get; set; } = null!;
        public virtual TipoCotizacion TipoCotizacionNavigation { get; set; } = null!;
        public virtual CotizacionCliente? CotizacionCliente { get; set; }
        public virtual CotizacionEjecucion? CotizacionEjecucion { get; set; }
        public virtual ICollection<ActividadCotizacion> ActividadCotizacions { get; set; }
        public virtual ICollection<CotizacionProducto> CotizacionProductos { get; set; }
        public virtual ICollection<TareaCotizacion> TareaCotizacions { get; set; }
    }
}
