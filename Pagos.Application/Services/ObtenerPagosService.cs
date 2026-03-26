using Pagos.Application.DTO;
using Pagos.Application.Interfaces;
using Pagos.Domain.Models;

namespace Pagos.Application.Services
{
    public class ObtenerPagosService
    {
        private readonly IPagoRepository _repo;

        public ObtenerPagosService(IPagoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ObtenerPagoDto>> Ejecutar(int clienteId)
        {
            var pagos = await _repo.ObtenerPorCliente(clienteId);

            return pagos.Select(p => new ObtenerPagoDto
            {
                TipoPago = p.TipoPago,
                Cuenta = p.Cuenta,
                Valor = p.Valor
            }).ToList();
        }
    }
}
