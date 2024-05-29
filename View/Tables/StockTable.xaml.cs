using SuperMarket.ViewModel;
using SuperMarket.ViewModel.TablesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperMarket.View
{
    /// <summary>
    /// Interaction logic for StockTable.xaml
    /// </summary>
    public partial class StockTable : Page
    {
        public StockTable()
        {
            InitializeComponent();
            TableStockViewModel viewModel = new TableStockViewModel();
            this.DataContext = viewModel;
        }
    }
}
