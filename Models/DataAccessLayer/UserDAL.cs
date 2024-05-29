using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SuperMarket.Models.Entity;


namespace SuperMarket.Models.DataAccessLayer
{
    public class UserDAL
    {
        public List<User> GetUsers()
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            List<User> users = new List<User>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllUsers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.UserId = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.UserType = (UserTypeEnum)reader.GetInt32(3);
                    user.IsActive = reader.GetBoolean(4);
                    users.Add(user);
                }

            }
            catch
            (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return users;
        }

        public User GetAUser(int UserID)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            User user = new User();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectUserById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", UserID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   user.UserId = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.UserType = (UserTypeEnum)reader.GetInt32(3);
                    user.IsActive = reader.GetBoolean(4);
                }
            }
            catch
            (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return user;
        }

        public void AddUser(User user)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@UserType", user.UserType);
                
                command.ExecuteNonQuery();
            }
            catch
            (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteUser(int UserID)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", UserID);
                command.ExecuteNonQuery();
            }
            catch
            (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateUser(int UserID, string Username, string Password, UserTypeEnum UserType, bool IsActive)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", UserID);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@UserType", UserType);
                
                command.ExecuteNonQuery();
            }
            catch
            (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
