using Firefly.CodeTests.AuthManager.Models;
using Firefly.CodeTests.AuthManager.Validation;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Firefly.CodeTests.AuthManager.Repositories
{
    /// <summary>
    /// Concrete implementation of the IUserRepository. Using ADO.Net as Entity framework and third party libraries were not to be used
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private string connectionString
        {
            get
            {
               return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }
  
        private SqlCommand command;
        private SqlDataReader reader;

        public Result IsAuthenticated(User user)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (command = new SqlCommand("AuthenticateUser", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        connection.Open();

                        using (reader = command.ExecuteReader())
                        {
                            return new Result
                            {
                                IsOK = reader.HasRows ? true : false,
                                Error = reader.HasRows ? string.Empty : "User is not authenticated"
                            };
                        }
                    }  
                }
            }
            catch (Exception ex)
            {
                return new Result
                {
                    IsOK = false,
                    Error = ex.Message
                };
            }
        }

        public Result CreateUser(User user, IValidation customRule)
        {
            //check rules are OK
            var customRuleCheck = new ValidationContext(user, customRule);
            if (customRuleCheck.Validate() == false)
                return new Result {
                    IsOK = false,
                    Error = "User details do not match validation rules"
                };

            //check user does not exist
            if (this.FindUser(user.Username) != null)
                return new Result
                {
                    IsOK = false,
                    Error = "User does not exist"
                };

            //create user
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (command = new SqlCommand("CreateUser", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        connection.Open();
                        var isCreated = command.ExecuteNonQuery();
                        return new Result
                        {
                            IsOK = isCreated == 0 ? false : true,
                            Error = isCreated == 0 ? "User not created" : string.Empty
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public User FindUser(string username)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (command = new SqlCommand("FindUser", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", username);
                        connection.Open();
                        using (reader = command.ExecuteReader())
                        {
                            return ConvertToUser(reader);
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ClearUsers()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (command = new SqlCommand("ClearUsers", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private User ConvertToUser(SqlDataReader reader)
        {
            while (reader.Read())
            {
                return new User {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Username = reader["Username"].ToString()
                };  
            }
            return default(User);
        }
    }
}
