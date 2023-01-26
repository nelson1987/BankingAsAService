using Baas.Domain.Account.Create;
using Baas.Domain.Account.CreatedAccount;

namespace Baas.Domain.Repositories.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public int IdEnterpriseAccount { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        /*
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
        */

        public static AccountDTO MappingFromEvent(CreatedAccountEvent evento)
        {
            return new AccountDTO()
            {
                Id = evento.Id,
                Numero = evento.Numero,
                Tipo = evento.Tipo,
                IdCliente = evento.IdCliente,
                IdEnterpriseAccount = evento.IdEnterpriseAccount,
                Name = evento.Name,
                Document = evento.Document
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
                IdEnterpriseAccount = command.IdEnterpriseAccount,
                Name = command.Name,
                Document = command.Document
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
                IdEnterpriseAccount = command.IdEnterpriseAccount,
                Name = command.Name,
                Document = command.Document
            };
        }
    }
}