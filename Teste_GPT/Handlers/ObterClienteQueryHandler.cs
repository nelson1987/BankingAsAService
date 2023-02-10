    public class ObterClienteQueryHandler : IRequestHandler<ObterClienteQuery, Cliente>
    {
        private readonly IClienteRepository _repository;

        public ObterClienteQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        //public async Task<Cliente> Handle(
    }