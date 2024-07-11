using Saul.Test.Domain.Entity;

namespace Saul.Test.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string userName, string password);
    }
}
