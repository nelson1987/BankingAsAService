using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Transaction
{
    public class GetTransactionQuery : IRequest<IEnumerable<GetTransactionQueryResponse>>
    {
    }
    public class GetTransactionQueryEvent : INotification
    {
    }
    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, IEnumerable<GetTransactionQueryResponse>>
    {
        private readonly ILogger<GetTransactionQueryHandler> _logger;
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionQueryHandler(ILogger<GetTransactionQueryHandler> logger, ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<GetTransactionQueryResponse>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            var listagem = await _transactionRepository.GetAccountByNumber(TransactionDTO.MappingFromModel(request));
            var grid = GridResponse<TransactionModel>.Get(listagem, "1", 3);
            return grid
                    .Select(x => GetTransactionQueryResponse.MappingFromModel(x));
        }
    }
    public static class GridResponse<T> where T : class
    {

        public static IEnumerable<T> Get(IEnumerable<T> products, string page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = products.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
        
            var result = (from produto in products
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                          select produto);
            return result;
        }
    }
    public class GetTransactionQueryResponse
    {
        public int Id { get; set; }
        public int IdConta { get; set; }
        public DateTime Transacao { get; set; }
        public decimal Valor { get; set; }
        public string BancoContraParte { get; set; }
        public string AgenciaContraParte { get; set; }
        public string ContaContraParte { get; set; }
        public string DocumentoContraParte { get; set; }

        public static GetTransactionQueryResponse MappingFromModel(TransactionModel model)
        {
            return new GetTransactionQueryResponse()
            {
                Id = model.Id,
                IdConta = model.IdConta,
                Transacao = model.Transacao,
                Valor = model.Valor,
                AgenciaContraParte = model.AgenciaContraParte,
                BancoContraParte = model.BancoContraParte,
                ContaContraParte = model.ContaContraParte,
                DocumentoContraParte = model.DocumentoContraParte
            };
        }
    }
}
