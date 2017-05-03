using Firefly.CodeTests.AuthManager.Models;
using Firefly.CodeTests.AuthManager.Validation;

namespace Firefly.CodeTests.AuthManager
{
    public interface IAuthenticationManager
    {
        Result CreateUser(User user, IValidation customRule);
        User FindUser(string username);
        Result AuthenticateUser(User user);
        void ClearUsers();
    }
}
