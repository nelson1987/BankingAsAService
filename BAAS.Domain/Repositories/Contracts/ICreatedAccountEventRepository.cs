using Baas.Domain.Repositories.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface ICreatedAccountEventRepository
    {
        Task<IList<Entities.Account>> Get(AccountDTO conta);

        Task Insert(AccountDTO conta);
    }
}