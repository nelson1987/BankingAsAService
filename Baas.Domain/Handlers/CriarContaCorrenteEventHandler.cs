using Baas.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class CriarContaCorrenteEventHandler : INotificationHandler<CriarContaCorrenteEvent>
    {
        public Task Handle(CriarContaCorrenteEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
