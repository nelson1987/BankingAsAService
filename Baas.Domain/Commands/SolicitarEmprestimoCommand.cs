using MediatR;

namespace Baas.Domain.Commands
{
    public class SolicitarEmprestimoCommand : IRequest<SolicitarEmprestimoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
