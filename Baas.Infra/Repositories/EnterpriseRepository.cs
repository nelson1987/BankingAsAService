using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using System.Threading.Tasks;

namespace Baas.Infra.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        public Task<EnterpriseModel> Delete(EnterpriseDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<EnterpriseModel> Get(EnterpriseDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<EnterpriseModel> Insert(EnterpriseDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<EnterpriseModel> Update(EnterpriseDTO conta)
        {
            throw new System.NotImplementedException();
        }
    }
}