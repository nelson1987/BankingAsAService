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

        public async Task Delete(AccountDTO dto)
        {
            using (var conn = _dbSession.Connection)
            {
                var query = @"DELETE TB_CONTA
                            WHERE NUM_CONTA = @NUMERO;";
                await conn.ExecuteAsync(sql: query, new { numero = dto.Numero });
            }
        }

        public async Task<Account> Insert(AccountDTO dto)
        {
            using (var conn = _dbSession.Connection)
            {
                var query = @"INSERT INTO TB_CONTA
                                        (NUM_CONTA
                                        ,TPO_CONTA
                                        ,IDT_CLIENTE)
                            VALUES(@NUMERO
                                        ,@TIPO
                                        ,@CLIENTE);";
                await conn.ExecuteAsync(sql: query, new { numero = dto.Numero, tipo = dto.Tipo, cliente = dto.IdCliente });
            }
            return Account.MappingFromDTO(dto);
        }

        public Task<Account> Update(AccountDTO conta)
        {
            throw new System.NotImplementedException();
        }
    }
}