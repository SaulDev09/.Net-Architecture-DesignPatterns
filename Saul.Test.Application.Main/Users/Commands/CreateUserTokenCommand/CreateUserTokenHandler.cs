using AutoMapper;
using MediatR;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Transversal.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.UseCases.Users.Commands.CreateUserTokenCommand
{
    public class CreateUserTokenHandler : IRequestHandler<CreateUserTokenCommand, Response<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserTokenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UserDto>> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<UserDto>();
            //var validation = _validator.Validate(new UserDto() { UserName = userName, Password = password });

            //if (!validation.IsValid)
            //{
            //    response.Message = "Validation Error";
            //    response.Errors = validation.Errors;
            //    return response;
            //}

            try
            {
                var user = await _unitOfWork.Users.Authenticate(request.UserName, request.Password);
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
