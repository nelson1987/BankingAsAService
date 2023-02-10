public interface IClienteRepository
{
    Task<Cliente> Buscar(int id);
    Task Inserir(Cliente cliente);
}