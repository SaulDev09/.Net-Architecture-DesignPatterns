using AutoMapper;
using MediatR;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Domain.Entities;
using Saul.Test.Transversal.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.UseCases.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var customer = _mapper.Map<Customer>(request);
            response.Data = await _unitOfWork.Customers.Insert(customer);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Data saved";
            }

            return response;
        }
    }
}
