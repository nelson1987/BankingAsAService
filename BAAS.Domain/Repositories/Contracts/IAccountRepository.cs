using Baas.Domain.Repositories.DTOs;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface IAccountRepository
    {
        Task<Entities.Account> Insert(AccountDTO conta);

        Task<Entities.Account> Update(AccountDTO conta);

        Task Delete(AccountDTO conta);
    }
}