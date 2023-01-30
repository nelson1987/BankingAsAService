using Baas.Domain.Repositories.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAccountByNumber(TransactionDTO conta);

        Task<Transaction> CreateAccount(TransactionDTO accountDTO);
    }
}