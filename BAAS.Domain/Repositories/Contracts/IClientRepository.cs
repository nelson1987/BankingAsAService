using Baas.Domain.Entities;
using Baas.Domain.Repositories.DTOs;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface IClientRepository
    {
        Task<Cliente> Get(ClientDTO conta);

        Task<Cliente> Insert(ClientDTO conta);

        Task<Cliente> Update(ClientDTO conta);

        Task<Cliente> Delete(ClientDTO conta);
    }
}