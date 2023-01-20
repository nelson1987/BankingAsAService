using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using System.Threading.Tasks;

namespace Baas.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public Task<ClientModel> Delete(ClientDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<ClientModel> Get(ClientDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<ClientModel> Insert(ClientDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<ClientModel> Update(ClientDTO conta)
        {
            throw new System.NotImplementedException();
        }
    }
}