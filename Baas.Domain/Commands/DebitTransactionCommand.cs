﻿using Baas.Domain.Tramsaction.Debit;
using MediatR;
using System;

namespace Baas.Domain.Commands
{
    public class DebitTransactionCommand : IRequest<DebitTransactionResponse>
    {
        //public AccountModel Debitante { get; set; }
        //public AccountModel Creditante { get; set; }
        public DateTime DiaAgendamento { get; set; }

        public decimal Valor { get; set; }
    }
}