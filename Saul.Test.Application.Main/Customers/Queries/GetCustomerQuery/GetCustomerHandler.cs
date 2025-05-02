using AutoMapper;
using MediatR;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Transversal.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.UseCases.Customers.Queries.GetCustomerQuery
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Response<CustomerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<CustomerDto>();
            var customer = await _unitOfWork.Customers.Get(request.CustomerId);
            response.Data = _mapper.Map<CustomerDto>(customer);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Successful query";
            }
            return response;
        }
    }
}
