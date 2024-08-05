using MediatR;
using Saul.Test.Application.DTO;
using Saul.Test.Transversal.Common;
using System.Collections.Generic;

namespace Saul.Test.Application.UseCases.Customers.Queries.GetAllCustomerQuery
{
    public sealed record GetAllCustomerQuery : IRequest<Response<IEnumerable<CustomerDto>>>
    {

    }
}
