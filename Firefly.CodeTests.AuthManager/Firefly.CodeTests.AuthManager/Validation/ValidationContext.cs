using Firefly.CodeTests.AuthManager.Models;

namespace Firefly.CodeTests.AuthManager.Validation
{
    /// <summary>
    /// using the strategy pattern to run the validate method
    /// </summary>
    public class ValidationContext
    {
        private IValidation customRule;
        private User user;

        public ValidationContext(User user, IValidation customRule)
        {
            this.customRule = customRule;
            this.user = user;
        }

        public bool Validate()
        {
            return customRule.Validate(user);
        }
    }
}
