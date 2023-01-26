using Baas.Domain.Repositories.DTOs;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface ICreatedAccountEventRepository
    {
        Task<Entities.Account> Get(AccountDTO conta);

        Task Insert(AccountDTO conta);
    }
}