using Pagos.Application.DTO;
using Pagos.Application.Interfaces;
using Pagos.Domain.Models;

namespace Pagos.Application.Services
{
    public class CrearPagoService
    {
        private readonly IPagoRepository _repo;

        public CrearPagoService(IPagoRepository repo)
        {
            _repo = repo;
        }

        public async Task Ejecutar(CrearPagoDTO dto)
        {
            if (dto.TipoPago.ToLower() != "crédito" && dto.TipoPago.ToLower() != "débito")
                throw new Exception("Tipo de pago inválido");

            if (dto.Valor <= 0)
                throw new Exception("Valor inválido");

            var pago = new Pago
            {
                ClienteId = dto.ClienteId,
                TipoPago = dto.TipoPago,
                Cuenta = dto.Cuenta,
                Valor = dto.Valor,
                Descripcion = dto.Descripcion
            };

            await _repo.Crear(pago);
        }
    }
}
