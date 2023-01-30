using MediatR;
using System.Threading.Tasks;

namespace Baas.Domain.Entities
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> GetByNumber(string numeroConta);
        Task<Unit> Update(ContaCorrente contaDeposito);
    }
}
