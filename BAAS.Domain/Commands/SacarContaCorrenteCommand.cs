using MediatR;

namespace Baas.Domain.Commands
{
    public class SacarContaCorrenteCommand : IRequest<SacarContaCorrenteCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
