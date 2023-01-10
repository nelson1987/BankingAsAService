using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface ITransactionRepository
    {
        Task<AccountModel> GetAccountByNumber(TransactionDTO conta);
        Task<AccountModel> CreateAccount(TransactionDTO accountDTO);
    }
}
