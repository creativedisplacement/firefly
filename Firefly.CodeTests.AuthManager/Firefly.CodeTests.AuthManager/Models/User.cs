namespace Firefly.CodeTests.AuthManager.Models
{
    /// <summary>
    /// User class for authentication manager. Could be done as an abstract class for extensibility but not required for this example. Password should really be encrypted as well
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
