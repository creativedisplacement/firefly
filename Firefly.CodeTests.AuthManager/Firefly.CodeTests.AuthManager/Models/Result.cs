namespace Firefly.CodeTests.AuthManager.Models
{
    /// <summary>
    /// Used as a wrapper to return results to the client. Any error messages can populate the "Error" property
    /// </summary>
    public class Result
    {
        public bool IsOK { get; set; }
        public string Error { get; set; }
    }
}
