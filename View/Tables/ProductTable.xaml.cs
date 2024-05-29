using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    /// Interaction logic for ProductTable.xaml
    /// </summary>
    public partial class ProductTable : Page
    {
        public ProductTable()
        {
            InitializeComponent();
            TableProductViewModel viewModel = new TableProductViewModel();
            this.DataContext = viewModel;
        }
            
    }
}
