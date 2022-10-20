﻿using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.ViewModels
{
    public class BovinoViewModel
    {
        [Required]
        public int Identificador { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        [Required]
        public string Raza { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        [Required]
        public int Sexo { get; set; }

        public DateTime? FechaMonta { get; set; }


        public int? Madre { get; set; }
        public int? Padre { get; set; }

        [Required]
        public int TipoAdquisición { get; set; }
    }
}