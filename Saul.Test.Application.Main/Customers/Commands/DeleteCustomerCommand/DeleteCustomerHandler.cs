using AutoMapper;
using MediatR;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Transversal.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.UseCases.Customers.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            response.Data = await _unitOfWork.Customers.Delete(request.CustomerId);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Data Deleted";
            }

            return response;
        }
    }
}
