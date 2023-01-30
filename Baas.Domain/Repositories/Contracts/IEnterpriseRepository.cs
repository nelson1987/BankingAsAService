using System.Threading.Tasks;

namespace Baas.Domain.Repositories.Contracts
{
    public interface IEnterpriseRepository
    {
        Task<EnterpriseModel> Get(EnterpriseDTO conta);

        Task<EnterpriseModel> Insert(EnterpriseDTO conta);

        Task<EnterpriseModel> Update(EnterpriseDTO conta);

        Task<EnterpriseModel> Delete(EnterpriseDTO conta);
    }
}