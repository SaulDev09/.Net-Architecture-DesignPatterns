using MediatR;
using Saul.Test.Application.DTO;
using Saul.Test.Transversal.Common;

namespace Saul.Test.Application.UseCases.Customers.Queries.GetCustomerQuery
{
    public sealed record class GetCustomerQuery : IRequest<Response<CustomerDto>>
    {
        public string CustomerId { get; set; }
    }
}
