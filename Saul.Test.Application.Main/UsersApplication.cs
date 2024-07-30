using AutoMapper;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Application.Validator;
using Saul.Test.Transversal.Common;
using System;

namespace Saul.Test.Application.UseCases
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _validator;

        public UsersApplication(IUnitOfWork unitOfWork, IMapper mapper, UsersDtoValidator validator)
        {
            _unitOfWork = unitOfWork;
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
                var user = _unitOfWork.Users.Authenticate(userName, password);
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
