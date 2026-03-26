using Clientes.Application.Interfaces;
using Clientes.Domain.Models;
using Clientes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Crear(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task<Cliente?> ObtenerPorId(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
