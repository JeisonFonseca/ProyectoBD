using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Required]
        public int Cedula { get; set; }

        [Required]
        public string NombreUsuario { get; set; } = null!;

        [Required]
        public string Clave { get; set; } = null!;

        [Required]
        public string Nombre { get; set; } = null!;

        [Required]
        public string Apellido1 { get; set; } = null!;

        [Required]
        public string Apelllido2 { get; set; } = null!;

        [Required]
        public int Rol { get; set; }
    }
}
