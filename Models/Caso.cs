using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Caso
    {
        public Caso()
        {
            ActividadCasos = new HashSet<ActividadCaso>();
            CasoEjecucions = new HashSet<CasoEjecucion>();
            TareaCasos = new HashSet<TareaCaso>();
        }

        public int Id { get; set; }
        public int PropietarioCaso { get; set; }
        public int NombreCuenta { get; set; }
        public int OrigenCaso { get; set; }
        public int EstadoCaso { get; set; }
        public string? NombreContacto { get; set; }
        public string Asunto { get; set; } = null!;
        public int Direccion { get; set; }
        public string Descripcion { get; set; } = null!;
        public int TipoCaso { get; set; }
        public int Prioridad { get; set; }

        public virtual Direccion DireccionNavigation { get; set; } = null!;
        public virtual EstadoCaso EstadoCasoNavigation { get; set; } = null!;
        public virtual OrigenCaso OrigenCasoNavigation { get; set; } = null!;
        public virtual Prioridad PrioridadNavigation { get; set; } = null!;
        public virtual Usuario PropietarioCasoNavigation { get; set; } = null!;
        public virtual TipoCaso TipoCasoNavigation { get; set; } = null!;
        public virtual ICollection<ActividadCaso> ActividadCasos { get; set; }
        public virtual ICollection<CasoEjecucion> CasoEjecucions { get; set; }
        public virtual ICollection<TareaCaso> TareaCasos { get; set; }
    }
}
