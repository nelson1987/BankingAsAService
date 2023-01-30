using Baas.Domain.Account.Create;
using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class AccountQueryHandler : IRequestHandler<AccountQuery, AccountQueryResponse>
    {
        private readonly IMediator _mediator;
        private readonly ICreatedAccountEventRepository _accountRepository;

        public AccountQueryHandler(IMediator mediator, ICreatedAccountEventRepository accountRepository)
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