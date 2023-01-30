using MediatR;

namespace Baas.Domain.Commands
{
    public class TransferirContaCorrenteCommand : IRequest<TransferirContaCorrenteCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
