﻿using MediatR;

namespace Baas.Domain.Entities
{
    /*
    public class IncluirMovimentacaoHandler : IRequestHandler<IncluirMovimentacaoCommand, IncluirMovimentacaoResponse>
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<IncluirMovimentacaoHandler> _logger;
        private readonly IBusControl _bus;

        public IncluirMovimentacaoHandler(ITransactionRepository repository, IMapper mapper, ILogger<IncluirMovimentacaoHandler> logger, IBusControl bus)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _bus = bus;
        }

        public async Task<IncluirMovimentacaoResponse> Handle(IncluirMovimentacaoCommand request, CancellationToken cancellationToken)
        {
            var movimentacao = _mapper.Map<Movimentacao>(request);

            await _repository.AddAsync(movimentacao);

            try
            {
                await _bus.Publish(_mapper.Map<MovimentacaoIncluidaEvent>(movimentacao));
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao publicar evento de movimentação incluída");
            }

            return new IncluirMovimentacaoResponse();
        }
    }
    public class MovimentacaoQueryHandler : IRequestHandler<MovimentacaoQuery, MovimentacaoQueryResponse>
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<MovimentacaoQueryHandler> _logger;
        private readonly IBusControl _bus;

        public MovimentacaoQueryHandler(ITransactionRepository repository, IMapper mapper, ILogger<MovimentacaoQueryHandler> logger, IBusControl bus)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _bus = bus;
        }

        public async Task<MovimentacaoQueryResponse> Handle(MovimentacaoQuery request, CancellationToken cancellationToken)
        {
            var movimentacao = _mapper.Map<Movimentacao>(request);

            await _repository.AddAsync(movimentacao);

            try
            {
                await _bus.Publish(_mapper.Map<MovimentacaoIncluidaEvent>(movimentacao));
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao publicar evento de movimentação incluída");
            }

            return new MovimentacaoQueryResponse();
        }
    }
    */

    public class ContaAbertaEvent : INotification
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public string Agencia { get; set; }
        // public static ContaAbertaEvent MappingFromDTO() { }
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