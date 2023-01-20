using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface IAccountRepository
    {
        Task<AccountModel> Get(AccountDTO conta);

        //Task<AccountModel> GetAccountByNumber(AccountDTO conta);

        Task<AccountModel> Insert(AccountDTO conta);

        Task<AccountModel> Update(AccountDTO conta);

        Task<AccountModel> Delete(AccountDTO conta);
    }

    public interface IClientRepository
    {
        Task<ClientModel> Get(ClientDTO conta);

        Task<ClientModel> Insert(ClientDTO conta);

        Task<ClientModel> Update(ClientDTO conta);

        Task<ClientModel> Delete(ClientDTO conta);
    }

    public interface IEnterpriseRepository
    {
        Task<EnterpriseModel> Get(EnterpriseDTO conta);

        Task<EnterpriseModel> Insert(EnterpriseDTO conta);

        Task<EnterpriseModel> Update(EnterpriseDTO conta);

        Task<EnterpriseModel> Delete(EnterpriseDTO conta);
    }
}