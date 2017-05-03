using Firefly.CodeTests.AuthManager.Models;
using Firefly.CodeTests.AuthManager.Validation;

namespace Firefly.CodeTests.AuthManager.Repositories
{
    /// <summary>
    /// Using the repository pattern to keep logic in one reusable place and also so that other types of user repositories in future can be used
    /// </summary>
    public interface IUserRepository
    {
        Result CreateUser(User user, IValidation customRule);
        User FindUser(string username);
        Result IsAuthenticated(User user);
        void ClearUsers();
    }
}
