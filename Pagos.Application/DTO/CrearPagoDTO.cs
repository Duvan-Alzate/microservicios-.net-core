using System.ComponentModel.DataAnnotations;

namespace Pagos.Application.DTO
{
    public class CrearPagoDTO
    {
        [Required]
        public required string TipoPago { get; set; } // Credito / Debito

        [Required]
        public required string Cuenta { get; set; }

        [Required]
        public required decimal Valor { get; set; }

        public string? Descripcion { get; set; }

        [Required]
        public required int ClienteId { get; set; }
    }
}
