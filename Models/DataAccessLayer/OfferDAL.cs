using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Supermarket.Services;
using SuperMarket.Models.Entity;

namespace SuperMarket.Models.DataAccessLayer
{
    public class OfferDAL
    {

        public List<Offer> GetOffers()
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            List<Offer> offers = new List<Offer>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllOffers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Offer offer = new Offer();
                    offer.OfferId = reader.GetInt32(0);
                    offer.ProductId = reader.GetInt32(1);
                    offer.DiscountPercentage = reader.GetInt32(2);
                    offer.StartDate = reader.GetDateTime(3);
                    offer.EndDate = reader.GetDateTime(4);
                    offer.Reason = reader.GetString(5);
                    offer.IsActive = reader.GetBoolean(6);
                    offers.Add(offer);

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
            return offers;
        }




        public Offer GetOffer(int OfferId)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            Offer offer = new Offer();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectOfferById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OfferId", OfferId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    offer.OfferId = reader.GetInt32(0);
                    offer.ProductId = reader.GetInt32(1);
                    offer.DiscountPercentage = reader.GetInt32(2);
                    offer.StartDate = reader.GetDateTime(3);
                    offer.EndDate = reader.GetDateTime(4);
                    offer.Reason = reader.GetString(5);
                    offer.IsActive = reader.GetBoolean(6);
                    return offer;
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
            return offer;
        }

        public void AddOffer(int ProductId, int DiscountPercentage, string Reason, DateTime StartDate, DateTime EndDate)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            SqlCommand command = new SqlCommand("InsertOffer", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProductId", ProductId);
            command.Parameters.AddWithValue("@DiscountPercentage", DiscountPercentage);
            command.Parameters.AddWithValue("@Reason", Reason);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
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

        public void DeleteOffer(int OfferId)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            SqlCommand command = new SqlCommand("SoftDeleteOffer", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@OfferId", OfferId);
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

        public void UpdateOffer(int OfferId, int ProductId, int DiscountPercentage, string Reason, DateTime StartDate, DateTime EndDate)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            SqlCommand command = new SqlCommand("UpdateOffer", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@OfferId", OfferId);
            command.Parameters.AddWithValue("@ProductId", ProductId);
            command.Parameters.AddWithValue("@DiscountPercentage", DiscountPercentage);
            command.Parameters.AddWithValue("@Reason", Reason);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
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

