using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Services;
using SuperMarket.Models.Entity;


namespace SuperMarket.Models.DataAccessLayer
{
    public class CategoryDAL
    {
        public List<Category> GetCategories()
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            List<Category> categories = new List<Category>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllCategories", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.CategoryID = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    category.IsActive = reader.GetBoolean(2);
                    categories.Add(category);
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
            return categories;
        }




        public Category GetACategory(int CategoryID)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            Category category = new Category();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectCategoryById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", CategoryID);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    category.CategoryID = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    category.IsActive = reader.GetBoolean(2);
                    return category;
                }
                else
                {
                    return null;
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
            return category;
        }

        public void AddCategory(string Name)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            SqlCommand command = new SqlCommand("InsertCategory", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", Name);
            try
            {
                connection.Open();
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

        public void DeleteCategory(int CategoryId)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            SqlCommand command = new SqlCommand("SoftDeleteCategory", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CategoryId", CategoryId);
            try
            {
                connection.Open();
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

        public void UpdateCategory(int CategoryId, string Name)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            SqlCommand command = new SqlCommand("UpdateCategory", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CategoryId", CategoryId);
            command.Parameters.AddWithValue("@Name", Name);
            try
            {
                connection.Open();
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

