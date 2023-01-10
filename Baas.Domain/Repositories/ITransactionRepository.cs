using Baas.Domain.Account.Create;
using Baas.Domain.Repositories.DTOs;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<AccountModel> GetAccountByNumber(TransactionDTO conta);
        Task<AccountModel> CreateAccount(TransactionDTO accountDTO);
    }
}
