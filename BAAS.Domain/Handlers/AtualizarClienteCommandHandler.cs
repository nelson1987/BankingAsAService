using Baas.Domain.Commands;
using Baas.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand>
    {
        private readonly IClienteRepository _repository;

        public AtualizarClienteCommandHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AtualizarClienteCommand command, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(command.Id);
            cliente.Nome = command.Nome;

            _repository.Update(cliente);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }

}
