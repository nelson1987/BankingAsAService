using AutoMapper;
using Baas.Domain.Commands;
using Baas.Domain.Entities;
using Baas.Domain.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class DepositarContaCorrenteCommandHandler : IRequestHandler<DepositarContaCorrenteCommand, DepositarContaCorrenteCommandResponse>
    {
        private IContaCorrenteRepository _contaCorrenteRepository { get; }
        private IMapper _mapper { get; }
        public DepositarContaCorrenteCommandHandler(IContaCorrenteRepository contaCorrenteRepository, IMapper map)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _mapper = map;
        }
        public async Task<DepositarContaCorrenteCommandResponse> Handle(DepositarContaCorrenteCommand request, CancellationToken cancellationToken)
        {
            /*
            ContaCorrente contaDeposito = await _contaCorrenteRepository.GetByNumber(request.NumeroConta);
            contaDeposito.Depositar(request.Valor);
            await _contaCorrenteRepository.Update(contaDeposito);
            //Executar o evento

            return _mapper.Map<DepositarContaCorrenteCommandResponse>(contaDeposito);
            */
            throw new NotImplementedException();
        }
    }
}
