using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class EstadoTarea
    {
        public EstadoTarea()
        {
            TareaCasos = new HashSet<TareaCaso>();
            TareaClientes = new HashSet<TareaCliente>();
            TareaContactos = new HashSet<TareaContacto>();
            TareaCotizacions = new HashSet<TareaCotizacion>();
            TareaEjecucions = new HashSet<TareaEjecucion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<TareaCaso> TareaCasos { get; set; }
        public virtual ICollection<TareaCliente> TareaClientes { get; set; }
        public virtual ICollection<TareaContacto> TareaContactos { get; set; }
        public virtual ICollection<TareaCotizacion> TareaCotizacions { get; set; }
        public virtual ICollection<TareaEjecucion> TareaEjecucions { get; set; }
    }
}
