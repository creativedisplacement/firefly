using Firefly.CodeTests.AuthManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Firefly.CodeTests.AuthManager.UnitTests
{
    [TestClass]
    public class AuthManagerIntegrationTest
    {
        private IAuthenticationManager authenticationManager;

        [TestInitialize]
        public void TestInitialize()
        {
            //DB cleanup runs before each test
            authenticationManager = new AuthenticationManager();
            authenticationManager.ClearUsers();
        }

        [TestMethod]
        public void CreateNewUser_UserNameValidationFails_NotValidEmail()
        {
            //custom validation checks for UserName: should be a valid email address
            var user = new User
            {
                Username="test",
                Password="test"
            };
            var result = authenticationManager.CreateUser(user, new UsernameAsEmailValidation());
            Assert.AreEqual(result.IsOK, false);
        }

        [TestMethod]
        public void CreateNewUser_UserNameValidationFails_NotValidActiveDirectoryAccount()
        {
            //custom validation checks for UserName: should be a valid active directory account (domain\username)
            var user = new User
            {
                Username = "test",
                Password = "test"
            };
            var result = authenticationManager.CreateUser(user, new UsernameAsDomainAccount());
            Assert.AreEqual(result.IsOK, false);
        }

        [TestMethod]
        public void CreateNewUser_Succeeds()
        {
            //successful creation of a new user
            var user = new User
            {
                Username = "test@test.com",
                Password = "test"
            };
            var result = authenticationManager.CreateUser(user, new UsernameAsEmailValidation());
            Assert.AreEqual(result.IsOK, true);
        }

        [TestMethod]
        public void CreateNewUser_UserNameAlreadyExists()
        {
            //cannot create user as the same UserName already exists
            InsertUser();
            var user = new User
            {
                Username = "test@test.com",
                Password = "test"
            };

            var result = authenticationManager.CreateUser(user, new UsernameAsEmailValidation());
            Assert.AreEqual(result.IsOK, false);
        }

        [TestMethod]
        public void GetUser_Succeeds()
        {
            //retrieve the user created with the test CreateNewUser_Succeededs by username
            InsertUser();

            var result = authenticationManager.FindUser("test@test.com");
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Username, "test@test.com");
        }

        [TestMethod]
        public void GetUser_Fails()
        {
            //cannot retrieve a User with a speficied UserName who does not exist in the database
            InsertUser();

            var result = authenticationManager.FindUser("test@test.com!");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AuthenticaUserCredentialsOk_Succeeds()
        {

            //account is successfully authenticated against an exsisting user previously created in CreateNewUser_Succeededs
            InsertUser();
            var result = authenticationManager.AuthenticateUser(new User { Username = "test@test.com", Password = "Test" });
            Assert.AreEqual(result.IsOK, true);
        }

        [TestMethod]
        public void AuthenticateUser_WrongPassword()
        {
            //user authentication fails bacause the password is wrong
            InsertUser();
            var result = authenticationManager.AuthenticateUser(new Models.User { Username = "test@test.com", Password = "Test!" });
            Assert.AreEqual(result.IsOK, false);
        }

        private void InsertUser()
        {
            //helper for creating a user and inserting into the database
            var user = new User
            {
                Username = "test@test.com",
                Password = "test"
            };
            authenticationManager.CreateUser(user, new UsernameAsEmailValidation());
        }
    }
}
