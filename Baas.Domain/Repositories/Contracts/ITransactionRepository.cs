using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionModel>> GetAccountByNumber(TransactionDTO conta);

        Task<TransactionModel> CreateAccount(TransactionDTO accountDTO);
    }
}