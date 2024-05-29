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
using Supermarket;
using SuperMarket.ViewModel;
using SuperMarket.ViewModel.TablesViewModel;

namespace SuperMarket.View
{
    /// <summary>
    /// Interaction logic for CategoryTable.xaml
    /// </summary>
    public partial class CategoryTable : Page
    {
        public CategoryTable()
        {
            InitializeComponent();
            TableCategoryViewModel viewModel = new TableCategoryViewModel();
            this.DataContext = viewModel;
        }
    }
}
