using Baas.Domain.Account.Create;
using Baas.Domain.Repositories.DTOs;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<AccountModel> GetAccount(AccountDTO conta);
        Task<AccountModel> GetAccountByNumber(AccountDTO conta);
        Task<AccountModel> CreateAccount(AccountDTO conta);
    }
}
