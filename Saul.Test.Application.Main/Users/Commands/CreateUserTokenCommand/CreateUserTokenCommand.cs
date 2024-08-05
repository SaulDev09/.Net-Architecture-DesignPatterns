using MediatR;
using Saul.Test.Application.DTO;
using Saul.Test.Transversal.Common;

namespace Saul.Test.Application.UseCases.Users.Commands.CreateUserTokenCommand
{
    public sealed record CreateUserTokenCommand : IRequest<Response<UserDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
