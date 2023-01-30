using MediatR;

namespace Baas.Domain.Entities
{
    public class SacarContaCorrenteCommand : IRequest<SacarContaCorrenteCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
