using System;
using System.ComponentModel.DataAnnotations;

namespace GaleriadeArte
{
	public class Artista
	{
		public long? Id { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio")]
		[StringLength(120, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 120 caracteres")]
		public string Nombre { get; set; }

		[StringLength(60, ErrorMessage = "La nacionalidad no puede exceder 60 caracteres")]
		public string Nacionalidad { get; set; }

		public DateTime? FechaNacimiento { get; set; }

		[StringLength(80, ErrorMessage = "El estilo principal no puede exceder 80 caracteres")]
		public string EstiloPrincipal { get; set; }

		public bool Activo { get; set; } = true;

		[EmailAddress(ErrorMessage = "El formato del email no es válido")]
		[StringLength(150, ErrorMessage = "El email no puede exceder 150 caracteres")]
		public string Email { get; set; }

		public DateTime? FechaRegistro { get; set; }
	}
}