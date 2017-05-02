using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Firefly.CodeTests.AuthManager.UnitTests
{
    [TestClass]
    public class AuthManagerIntegrationTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            //TODO: implement DB cleanup
        }

        [TestMethod]
        public void CreateNewUser_UserNameValidationFails_1()
        {
            //TODO: implement a test where, during a new User creation, the UserName custom validation fails
            //	custom validation checks for UserName: should be a valid email address

            throw new NotImplementedException();
        }

        [TestMethod]
        public void CreateNewUser_UserNameValidationFails_2()
        {
            //TODO: implement a test where, during a new User creation, the UserName custom validation fails
            //	custom validation checks for UserName: should be a valid active directory account (domain\username)

            throw new NotImplementedException();
        }

        [TestMethod]
        public void CreateNewUser_Succeeds()
        {
            //TODO: implement a test where the creation succeed

            throw new NotImplementedException();
        }

        [TestMethod]
        public void CreateNewUser_UserNameAlreadyExists()
        {
            //TODO: implement a test where the creation fails because a User with the same UserName already exists

            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetUser_Succeeds()
        {
            //TODO: implement a test that retrieve, using the UserName, the user created with the test CreateNewUser_Succeededs

            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetUser_Fails()
        {
            //TODO: implement a test that doesn't retrieve a User with a speficied UserName

            throw new NotImplementedException();
        }

        [TestMethod]
        public void AuthenticaUserCredentialsOk_Succeeds()
        {
            //TODO: implement a test in which an account is successfully authenticated against an exsisting user previously created in CreateNewUser_Succeededs

            throw new NotImplementedException();
        }

        [TestMethod]
        public void AuthenticateUser_WrongPassword()
        {
            //TODO: implement a test in which user authentication fails bacause the password is wrong

            throw new NotImplementedException();
        }
    }
}
