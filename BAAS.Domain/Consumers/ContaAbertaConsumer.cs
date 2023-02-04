using Baas.Domain.Events;
using Baas.Domain.Helpers;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BAAS.Domain.Consumers
{
    public class ContaAbertaConsumer :
        IConsumer<ContaAbertaEvent>
    {
        readonly ILogger<ContaAbertaConsumer> _logger;
        readonly IMediator _mediator;

        public ContaAbertaConsumer(ILogger<ContaAbertaConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<ContaAbertaEvent> context)
        {
            try
            {
                var resultado = await _mediator.Send(new ContaAbertaEventSync()
                {
                    Numero = context.Message.Numero,
                    Id = context.Message.Id,
                    Agencia = context.Message.Agencia,
                    IdCliente = context.Message.IdCliente,
                    Tipo = context.Message.Tipo
                });
                _logger.LogInformation("Value: {0}", context.Message.ToJson());
            }
            catch (Exception ex)
            {
                throw new Exception($"Problema ao realizar uma inserção: {ex.Message}");
            }
        }
    }

    public class ContaAbertaConsumerDefinition :
        ConsumerDefinition<ContaAbertaConsumer>
    {
        public ContaAbertaConsumerDefinition()
        {
            // override the default endpoint name
            EndpointName = "pagamento-realizado";

            // limit the number of messages consumed concurrently
            // this applies to the consumer only, not the endpoint
            ConcurrentMessageLimit = 8;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<ContaAbertaConsumer> consumerConfigurator)
        {
            // configure message retry with millisecond intervals
            endpointConfigurator.UseMessageRetry(r => r.Intervals(5, 10, 100, 200, 500, 800, 1000));

            // use the outbox to prevent duplicate events from being published
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}
