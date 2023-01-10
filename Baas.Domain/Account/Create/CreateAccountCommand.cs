using MediatR;

namespace Baas.Domain.Account.Create
{
    public class CreateAccountCommand : IRequest<CreateAccountResponse>
    {
        public int IdEnterpriseAccount { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
    }
}