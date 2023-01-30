using Baas.Domain.Account.Create;
using Baas.Domain.Commands;
using System;

namespace Baas.Domain.Repositories.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public string Agencia { get; set; }

        internal static AccountDTO MappingFromModel(AberturaContaCommand request)
        {
            return new AccountDTO()
            {
                Agencia = request.Agencia,
                IdCliente = request.IdCliente,
                Tipo = request.Tipo
            };
        }

        internal static AccountDTO MappingFromModel(AccountQuery request)
        {
            return new AccountDTO()
            {
                IdCliente = request.IdCliente,
                Tipo = request.Tipo
            };
        }

        internal static AccountDTO MappingFromModel(InsertAccountCommand command)
        {
            throw new NotImplementedException();
        }
        //public int IdEnterpriseAccount { get; set; }
        //public string Name { get; set; }
        //public string Document { get; set; }
        //public string Agencia { get; set; }
        //public string CodigoCompe { get; set; }
    }
}