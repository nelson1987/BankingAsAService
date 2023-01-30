using AutoMapper;
using Baas.Domain.Commands;
using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Responses;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class AberturaContaCommandHandler : IRequestHandler<AberturaContaCommand, AberturaContaCommandResponse>
    {
        private readonly ILogger<AberturaContaCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IBus _bus;
        private readonly IAccountRepository _contaRepository;

        public AberturaContaCommandHandler(ILogger<AberturaContaCommandHandler> logger, IMapper mapper, IBus bus, IAccountRepository contaRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _bus = bus;
            _contaRepository = contaRepository;
        }

        public async Task<AberturaContaCommandResponse> Handle(AberturaContaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                _logger.LogInformation("Iniciando a abertura de conta {@request}", request);

                AccountDTO conta = _mapper.Map<AccountDTO>(request);
                conta.Numero = GetNumeroConta();

                await _contaRepository.Insert(conta);

                _logger.LogInformation("Conta {Numero} aberta com sucesso.", conta.Numero);
                //TODO: Criar Evento
                //try
                //{
                //    await _bus.Publish<ContaAbertaEvent>(_mapper.Map<ContaAbertaEvent>(conta));
                //    _logger.LogInformation("Evento de conta aberta publicado com sucesso");
                //}
                //catch (Exception ex)
                //{
                //    _logger.LogError(ex, "Ocorreu um erro ao publicar o evento de conta aberta");
                //}
                return _mapper.Map<AberturaContaCommandResponse>(conta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao publicar o evento de conta aberta");
                throw new TaskCanceledException();
            }
        }
        private string GetNumeroConta()
        {
            Random rand = new Random();
            string numericString = "";
            for (int i = 0; i < 10; i++)
            {
                numericString += rand.Next(10).ToString();
            }
            return numericString;
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