using MediatR;
using System.Collections.Generic;

namespace Baas.Domain.Transaction
{
    public class GetTransactionQuery : IRequest<IEnumerable<GetTransactionQueryResponse>>
    {
    }
}