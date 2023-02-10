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

            await _repository.Inserir(cliente);

            return cliente.Id;
        }
    }