using MediatR;

namespace Baas.Domain.Entities
{
    public class TransferirPontosCartaoCreditoCommand : IRequest<TransferirPontosCartaoCreditoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
