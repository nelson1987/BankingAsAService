using System;

namespace Baas.Domain.Events
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
    //public class ContaAbertaEventService :
    //    BackgroundService
    //{
    //    readonly IBus _bus;

    //    public ContaAbertaEventService(IBus bus)
    //    {
    //        _bus = bus;
    //    }

    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        while (!stoppingToken.IsCancellationRequested)
    //        {
    //            //_bus.Address = "Conta-Aberta-Event";
    //            await _bus.Publish(new ContaAbertaEvent { Numero = "World" }, stoppingToken);
    //            await Task.Delay(1000, stoppingToken);

    //        }
    //    }
    //}
    public class ContaAbertaEvent : IEvent
    {
        public Guid CorrelationId { get { return Guid.NewGuid(); } }

        public string QueueName { get { return "Conta-Aberta-Event"; } }

        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public string Agencia { get; set; }
    }
}