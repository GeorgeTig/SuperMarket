using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.Entity
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime IssueDate { get; set; }
        public int AmountReceived { get; set; }

        [NotMapped]
        public virtual List<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
