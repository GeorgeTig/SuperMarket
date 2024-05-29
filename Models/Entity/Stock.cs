using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.Entity
{
    public enum UnitEnum
    {
        KG,
        L,
        PCS
    }
    public class Stock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public UnitEnum Unit { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime SupplyDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        
    }
}
