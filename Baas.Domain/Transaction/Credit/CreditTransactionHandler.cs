using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Tramsaction.Credit
{
    public class CreditTransactionHandler : IRequestHandler<CreditTransactionCommand, CreditTransactionResponse>
    {
        private readonly ILogger<CreditTransactionHandler> _logger;

        public Task<CreditTransactionResponse> Handle(CreditTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}