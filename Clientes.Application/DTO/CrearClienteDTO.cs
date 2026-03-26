using System.ComponentModel.DataAnnotations;

namespace Clientes.Application.DTO
{
    public class CrearClienteDTO
    {
        [Required(ErrorMessage = "El documento es obligatorio")]
        public required string Documento { get; set; }

        [Required]
        public required string TipoDocumento { get; set; } // CC, TI, etc

        [Required(ErrorMessage = "Nombres obligatorios")]
        public required string Nombres { get; set; }

        [Required(ErrorMessage = "Apellidos obligatorios")]
        public required string Apellidos { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public required string Email { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo números")]
        public string Celular { get; set; }

        [Required]
        public required string NumeroCuenta { get; set; }

        [Required]
        public required string TipoCuenta { get; set; } // Ahorros / Corriente
    }
}
