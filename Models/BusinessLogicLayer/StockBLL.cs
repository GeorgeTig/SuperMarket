using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;

namespace SuperMarket.Models.BusinessLogicLayer
{
     public class StockBLL
    {
        private StockDAL stockDAL = new StockDAL();

        public void AddStock(int ProductId, int Quantity, int Unit, decimal PurchasePrice, DateTime SupplyDate, DateTime ExpiryDate)
        {
            stockDAL.AddStock(ProductId, Quantity, Unit, PurchasePrice, SupplyDate, ExpiryDate);
        }

        public List<Stock> GetAllStocks()
        {
            return stockDAL.GetStocks();
        }
    }
}
