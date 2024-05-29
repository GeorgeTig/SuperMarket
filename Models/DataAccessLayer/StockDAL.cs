using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SuperMarket.Models.Entity;

namespace SuperMarket.Models.DataAccessLayer
{
    public class StockDAL
    {
        public void AddStock(int ProductId, int Quantity, int Unit, decimal PurchasePrice, DateTime SupplyDate, DateTime ExpiryDate)
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertStock", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", ProductId);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@Unit", Unit);
                command.Parameters.AddWithValue("@PurchasePrice", PurchasePrice);
                command.Parameters.AddWithValue("@SupplyDate", SupplyDate);
                command.Parameters.AddWithValue("@ExpiryDate", ExpiryDate);
                
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

        public List<Stock> GetStocks()
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            List<Stock> stocks = new List<Stock>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllStocks", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Stock stock = new Stock();
                    stock.StockId = reader.GetInt32(0);
                    stock.ProductId = reader.GetInt32(1);
                    stock.Quantity = reader.GetInt32(2);
                    stock.Unit = (UnitEnum)Enum.Parse(typeof(UnitEnum), reader.GetInt32(3).ToString());
                    stock.PurchasePrice = reader.GetDecimal(4);
                    stock.SupplyDate = reader.GetDateTime(5);
                    stock.ExpiryDate = reader.GetDateTime(6);
                    stock.IsActive = reader.GetBoolean(7);
                    stocks.Add(stock);
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
            return stocks;
        }
    }
}
