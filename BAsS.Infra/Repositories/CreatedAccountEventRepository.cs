using Baas.Domain.Entities;
using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Infra.DbContext;
using MongoDB.Driver;
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

        public Task<Account> Get(AccountDTO conta)
        {
            var aluno = _context.Alunos.Find(x => x.Id == conta.Id).FirstOrDefaultAsync();
            return aluno;
        }

        public Task Insert(AccountDTO conta)
        {
            Account account = Account.MappingFromDTO(conta);
            _context.Alunos.InsertOne(account);
            return Task.CompletedTask;
        }
    }
}
