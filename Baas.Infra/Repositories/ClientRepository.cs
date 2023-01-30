using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using System.Threading.Tasks;

namespace Baas.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MyDbContext _context;

        public ClienteRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Buscar(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Inserir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }
    }
}