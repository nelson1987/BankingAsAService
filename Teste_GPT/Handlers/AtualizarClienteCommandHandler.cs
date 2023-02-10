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

            await _repository.AtualizarAsync();

            return Unit.Value;
        }
    }
}