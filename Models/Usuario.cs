using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ActividadCasos = new HashSet<ActividadCaso>();
            ActividadClientes = new HashSet<ActividadCliente>();
            ActividadContactos = new HashSet<ActividadContacto>();
            ActividadCotizacions = new HashSet<ActividadCotizacion>();
            ActividadEjecucions = new HashSet<ActividadEjecucion>();
            Casos = new HashSet<Caso>();
            Clientes = new HashSet<Cliente>();
            ContactoClientes = new HashSet<ContactoCliente>();
            CotizacionClientes = new HashSet<CotizacionCliente>();
            EjecucionAsesorNavigations = new HashSet<Ejecucion>();
            EjecucionPropietarioEjecucionNavigations = new HashSet<Ejecucion>();
            ManagerDepartamentos = new HashSet<ManagerDepartamento>();
            TareaCasos = new HashSet<TareaCaso>();
            TareaClientes = new HashSet<TareaCliente>();
            TareaContactos = new HashSet<TareaContacto>();
            TareaCotizacions = new HashSet<TareaCotizacion>();
            TareaEjecucions = new HashSet<TareaEjecucion>();
        }

        public int Cedula { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apelllido2 { get; set; } = null!;
        public int Rol { get; set; }

        public virtual Rol RolNavigation { get; set; } = null!;
        public virtual EmpleadoDepartamento? EmpleadoDepartamento { get; set; }
        public virtual ICollection<ActividadCaso> ActividadCasos { get; set; }
        public virtual ICollection<ActividadCliente> ActividadClientes { get; set; }
        public virtual ICollection<ActividadContacto> ActividadContactos { get; set; }
        public virtual ICollection<ActividadCotizacion> ActividadCotizacions { get; set; }
        public virtual ICollection<ActividadEjecucion> ActividadEjecucions { get; set; }
        public virtual ICollection<Caso> Casos { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<ContactoCliente> ContactoClientes { get; set; }
        public virtual ICollection<CotizacionCliente> CotizacionClientes { get; set; }
        public virtual ICollection<Ejecucion> EjecucionAsesorNavigations { get; set; }
        public virtual ICollection<Ejecucion> EjecucionPropietarioEjecucionNavigations { get; set; }
        public virtual ICollection<ManagerDepartamento> ManagerDepartamentos { get; set; }
        public virtual ICollection<TareaCaso> TareaCasos { get; set; }
        public virtual ICollection<TareaCliente> TareaClientes { get; set; }
        public virtual ICollection<TareaContacto> TareaContactos { get; set; }
        public virtual ICollection<TareaCotizacion> TareaCotizacions { get; set; }
        public virtual ICollection<TareaEjecucion> TareaEjecucions { get; set; }
    }
}
