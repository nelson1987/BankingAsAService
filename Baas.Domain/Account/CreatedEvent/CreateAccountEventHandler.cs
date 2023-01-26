using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Account.CreatedAccount
{
    public class CreateAccountEventHandler : INotificationHandler<CreatedAccountEvent>
    {
        private readonly ICreatedAccountEventRepository _repository;

        public CreateAccountEventHandler(ICreatedAccountEventRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreatedAccountEvent notification, CancellationToken cancellationToken)
        {
            _repository.Insert(AccountDTO.MappingFromEvent(notification));
            return Task.CompletedTask;
        }
    }
}