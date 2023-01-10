using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using Baas.Infra.DbContext;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Baas.Infra.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ILogger<TransactionRepository> _logger;
        private readonly DbSession _dbSession;

        public TransactionRepository(ILogger<TransactionRepository> logger, DbSession dbSession)
        {
            _logger = logger;
            _dbSession = dbSession;
        }

        public Task<AccountModel> CreateAccount(TransactionDTO conta)
        {

            using (var conn = _dbSession.Connection)
            {
                //var query = @"Select Top 10 
                 //                   NUM_CONTA as Number, 
                 //                   IDT_CLIENTE as IdCliente 
                 //       From TB_CONTA 
                 //       WHERE IDT_CLIENTE = @ID";
                //var model = await conn.QueryFirstAsync<AccountModel>(query, new { id = conta });
                ////List<Tarefa> tarefas = (await conn.QueryAsync<Tarefa>(sql: query)).ToList();
                //return model;
            }
            throw new System.Exception();
        }

        public Task<AccountModel> GetAccountByNumber(TransactionDTO conta)
        {
            throw new System.NotImplementedException();
        }
    }
}
