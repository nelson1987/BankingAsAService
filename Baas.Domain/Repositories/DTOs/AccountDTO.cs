using Baas.Domain.Account.Create;

namespace Baas.Domain.Repositories.DTOs
{
    public class AccountDTO
    {
        public string Numero { get; set; }
        public string IdCliente { get; set; }
        public string IdEmpresa { get; set; }

        public static AccountDTO MappingFromModel(CreateAccountCommand request)
        {
            return new AccountDTO();
        }

        public static AccountDTO MappingFromModel(AccountQuery request)
        {
            return new AccountDTO()
            {
                IdCliente = request.IdCliente,
                Numero = request.Numero,
                IdEmpresa = request.IdEmpresa
            };
        }
    }
}