using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Ejecucion
    {
        public Ejecucion()
        {
            ActividadEjecucions = new HashSet<ActividadEjecucion>();
            CotizacionEjecucions = new HashSet<CotizacionEjecucion>();
            TareaEjecucions = new HashSet<TareaEjecucion>();
        }

        public int Id { get; set; }
        public int Departamento { get; set; }
        public long PropietarioEjecucion { get; set; }
        public string NombreEjecucion { get; set; } = null!;
        public DateTime FechaEjecucion { get; set; }
        public long NombreCuenta { get; set; }
        public DateTime MAProyCierre { get; set; }
        public long Asesor { get; set; }
        public DateTime? FechaCierreReal { get; set; }

        public virtual Usuario AsesorNavigation { get; set; } = null!;
        public virtual Departamento DepartamentoNavigation { get; set; } = null!;
        public virtual Usuario PropietarioEjecucionNavigation { get; set; } = null!;
        public virtual CasoEjecucion? CasoEjecucion { get; set; }
        public virtual ICollection<ActividadEjecucion> ActividadEjecucions { get; set; }
        public virtual ICollection<CotizacionEjecucion> CotizacionEjecucions { get; set; }
        public virtual ICollection<TareaEjecucion> TareaEjecucions { get; set; }
    }
}
