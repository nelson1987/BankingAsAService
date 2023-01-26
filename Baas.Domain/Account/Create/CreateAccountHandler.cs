using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Account.Create
{
    public class CreateAccountHandler : IRequestHandler<InsertAccountCommand, InsertAccountResponse>
    {
        private readonly IMediator _mediator;
        private readonly IAccountRepository _accountRepository;

        public CreateAccountHandler(IMediator mediator, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _mediator = mediator;
        }

        public async Task<InsertAccountResponse> Handle(InsertAccountCommand command, CancellationToken cancellationToken)
        {
            //AccountModel contaResponse = await ValidarSeExiste(request);

            //Criacao de Conta em banco Relacional
            Entities.Account criacaoContaResponse = await _accountRepository.Insert(AccountDTO.MappingFromModel(command));

            //Publicar();

            //Incluir na fila para sincronizar com banco no-sql
            await _mediator.Send(criacaoContaResponse);
            return InsertAccountResponse.MappingFromModel(criacaoContaResponse);
        }

        //private async Task<AccountModel> ValidarSeExiste(CreateAccountCommand request)
        //{
        //    var contaResponse = await _accountRepository.GetAccountByNumber(AccountDTO.MappingFromModel(request));
        //    if (contaResponse == null)
        //        throw new System.NotImplementedException();
        //    return contaResponse;
        //}

        //private async Task<AccountModel> Inserir(InsertAccountCommand command)
        //{
        //    var criacaoContaResponse = await _accountRepository.Insert(AccountDTO.MappingFromModel(command));
        //    if (criacaoContaResponse == null)
        //        throw new System.NotImplementedException();
        //    return criacaoContaResponse;
        //}

        //private void Publicar()
        //{
        //    var eventResponse = _mediator.Publish(new CreateAccountEvent());
        //    if (eventResponse.IsFaulted)
        //        throw new System.NotImplementedException();
        //}
    }
}