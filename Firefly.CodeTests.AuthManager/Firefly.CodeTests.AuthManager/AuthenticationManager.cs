using Firefly.CodeTests.AuthManager.Models;
using Firefly.CodeTests.AuthManager.Repositories;
using Firefly.CodeTests.AuthManager.Validation;

namespace Firefly.CodeTests.AuthManager
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private IUserRepository repository;

        public AuthenticationManager()
        {
            repository = new UserRepository();
        }
        public Result CreateUser(User user, IValidation customRule)
        {
            return repository.CreateUser(user, customRule);
        }

        public User FindUser(string username)
        {
            return repository.FindUser(username);
        }

        public Result AuthenticateUser(User user)
        {
            return repository.IsAuthenticated(user);
        }

        public void ClearUsers()
        {
            repository.ClearUsers();
        }
    }
}
