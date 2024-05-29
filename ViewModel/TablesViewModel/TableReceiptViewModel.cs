using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.ViewModel.TablesViewModel
{
    internal class TableReceiptViewModel
    {
        public List<Receipt> Receipts { get; set; }
        public BusinessLogicLayer BusinessLogicLayer { get; set; }
        public TableReceiptViewModel() 
        {
            Receipts = new List<Receipt>();
            BusinessLogicLayer = new BusinessLogicLayer();
            Receipts= BusinessLogicLayer.GetAllReceipts();
        }
    }
}
