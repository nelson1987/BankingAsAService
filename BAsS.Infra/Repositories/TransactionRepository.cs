using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Infra.DbContext;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

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

        public async Task<Transaction> CreateAccount(TransactionDTO conta)
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

        public async Task<IEnumerable<Transaction>> GetAccountByNumber(TransactionDTO conta)
        {
            using (var conn = _dbSession.Connection)
            {
                return await conn.QueryAsync<Transaction>
                    (QuerySelect(), conta);
            }
        }

        private static string QuerySelect()
        {
            //var nomeTabela = "TB_TRANSACAO";
            //var creator = new QueryCreator(nomeTabela);
            //return creator.GetQuery();
            return @"Select 
                        [IDT_TRANSACTION] as Id
                        ,[IDT_CONTA] as IdConta
                        ,[DTA_TRANSACAO] as Transacao
                        ,[VLR_TRANSACAO] as Valor
                        ,[DTA_AGENDAMENTO]
                        ,[BANCO_CONTRAPARTE] as BancoContraParte
                        ,[AGENCIA_CONTRAPARTE] as AgenciaContraParte
                        ,[CONTA_CONTRAPARTE] as ContaContraParte
                        ,[DOCUMENTO_CONTRAPARTE] as DocumentoContraParte
                    FROM [DB_BAAS].[dbo].[TB_TRANSACAO]
                    WHERE IDT_CONTA = @Conta";
        }

        Task<IEnumerable<Domain.Entities.Transaction>> ITransactionRepository.GetAccountByNumber(TransactionDTO conta)
        {
            throw new System.NotImplementedException();
        }

        Task<Domain.Entities.Transaction> ITransactionRepository.CreateAccount(TransactionDTO accountDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}