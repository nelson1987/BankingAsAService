using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Criacao { get; set; }
    }
    public class AdicionarClienteCommand : IRequest<int>
    {
        public string Nome { get; set; }
    }
    public class AdicionarClienteCommandHandler : IRequestHandler<AdicionarClienteCommand, int>
    {
        private readonly IClienteRepository _repository;

        public AdicionarClienteCommandHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AdicionarClienteCommand command, CancellationToken cancellationToken)
        {
            var cliente = new Cliente
            {
                Nome = command.Nome,
                Criacao = DateTime.Now
            };

            _repository.Add(cliente);
            await _repository.SaveChangesAsync();

            return cliente.Id;
        }
    }
    public class AtualizarClienteCommand : IRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand>
    {
        private readonly IClienteRepository _repository;

        public AtualizarClienteCommandHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AtualizarClienteCommand command, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(command.Id);
            cliente.Nome = command.Nome;

            _repository.Update(cliente);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }

    public class ObterClienteQuery : IRequest<Cliente>
    {
        public int Id { get; set; }
    }

    public class ObterClienteQueryHandler : IRequestHandler<ObterClienteQuery, Cliente>
    {
        private readonly IClienteRepository _repository;

        public ObterClienteQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Task<Cliente> Handle(ObterClienteQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public interface IClienteRepository
    {
        Task<Cliente> Buscar(int id);
        Task Inserir(Cliente cliente);
    }
    public class ClienteRepository : IClienteRepository
    {
        //private readonly MyDbContext _context;
        //
        //public ClienteRepository(MyDbContext context)
        //{
        //    _context = context;
        //}
        //
        //public async Task<Cliente> Buscar(int id)
        //{
        //    return await _context.Clientes.FindAsync(id);
        //}
        //
        //public async Task Inserir(Cliente cliente)
        //{
        //    _context.Clientes.Add(cliente);
        //    await _context.SaveChangesAsync();
        //}
    }
}
