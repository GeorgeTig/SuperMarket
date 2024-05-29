using Microsoft.Data.SqlClient;
using SuperMarket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.DataAccessLayer
{
    public class ProductDAL
    {

        public List<Product> GetProducts()
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            List<Product> products = new List<Product>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllProducts", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.Barcode = reader.GetString(2);
                    product.CategoryId = reader.GetInt32(3);
                    product.ProducerId = reader.GetInt32(4);
                    product.IsActive = reader.GetBoolean(5);
                    products.Add(product);
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
            return products;
        }

        public Product GetAProduct(int ProductId)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            Product product = new Product();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectProductById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", ProductId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.ProductId = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.Barcode = reader.GetString(2);
                    product.CategoryId = reader.GetInt32(3);
                    product.ProducerId = reader.GetInt32(4);
                    product.IsActive = reader.GetBoolean(5);
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
            return product;
        }

        public void AddProduct(string Name, string Barcode, int CategoryId, int ProducerId)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Barcode", Barcode);
                command.Parameters.AddWithValue("@CategoryId", CategoryId);
                command.Parameters.AddWithValue("@ProducerId", ProducerId);
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

        public void UpdateProduct(int ProductId, string Name, string Barcode, int CategoryId, int ProducerId)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", ProductId);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Barcode", Barcode);
                command.Parameters.AddWithValue("@CategoryId", CategoryId);
                command.Parameters.AddWithValue("@ProducerId", ProducerId);
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

        public void DeleteProduct(int ProductId)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", ProductId);
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

        void SoftDeleteProduct(int ProductId)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", ProductId);
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

        void UpdateProduct(int ProductId, string Name, string Barcode, int CategoryId, int ProducerId, bool IsActive)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", ProductId);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Barcode", Barcode);
                command.Parameters.AddWithValue("@CategoryId", CategoryId);
                command.Parameters.AddWithValue("@ProducerId", ProducerId);
                command.Parameters.AddWithValue("@IsActive", IsActive);
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

