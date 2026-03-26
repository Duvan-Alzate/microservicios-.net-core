namespace Clientes.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string TipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public bool Estado { get; set; } = true;
    }
}
