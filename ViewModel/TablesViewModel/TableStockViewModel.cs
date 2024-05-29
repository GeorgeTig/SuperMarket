using ICommandDemoAgain.Commands;
using Microsoft.Identity.Client;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using SuperMarket.ViewModel.EditPagesViewModel;
using SuperMarket.View.EditPages;

namespace SuperMarket.ViewModel.TablesViewModel
{
    public class TableStockViewModel 
    {
        public List<Stock> Stocks { get; set; }
        public BusinessLogicLayer BusinessLogicLayer { get; set; }
        public ICommand AddStockCommand { get; set; }
        public TableStockViewModel()
        {
            Stocks = new List<Stock>();
            BusinessLogicLayer = new BusinessLogicLayer();
            Stocks = BusinessLogicLayer.GetAllStocks();
            AddStockCommand = new RelayCommand(o =>
            {
                if (o is not Page page)
                {
                    return;
                }

                page.NavigationService.Navigate(new EditStockPage());
            });
        }
    }
}
