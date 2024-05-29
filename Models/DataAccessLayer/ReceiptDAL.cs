using Microsoft.Data.SqlClient;
using SuperMarket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.DataAccessLayer
{
    public class ReceiptDAL
    {
        public List<Receipt> GetReceipts()
        {
            var connection = new SqlConnection("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
            List<Receipt> receipts = new List<Receipt>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllReceipts", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Receipt receipt = new Receipt();
                    receipt.ReceiptId = reader.GetInt32(0);
                    receipt.UserId = reader.GetInt32(1);
                    receipt.IssueDate = reader.GetDateTime(2);
                    receipt.AmountReceived = reader.GetInt32(3);
                    receipt.IsActive = reader.GetBoolean(4);
                    receipts.Add(receipt);
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
            return receipts;
        }
    }
}
