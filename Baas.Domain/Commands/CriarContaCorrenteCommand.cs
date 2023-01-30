using Baas.Domain.Responses;
using MediatR;

namespace Baas.Domain.Commands
{
    public class ComprarCartaoCreditoCommandResponse { }
    public class PagarFaturaCartaoCreditoCommandResponse { }
    public class TransferirPontosCartaoCreditoCommandResponse { }
    public class SacarContaCorrenteCommandResponse { }
    public class TransferirContaCorrenteCommandResponse { }
    public class SolicitarEmprestimoCommandResponse { }
    public class PagarParcelaEmprestimoCommandResponse { }
    public class AplicarInvestimentoCommandResponse { }
    public class ResgatarInvestimentoCommandResponse { }
    public class CalcularRendimentoInvestimentoCommandResponse { }

    public class CriarContaCorrenteCommand : IRequest<CriarContaCorrenteCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
