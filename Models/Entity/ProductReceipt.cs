using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.Entity
{
    [PrimaryKey("ReceiptId","ProductId")]
    public class ProductReceipt
    {
        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Subtotal { get; set; }
        public bool IsActive { get; set; }
    }
}
