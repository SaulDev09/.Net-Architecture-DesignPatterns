using Saul.Test.Application.DTO;
using Saul.Test.Transversal.Common;
using System.Threading.Tasks;

namespace Saul.Test.Application.Interface.UseCases
{
    public interface IUsersApplication
    {
        Task<Response<UserDto>> Authenticate(string userName, string password);
    }
}
