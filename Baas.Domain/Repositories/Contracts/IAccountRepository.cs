using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface IAccountRepository
    {
        Task<AccountModel> GetAccount(AccountDTO conta);

        Task<AccountModel> GetAccountByNumber(AccountDTO conta);

        Task<AccountModel> CreateAccount(AccountDTO conta);
    }
}