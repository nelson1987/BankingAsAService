using System.Threading.Tasks;

namespace Baas.Domain.Entities
{
    public interface IContaRepository
    {
        Task<Conta> AddAsync(Conta entity);
    }
}