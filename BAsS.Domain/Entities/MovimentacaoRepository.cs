using System.Threading.Tasks;

namespace Baas.Domain.Entities
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        /*
        private readonly ApplicationDbContext _context;

        public MovimentacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movimentacao> AddAsync(Movimentacao entity)
        {
            await _context.Contas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        */
        public Task<Movimentacao> AddAsync(Movimentacao entity)
        {
            throw new System.NotImplementedException();
        }
    }
}