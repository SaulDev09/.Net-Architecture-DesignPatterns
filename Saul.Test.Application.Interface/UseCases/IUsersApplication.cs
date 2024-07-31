using Saul.Test.Application.DTO;
using Saul.Test.Transversal.Common;

namespace Saul.Test.Application.Interface.UseCases
{
    public interface IUsersApplication
    {
        Response<UserDto> Authenticate(string userName, string password);
    }
}
