using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Entities
{
    public class CriarContaCorrenteCommandHandler : IRequestHandler<CriarContaCorrenteCommand, CriarContaCorrenteCommandResponse>
    {
        public async Task<CriarContaCorrenteCommandResponse> Handle(CriarContaCorrenteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
