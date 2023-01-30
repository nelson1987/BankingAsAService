using Baas.Domain.Commands;
using Baas.Domain.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class DebitTransactionHandler : IRequestHandler<DebitTransactionCommand, DebitTransactionResponse>
    {
        private readonly ILogger<DebitTransactionHandler> _logger;

        public Task<DebitTransactionResponse> Handle(DebitTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}