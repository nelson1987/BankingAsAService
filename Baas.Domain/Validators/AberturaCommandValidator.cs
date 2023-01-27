using Baas.Domain.Commands;
using FluentValidation;

namespace Baas.Domain.Entities
{
    public class AberturaCommandValidator : AbstractValidator<AberturaContaCommand>
    {
        public AberturaCommandValidator()
        {
        //    RuleFor(x => x.Agencia)
        //        .Matches(@"^[0-9]{4}$")
        //        .WithMessage("A agência deve conter 4 caracteres numéricos.");
        //
        //    RuleFor(x => x.CodigoCompe)
        //        .Matches(@"^[0-9]{3}$")
        //        .WithMessage("O código compe deve conter 3 caracteres numéricos.");
        }
    }

    //public class ContaRepository : IContaRepository
    //{
    //    private readonly ApplicationDbContext _context;

    //    public ContaRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<Conta> AddAsync(Conta entity)
    //    {
    //        await _context.Contas.AddAsync(entity);
    //        await _context.SaveChangesAsync();
    //        return entity;
    //    }
    //}
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