using AutoMapper;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Domain.Entities;
using Saul.Test.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Application.UseCases.Customers
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Insert(CustomerDto customersDto)
        {
            var response = new Response<bool>();

            var customer = _mapper.Map<Customer>(customersDto);
            response.Data = await _unitOfWork.Customers.Insert(customer);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Data saved";
            }

            return response;
        }

        public async Task<Response<bool>> Update(CustomerDto customersDto)
        {
            var response = new Response<bool>();

            var customer = _mapper.Map<Customer>(customersDto);
            response.Data = await _unitOfWork.Customers.Update(customer);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Data updated";
            }

            return response;
        }

        public async Task<Response<bool>> Delete(string customerId)
        {
            var response = new Response<bool>();
            response.Data = await _unitOfWork.Customers.Delete(customerId);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Data Deleted";
            }

            return response;
        }

        public async Task<Response<CustomerDto>> Get(string customerId)
        {
            var response = new Response<CustomerDto>();
            var customer = await _unitOfWork.Customers.Get(customerId);
            response.Data = _mapper.Map<CustomerDto>(customer);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Successful query";
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomerDto>>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDto>>();

            var customers = await _unitOfWork.Customers.GetAll();
            response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Successful query";
            }

            return response;
        }

        public async Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPagination(int pageNumber, int pageSize)
        {

            var response = new ResponsePagination<IEnumerable<CustomerDto>>();
            var customers = await _unitOfWork.Customers.GetAllWithPagination(pageNumber, pageSize);
            response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            if (response.Data != null)
            {
                response.PageNumber = pageNumber;
                response.TotalCount = await _unitOfWork.Customers.Count();
                response.TotalPages = (int)Math.Ceiling(response.TotalCount / (double)pageSize);

                response.IsSuccess = true;
                response.Message = "Successful query";
            }

            return response;
        }
    }
}
