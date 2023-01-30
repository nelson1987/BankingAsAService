using System.Threading.Tasks;

namespace Baas.Domain.Entities
{
    public interface IClienteRepository
    {
        Task<Cliente> Buscar(int id);
        Task Inserir(Cliente cliente);
    }

}
