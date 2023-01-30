using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Transaction;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, IEnumerable<GetTransactionQueryResponse>>
    {
        private readonly ILogger<GetTransactionQueryHandler> _logger;
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionQueryHandler(ILogger<GetTransactionQueryHandler> logger, ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<GetTransactionQueryResponse>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            var listagem = await _transactionRepository.GetAccountByNumber(TransactionDTO.MappingFromModel(request));
            var grid = GridResponse<Transaction>.Get(listagem, "1", 3);
            return grid
                    .Select(x => GetTransactionQueryResponse.MappingFromModel(x));
        }
    }
}