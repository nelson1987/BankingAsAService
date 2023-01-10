using Baas.Domain.Account.Create;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Tramsaction.Credit
{
    public class CreditTransactionCommand : IRequest<CreditTransactionResponse>
    {
        public AccountModel Debitante { get; set; }
        public AccountModel Creditante { get; set; }
        public DateTime DiaAgendamento { get; set; }
        public decimal Valor { get; set; }
    }
    public class CreditTransactionResponse
    { 
    }
    public class CreditTransactionEvent : INotification
    { 
    }
    public class TransactionModel
    { 
    }
    public class CreditTransactionHandler : IRequestHandler<CreditTransactionCommand, CreditTransactionResponse>
    {
        public Task<CreditTransactionResponse> Handle(CreditTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
