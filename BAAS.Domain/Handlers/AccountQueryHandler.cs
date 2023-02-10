using Baas.Domain.Account.Create;
using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class AccountQueryHandler : IRequestHandler<AccountQuery, IList<AccountQueryResponse>>
    {
        private readonly ICreatedAccountEventRepository _accountRepository;

        public AccountQueryHandler(ICreatedAccountEventRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IList<AccountQueryResponse>> Handle(AccountQuery request, CancellationToken cancellationToken)
        {
            IList<Entities.Account> contaResponse = await _accountRepository.Get(AccountDTO.MappingFromModel(request));
            if (contaResponse == null)
                throw new System.NotImplementedException();
            return contaResponse
                .Select(x => AccountQueryResponse.MappingFromModel(x))
                .ToList();
        }
    }
}