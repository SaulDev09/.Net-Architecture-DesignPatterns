using System;
using System.Threading.Tasks;
using AutoMapper;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface;
using Saul.Test.Domain.Entity;
using Saul.Test.Domain.Interface;
using Saul.Test.Transversal.Common;

namespace Saul.Test.Application.Main
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;
        public CustomersApplication(
            ICustomersDomain customersDomain,
            IMapper mapper
            )
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Insert(CustomersDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customersDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Data saved";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
