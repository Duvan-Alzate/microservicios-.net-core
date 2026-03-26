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

        public async Task<List<Pago>> Ejecutar(int clienteId)
        {
            return await _repo.ObtenerPorCliente(clienteId);
        }
    }
}
