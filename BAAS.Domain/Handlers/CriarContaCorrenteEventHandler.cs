using Baas.Domain.Events;
using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class CriarContaCorrenteEventHandler : IRequestHandler<ContaAbertaEventSync, ContaAbertaEventSyncResponse>
    {
        private readonly ICreatedAccountEventRepository _createdAccountEventRepository;

        public CriarContaCorrenteEventHandler(ICreatedAccountEventRepository createdAccountEventRepository)
        {
            _createdAccountEventRepository = createdAccountEventRepository;
        }

        public async Task<ContaAbertaEventSyncResponse> Handle(ContaAbertaEventSync request, CancellationToken cancellationToken)
        {
            //TODO: MongoDB
            await _createdAccountEventRepository.Insert(new AccountDTO()
            {
                Numero = request.Numero,
                 Agencia = request.Agencia,
                  Id = request.Id,
                   IdCliente = request.IdCliente,
                    Tipo = request.Tipo
            });
            return new ContaAbertaEventSyncResponse()
            {
                Numero = request.Numero
            };
        }
    }
}
