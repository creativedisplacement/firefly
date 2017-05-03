using Firefly.CodeTests.AuthManager.Models;
using Firefly.CodeTests.AuthManager.Validation;
using System.Text.RegularExpressions;

namespace Firefly.CodeTests.AuthManager.UnitTests
{
    public class UsernameAsDomainAccount : IValidation
    {
        public bool Validate(User user)
        {
            return Regex.IsMatch(user.Username, @"^[a-zA-Z][a-zA-Z0-9\-\.]{0,61}[a-zA-Z]\\\w[\w\.\- ]+$", RegexOptions.IgnoreCase);
        }
    }
}
