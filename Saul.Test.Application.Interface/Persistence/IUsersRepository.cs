using Saul.Test.Domain.Entity;

namespace Saul.Test.Application.Interface.Persistence
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        User Authenticate(string userName, string password);
    }
}
