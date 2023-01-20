using Baas.Domain.Account.Create;

namespace Baas.Domain.Repositories.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }

        public static AccountDTO MappingFromModel(InsertAccountCommand command)
        {
            return new AccountDTO()
            {
                Id = command.Id,
                Numero = command.Numero,
                Tipo = command.Tipo,
                IdCliente = command.IdCliente,
            };
        }

        public static AccountDTO MappingFromModel(AccountQuery command)
        {
            return new AccountDTO()
            {
                Id = command.Id,
                Numero = command.Numero,
                Tipo = command.Tipo,
                IdCliente = command.IdCliente,
            };
        }
        
        public static AccountDTO MappingFromModel(InsertAccountCommand command)
        {
            return new AccountDTO()
            {
                Id = command.Id,
                Numero = command.Numero,
                Tipo = command.Tipo,
                IdCliente = command.IdCliente,
            };
        }

    }
}