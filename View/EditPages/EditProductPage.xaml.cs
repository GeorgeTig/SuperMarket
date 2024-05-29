using SuperMarket.Models.Entity;
using SuperMarket.ViewModel.EditPagesViewModel;
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

namespace SuperMarket.View.EditPages
{
    /// <summary>
    /// Interaction logic for EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        public EditProductPage()
        {
            InitializeComponent();
            ProductEditViewModel productEditViewModel = new ProductEditViewModel();
            this.DataContext = productEditViewModel;
        }

        public EditProductPage(Product product)
        {
            InitializeComponent();
            ProductEditViewModel productEditViewModel = new ProductEditViewModel(product);
            this.DataContext = productEditViewModel;
        }
    }
}
