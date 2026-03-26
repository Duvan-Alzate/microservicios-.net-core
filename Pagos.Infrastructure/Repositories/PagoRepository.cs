using Microsoft.EntityFrameworkCore;
using Pagos.Application.Interfaces;
using Pagos.Domain.Models;
using Pagos.Infrastructure.Data;

namespace Pagos.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly AppDbContext _context;

        public PagoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Crear(Pago pago)
        {
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pago>> ObtenerPorCliente(int clienteId)
        {
            return await _context.Pagos
                .Where(x => x.ClienteId == clienteId)
                .OrderByDescending(x => x.Fecha)
                .ToListAsync();
        }
    }
}
