using Baas.Domain.Entities;
using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Infra.DbContext;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Baas.Infra.Repositories
{
    public class CreatedAccountEventRepository : ICreatedAccountEventRepository
    {
        private readonly MongoDbSession _context;

        public CreatedAccountEventRepository(MongoDbSession context)
        {
            _context = context;
        }

        public async Task<IList<Account>> Get(AccountDTO dto)
        {
            return await _context.Contas.Find(x => x.IdCliente == dto.IdCliente && x.Tipo == dto.Tipo && x.Numero == dto.Numero).ToListAsync();
        }
        public Task Insert(AccountDTO conta)
        {
            try
            {
                Account account = Account.MappingFromDTO(conta);
                _context.Contas.InsertOne(account);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw new Exception($"Problema ao realizar uma inserção{ex.Message}");
            }
        }
    }
}
