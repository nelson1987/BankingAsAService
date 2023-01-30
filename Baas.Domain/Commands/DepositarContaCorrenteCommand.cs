using Baas.Domain.Responses;
using MediatR;

namespace Baas.Domain.Commands
{
    public class DepositarContaCorrenteCommand : IRequest<DepositarContaCorrenteCommandResponse>
    {
        public string NumeroConta { get; set; }
        public decimal Valor { get; set; }
    }
}
