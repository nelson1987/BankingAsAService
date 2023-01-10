using Baas.Domain.Account.Create;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Tramsaction.Debit
{
    public class DebitTransactionCommand : IRequest<DebitTransactionResponse>
    {
        public AccountModel Debitante { get; set; }
        public AccountModel Creditante { get; set; }
        public DateTime DiaAgendamento { get; set; }
        public decimal Valor { get; set; }
    }
    public class DebitTransactionResponse
    {
    }
    public class DebitTransactionEvent : INotification
    {
    }
    public class TransactionModel
    {
    }
    public class DebitTransactionHandler : IRequestHandler<DebitTransactionCommand, DebitTransactionResponse>
    {
        public Task<DebitTransactionResponse> Handle(DebitTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
