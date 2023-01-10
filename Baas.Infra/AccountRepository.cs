using Baas.Domain.Account.Create;
using Baas.Domain.Repositories;
using Baas.Domain.Repositories.DTOs;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Baas.Infra
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbSession _dbSession;

        public AccountRepository(DbSession configuration)
        {
            _dbSession = configuration;
        }

        public async Task<AccountModel> CreateAccount(AccountDTO accountDTO)
        {
            using (var conn = _dbSession.Connection)
            {
                //var query = "Select Top 10 ClienteId,Nome,Idade,Pais From Clientes";
                //produto = connection.Query<Product>(@"SELECT * FROM Products WHERE ProductID = @ID", new { id = 2 });
                //List<Tarefa> tarefas = (await conn.QueryAsync<Tarefa>(sql: query)).ToList();
            }
            //var clientes = await db.QueryAsync<Cliente>(query);
            throw new System.NotImplementedException();
        }

        public async Task<AccountModel> GetAccount(AccountDTO conta)
        {

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
            //throw new NotImplementedException();
        }

        public Task<AccountModel> GetAccountByNumber(AccountDTO conta)
        {
            throw new System.NotImplementedException();
        }
    }
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }

        public DbSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration
                     .GetConnectionString("DefaultConnection"));
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}
