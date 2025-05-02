using AutoMapper;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Transversal.Common;
using System;
using System.Threading.Tasks;

namespace Saul.Test.Application.UseCases.Users
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UserDto>> Authenticate(string userName, string password)
        {
            var response = new Response<UserDto>();           

            try
            {
                var user = await _unitOfWork.Users.Authenticate(userName, password);
                response.Data = _mapper.Map<UserDto>(user);
                response.IsSuccess = true;
                response.Message = "Successful Authentication";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = false;
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
