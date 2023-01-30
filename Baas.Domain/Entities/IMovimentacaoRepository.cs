namespace Baas.Domain.Entities
{
    public interface IMovimentacaoRepository
    {
        Task<Movimentacao> AddAsync(Movimentacao entity);
    }
}