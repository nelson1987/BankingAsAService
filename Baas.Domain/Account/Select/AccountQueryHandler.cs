using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Account.Create
{
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
            var contaResponse = await _accountRepository.Get(AccountDTO.MappingFromModel(request));
            if (contaResponse == null)
                throw new System.NotImplementedException();
            return AccountQueryResponse.MappingFromModel(contaResponse);
        }
    }
}