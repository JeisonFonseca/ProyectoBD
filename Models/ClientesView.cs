using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class ClientesView
    {
        public long Cedula { get; set; }
        public string NombreCuenta { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string? ContactoPrincipal { get; set; }
        public string Telefono { get; set; } = null!;
        public string SitioWeb { get; set; } = null!;
        public string? InformacionAdicional { get; set; }
        public string Moneda { get; set; } = null!;
        public string Sector { get; set; } = null!;
        public string Zona { get; set; } = null!;
        public string Usuario { get; set; } = null!;
    }
}
