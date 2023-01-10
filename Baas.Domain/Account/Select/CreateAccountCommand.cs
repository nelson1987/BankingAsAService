using Baas.Domain.Repositories;
using Baas.Domain.Repositories.DTOs;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Account.Create
{
    public class AccountQuery : IRequest<AccountQueryResponse>
    {
        public string Numero { get; set; }
        public string IdCliente { get; set; }
        public string IdEmpresa { get; set; }
    }

    public class AccountQueryResponse
    {
        public string Number { get; set; }
        public static AccountQueryResponse MappingFromModel(AccountModel criacaoContaResponse)
        {
            return new AccountQueryResponse()
            {
                Number = criacaoContaResponse.Number
            };
        }
    }

    public class AccountQueryHandler : IRequestHandler<AccountQuery, AccountQueryResponse>
    {
        private readonly IMediator _mediator;
        private readonly IAccountRepository _accountRepository;

        public AccountQueryHandler(IMediator mediator, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _mediator = mediator;
        }

        public async Task<AccountQueryResponse> Handle(AccountQuery request, CancellationToken cancellationToken)
        {
            var contaResponse = await _accountRepository.GetAccount(AccountDTO.MappingFromModel(request));
            if (contaResponse == null)
                throw new System.NotImplementedException();
            return AccountQueryResponse.MappingFromModel(contaResponse);
        }
    }
}