using Baas.Domain.Repositories;
using Baas.Domain.Repositories.DTOs;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Account.Create
{
    public class CreateAccountCommand : IRequest<CreateAccountResponse>
    {
        public int IdEnterpriseAccount { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
    }

    public class CreateAccountResponse
    {
        public string Number { get; set; }
        public static CreateAccountResponse MappingFromModel(AccountModel criacaoContaResponse)
        {
            throw new NotImplementedException();
        }
    }

    public class CreateAccountEvent : INotification
    {
    }

    public class AccountModel
    {
        public string BankCode { get; set; }
        public string Number { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string IdCliente { get; set; }
    }

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