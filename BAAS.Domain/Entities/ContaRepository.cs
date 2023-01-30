using System.Threading.Tasks;

namespace Baas.Domain.Entities
{
    public class ContaRepository : IContaRepository
    {
        /*
        private readonly ApplicationDbContext _context;

        public ContaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Conta> AddAsync(Conta entity)
        {
            await _context.Contas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        */
        public Task<Conta> AddAsync(Conta entity)
        {
            throw new System.NotImplementedException();
        }
    }
    //public class MovimentacaoRepository : IMovimentacaoRepository
    //{
    //    private readonly ApplicationDbContext _context;

    //    public MovimentacaoRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<Movimentacao> AddAsync(Movimentacao entity)
    //    {
    //        await _context.Contas.AddAsync(entity);
    //        await _context.SaveChangesAsync();
    //        return entity;
    //    }
    //}

    //public interface IContaRepository
    //{
    //    Task<Conta> AddAsync(Conta entity);
    //}
    //public interface IMovimentacaoRepository
    //{
    //    Task<Movimentacao> AddAsync(Movimentacao entity);
    //}
}