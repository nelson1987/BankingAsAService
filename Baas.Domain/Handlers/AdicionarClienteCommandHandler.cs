using Baas.Domain.Commands;
using Baas.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class AdicionarClienteCommandHandler : IRequestHandler<AdicionarClienteCommand, int>
    {
        private readonly IClienteRepository _repository;

        public AdicionarClienteCommandHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AdicionarClienteCommand command, CancellationToken cancellationToken)
        {
            var cliente = new Cliente
            {
                Nome = command.Nome,
                Criacao = DateTime.Now
            };

            _repository.Add(cliente);
            await _repository.SaveChangesAsync();

            return cliente.Id;
        }
    }

}
