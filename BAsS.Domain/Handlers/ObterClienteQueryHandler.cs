using Baas.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class ObterClienteQueryHandler : IRequestHandler<ObterClienteQuery, Cliente>
    {
        private readonly IClienteRepository _repository;

        public ObterClienteQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Task<Cliente> Handle(ObterClienteQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
