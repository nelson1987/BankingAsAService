using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface IEnterpriseRepository
    {
        Task<Enterprise> Get(EnterpriseDTO conta);

        Task<Enterprise> Insert(EnterpriseDTO conta);

        Task<Enterprise> Update(EnterpriseDTO conta);

        Task<Enterprise> Delete(EnterpriseDTO conta);
    }
}