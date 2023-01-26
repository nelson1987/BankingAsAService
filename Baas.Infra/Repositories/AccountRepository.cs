using Baas.Domain.Entities;
using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Infra.DbContext;
using Dapper;
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

        public async Task<Account> CreateAccount(AccountDTO dto)
        {
            using (var conn = _dbSession.Connection)
            {
                var query = @"INSERT INTO TB_CONTA
                                        (NUM_CONTA
                                        ,TPO_CONTA
                                        ,IDT_CLIENTE)
                            VALUES(@NUMERO
                                        ,@TIPO
                                        ,@CLIENTE)";
                // connection.Query<Product>(@"SELECT * FROM Products WHERE ProductID = @ID", new { id = 2 });
                //List<Tarefa> tarefas = (
                await conn.ExecuteAsync(sql: query, new { numero = dto.Numero, tipo = dto.Tipo, cliente = dto.IdCliente });
                //).ToList();
            }
            return Account.MappingFromDTO(dto);
            //var clientes = await db.QueryAsync<Cliente>(query);
        }

        public Task<Account> Delete(AccountDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<Account> Insert(AccountDTO conta)
        {
            throw new System.NotImplementedException();
        }

        public Task<Account> Update(AccountDTO conta)
        {
            throw new System.NotImplementedException();
        }
    }
}