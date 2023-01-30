using Baas.Domain.Entities;
using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using System.Threading.Tasks;

namespace Baas.Infra.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        public Task<Enterprise> Delete(EnterpriseDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<Enterprise> Get(EnterpriseDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<Enterprise> Insert(EnterpriseDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<Enterprise> Update(EnterpriseDTO conta)
        {
            throw new System.NotImplementedException();
        }
    }
}