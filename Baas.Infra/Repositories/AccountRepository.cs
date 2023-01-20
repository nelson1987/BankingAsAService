using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Repositories.Models;
using Baas.Infra.DbContext;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Baas.Infra.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ILogger<AccountRepository> _logger;
        private readonly DbSession _dbSession;

        public AccountRepository(ILogger<AccountRepository> logger, DbSession dbSession)
        {
            _logger = logger;
            _dbSession = dbSession;
        }

        public async Task<AccountModel> CreateAccount(AccountDTO dto)
        {
            /*
                using (var conn = _dbSession.Connection)
                {
                    var query = @"INSERT INTO
                                        NUM_CONTA as Number,
                                        IDT_CLIENTE as IdCliente
                            From TB_CONTA
                            WHERE IDT_CLIENTE = @ID";

                    //var query = "Select Top 10 ClienteId,Nome,Idade,Pais From Clientes";
                    //produto = connection.Query<Product>(@"SELECT * FROM Products WHERE ProductID = @ID", new { id = 2 });
                    //List<Tarefa> tarefas = (await conn.QueryAsync<Tarefa>(sql: query)).ToList();
                }
                //var clientes = await db.QueryAsync<Cliente>(query);
            */
            throw new System.NotImplementedException();
        }

        public Task<AccountModel> Delete(AccountDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<AccountModel> Get(AccountDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AccountModel> GetAccount(AccountDTO conta)
        {
            /*
            using (var conn = _dbSession.Connection)
            {
                var query = @"Select Top 10
                                    NUM_CONTA as Number,
                                    IDT_CLIENTE as IdCliente
                        From TB_CONTA
                        WHERE IDT_CLIENTE = @ID";
                var model = await conn.QueryFirstAsync<AccountModel>(query, new { id = conta.IdCliente });
                //List<Tarefa> tarefas = (await conn.QueryAsync<Tarefa>(sql: query)).ToList();
                return model;
            }
            */
            throw new System.NotImplementedException();
        }

        public async Task<AccountModel> GetAccountByNumber(AccountDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<AccountModel> Insert(AccountDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<AccountModel> Update(AccountDTO conta)
        {
            throw new System.NotImplementedException();
        }
    }
}