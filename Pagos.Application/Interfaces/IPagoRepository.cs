using Pagos.Domain.Models;

namespace Pagos.Application.Interfaces
{
    public interface IPagoRepository
    {
        Task Crear(Pago pago);
        Task<List<Pago>> ObtenerPorCliente(int clienteId);
    }
}
