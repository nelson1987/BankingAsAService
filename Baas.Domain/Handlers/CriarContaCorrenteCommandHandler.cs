using Baas.Domain.Commands;
using Baas.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
    public class CriarContaCorrenteCommandHandler : IRequestHandler<CriarContaCorrenteCommand, CriarContaCorrenteCommandResponse>
    {
        public async Task<CriarContaCorrenteCommandResponse> Handle(CriarContaCorrenteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
