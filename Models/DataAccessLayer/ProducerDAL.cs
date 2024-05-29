using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SuperMarket.Models.Entity;

namespace SuperMarket.Models.DataAccessLayer
{
    public class ProducerDAL
    {
        public List<Producer> GetProducers()
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            List<Producer> producers = new List<Producer>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllProducers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Producer producer = new Producer();
                    producer.ProducerId = reader.GetInt32(0);
                    producer.Name = reader.GetString(1);
                    producer.OriginCountry = reader.GetString(2);
                    producer.IsActive = reader.GetBoolean(3);
                    producers.Add(producer);
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
            return producers;
        }
        
        public Producer GetAProducer(int ProducerId)
        {
            var connection =    new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            Producer producer = new Producer();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectProducerById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProducerId", ProducerId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    producer.ProducerId = reader.GetInt32(0);
                    producer.Name = reader.GetString(1);
                    producer.OriginCountry = reader.GetString(2);
                    producer.IsActive = reader.GetBoolean(3);
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
            return producer;
        }

        public void AddProducer(string Name, string OriginCountry)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertProducer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@OriginCountry", OriginCountry);
               
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

        public void DeleteProducer(int ProducerId)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteProducer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
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

        public void UpdateProducer(int ProducerId, string Name, string OriginCountry)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateProducer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProducerId", ProducerId);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@OriginCountry", OriginCountry);
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
