using MediatR;
using Saul.Test.Application.DTO;
using Saul.Test.Transversal.Common;
using System.Collections.Generic;

namespace Saul.Test.Application.UseCases.Customers.Queries.GetAllWithPaginationCustomerQuery
{
    public sealed record GetAllWithPaginationCustomerQuery : IRequest<ResponsePagination<IEnumerable<CustomerDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
