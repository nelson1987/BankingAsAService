using Baas.Domain.Responses;
using MediatR;
using System;

namespace Baas.Domain.Entities
{
    public class MovimentacaoQuery : IRequest<MovimentacaoQueryResponse>
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public int IdConta { get; set; }
    }
}