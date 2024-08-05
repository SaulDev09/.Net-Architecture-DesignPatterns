using MediatR;
using Saul.Test.Transversal.Common;

namespace Saul.Test.Application.UseCases.Customers.Commands.DeleteCustomerCommand
{
    public sealed record DeleteCustomerCommand : IRequest<Response<bool>>
    {
        public string CustomerId { get; set; }
    }
}
