using Baas.Domain.Responses;
using Baas.Domain.Validators;
using FluentValidation;
using MediatR;

namespace Baas.Domain.Commands
{
    public class AberturaContaCommand : IRequest<AberturaContaCommandResponse>
    {
        //public string CodigoCompe { get; set; }
        public string Tipo => "1";
        public int IdCliente => 1;
        public string Agencia { get; set; }
        //public int IdEnterpriseAccount { get; set; }
        //public string Name { get; set; }
        //public string Document { get; set; }

        public void Validate()
        {
            var result = new AberturaCommandValidator().Validate(this);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
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