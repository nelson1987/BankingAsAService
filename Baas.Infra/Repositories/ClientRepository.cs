using Baas.Domain.Entities;
using Baas.Infra.DbContext;
using System.Threading.Tasks;

namespace Baas.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        /*
        private readonly DbSession _context;

        public ClienteRepository(DbSession context)
        {
            _context = context;
        }

        public Task Add(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Cliente> Buscar(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public Task<Cliente> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Inserir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            //await _context.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(object cliente)
        {
            throw new System.NotImplementedException();
        }
        */
        public Task Add(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> Buscar(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Inserir(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(object cliente)
        {
            throw new System.NotImplementedException();
        }
    }
}