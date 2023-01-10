using Baas.Domain.Repositories.Models;
using MediatR;
using System;

namespace Baas.Domain.Tramsaction.Credit
{
    public class CreditTransactionCommand : IRequest<CreditTransactionResponse>
    {
        public AccountModel Debitante { get; set; }
        public AccountModel Creditante { get; set; }
        public DateTime DiaAgendamento { get; set; }
        public decimal Valor { get; set; }
    }
}
