using Baas.Domain.Events;
using Baas.Domain.Helpers;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BAAS.Domain.Consumers
{
    public class ContaAbertaConsumer :
        IConsumer<ContaAbertaEvent>
    {
        readonly ILogger<ContaAbertaConsumer> _logger;

        public ContaAbertaConsumer(ILogger<ContaAbertaConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<ContaAbertaEvent> context)
        {
            _logger.LogInformation("Value: {0}", context.Message.ToJson());
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
