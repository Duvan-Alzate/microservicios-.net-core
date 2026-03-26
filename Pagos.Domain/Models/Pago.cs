using Pagos.Domain.Enums;

namespace Pagos.Domain.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string TipoPago { get; set; }
        public string Cuenta { get; set; }
        public decimal Valor { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
