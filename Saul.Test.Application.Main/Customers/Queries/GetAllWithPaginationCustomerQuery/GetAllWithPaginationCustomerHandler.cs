using AutoMapper;
using MediatR;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.UseCases.Customers.Queries.GetAllWithPaginationCustomerQuery
{
    public class GetAllWithPaginationCustomerHandler : IRequestHandler<GetAllWithPaginationCustomerQuery, ResponsePagination<IEnumerable<CustomerDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWithPaginationCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponsePagination<IEnumerable<CustomerDto>>> Handle(GetAllWithPaginationCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDto>>();
            var customers = await _unitOfWork.Customers.GetAllWithPagination(request.PageNumber, request.PageSize);
            response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            if (response.Data != null)
            {
                response.PageNumber = request.PageNumber;
                response.TotalCount = await _unitOfWork.Customers.Count();
                response.TotalPages = (int)Math.Ceiling(response.TotalCount / (double)request.PageSize);

                response.IsSuccess = true;
                response.Message = "Successful query";
            }

            return response;
        }
    }
}
