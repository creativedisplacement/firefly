using Firefly.CodeTests.AuthManager.Models;
using Firefly.CodeTests.AuthManager.Validation;
using System.Text.RegularExpressions;

namespace Firefly.CodeTests.AuthManager.UnitTests
{
    public class UsernameAsEmailValidation : IValidation
    {
        public bool Validate(User user)
        {
            return Regex.IsMatch(user.Username, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
        }
    }
}
