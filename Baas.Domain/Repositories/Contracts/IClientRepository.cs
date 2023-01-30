using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface IClientRepository
    {
        Task<Client> Get(ClientDTO conta);

        Task<Client> Insert(ClientDTO conta);

        Task<Client> Update(ClientDTO conta);

        Task<Client> Delete(ClientDTO conta);
    }
}