using Baas.Domain.Entities;
using Baas.Domain.Repositories.DTOs;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface IAccountRepository
    {
        Task<Entities.Account> Insert(AccountDTO conta);

        Task<Entities.Account> Update(AccountDTO conta);

        Task<Entities.Account> Delete(AccountDTO conta);
    }

    //public interface IClientRepository
    //{
    //    Task<ClientModel> Get(ClientDTO conta);

    //    Task<ClientModel> Insert(ClientDTO conta);

    //    Task<ClientModel> Update(ClientDTO conta);

    //    Task<ClientModel> Delete(ClientDTO conta);
    //}

    //public interface IEnterpriseRepository
    //{
    //    Task<EnterpriseModel> Get(EnterpriseDTO conta);

    //    Task<EnterpriseModel> Insert(EnterpriseDTO conta);

    //    Task<EnterpriseModel> Update(EnterpriseDTO conta);

    //    Task<EnterpriseModel> Delete(EnterpriseDTO conta);
    //}
}