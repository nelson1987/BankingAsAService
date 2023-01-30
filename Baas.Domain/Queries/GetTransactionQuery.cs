using Baas.Domain.Responses;
using MediatR;
using System.Collections.Generic;

namespace Baas.Domain.Queries
{
    public class GetTransactionQuery : IRequest<IEnumerable<GetTransactionQueryResponse>>
    {
    }
}