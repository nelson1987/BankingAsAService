using MediatR;

namespace Baas.Domain.Entities
{
    public class DepositarContaCorrenteCommand : IRequest<DepositarContaCorrenteCommandResponse>
    {
        public string NumeroConta { get; set; }
        public decimal Valor { get; set; }
    }
}
