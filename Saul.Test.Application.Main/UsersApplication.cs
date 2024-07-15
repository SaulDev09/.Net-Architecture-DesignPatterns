using AutoMapper;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface;
using Saul.Test.Domain.Interface;
using Saul.Test.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Saul.Test.Application.Validator;

namespace Saul.Test.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _validator;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UsersDtoValidator validator)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _validator = validator;
        }

        public Response<UsersDto> Authenticate(string userName, string password)
        {
            var response = new Response<UsersDto>();
            var validation = _validator.Validate(new UsersDto() { UserName = userName, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Validation Error";
                response.Errors = validation.Errors;
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
