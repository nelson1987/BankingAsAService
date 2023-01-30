using MediatR;

namespace Baas.Domain.Entities
{
    public class SolicitarEmprestimoCommand : IRequest<SolicitarEmprestimoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
