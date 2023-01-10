using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Account.Create
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        private readonly IMediator _mediator;
        private readonly IAccountRepository _accountRepository;

        public CreateAccountHandler(IMediator mediator, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _mediator = mediator;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            AccountModel contaResponse = await ValidarSeExiste(request);
            AccountModel criacaoContaResponse = await Inserir(request, contaResponse);
            Publicar();
            return CreateAccountResponse.MappingFromModel(criacaoContaResponse);
        }

        private async Task<AccountModel> ValidarSeExiste(CreateAccountCommand request)
        {
            var contaResponse = await _accountRepository.GetAccountByNumber(AccountDTO.MappingFromModel(request));
            if (contaResponse == null)
                throw new System.NotImplementedException();
            return contaResponse;
        }
        
        private async Task<AccountModel> Inserir(CreateAccountCommand request, AccountModel contaResponse)
        {
            var criacaoContaResponse = await _accountRepository.CreateAccount(AccountDTO.MappingFromModel(request));
            if (contaResponse == null)
                throw new System.NotImplementedException();
            return criacaoContaResponse;
        }
        
        private void Publicar()
        {
            var eventResponse = _mediator.Publish(new CreateAccountEvent());
            if (eventResponse.IsFaulted)
                throw new System.NotImplementedException();
        }
    }
}