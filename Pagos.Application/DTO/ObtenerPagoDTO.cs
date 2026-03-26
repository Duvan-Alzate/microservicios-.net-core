namespace Pagos.Application.DTO
{
    public class ObtenerPagoDto
    {
        public string TipoPago { get; set; }
        public string Cuenta { get; set; }
        public decimal Valor { get; set; }
    }
}
