using Saul.Test.Domain.Entities;
using System.Threading.Tasks;

namespace Saul.Test.Application.Interface.Persistence
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<User> Authenticate(string userName, string password);
    }
}
