using AutoMapper;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface;
using Saul.Test.Domain.Interface;
using Saul.Test.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saul.Test.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
        }

        public Response<UsersDto> Authenticate(string userName, string password)
        {
            var response = new Response<UsersDto>();
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                response.Message = "The params can't be null";
                return response;
            }

            try
            {
                var user = _usersDomain.Authenticate(userName, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Successful Authentication";
            }
            catch(InvalidOperationException)
            {
                response.IsSuccess=false;
                response.Message = "User doesn't exist";
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
