using MediatR;
using System;
using System.Threading.Tasks;

namespace Baas.Domain.Entities
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        public Task<ContaCorrente> GetByNumber(string numeroConta)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Update(ContaCorrente contaDeposito)
        {
            throw new NotImplementedException();
        }
    }
}
