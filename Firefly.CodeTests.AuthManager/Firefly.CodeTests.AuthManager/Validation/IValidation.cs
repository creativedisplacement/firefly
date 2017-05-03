using Firefly.CodeTests.AuthManager.Models;

namespace Firefly.CodeTests.AuthManager.Validation
{
    /// <summary>
    /// New validation rules need to inherit this interface
    /// </summary>
    public interface IValidation
    {
        //should really return the Result wrapper, but left as boolean for simplicity
        bool Validate(User user);
    }
}
