namespace Baas.Domain.Entities
{
    public interface IContaRepository
    {
        Task<Conta> AddAsync(Conta entity);
    }
}