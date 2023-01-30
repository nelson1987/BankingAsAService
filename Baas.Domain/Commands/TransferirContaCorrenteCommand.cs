using MediatR;

namespace Baas.Domain.Entities
{
    public class TransferirContaCorrenteCommand : IRequest<TransferirContaCorrenteCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
