using MediatR;

namespace Baas.Domain.Commands
{
    public class TransferirPontosCartaoCreditoCommand : IRequest<TransferirPontosCartaoCreditoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
