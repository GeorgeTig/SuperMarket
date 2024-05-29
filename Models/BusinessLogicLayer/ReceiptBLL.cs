using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;

namespace SuperMarket.Models.BusinessLogicLayer
{
    public class ReceiptBLL
    {
        private ReceiptDAL receiptDAL = new ReceiptDAL();
        public List<Receipt> GetAllReceipts()
        {
            return receiptDAL.GetReceipts();
        }
    }
}
