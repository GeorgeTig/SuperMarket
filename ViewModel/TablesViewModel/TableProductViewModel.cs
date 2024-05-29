using ICommandDemoAgain.Commands;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;
using SuperMarket.View.EditPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SuperMarket.ViewModel.TablesViewModel
{
    internal class TableProductViewModel : BaseViewModel
    {
        public List<Product> Products;
        public BusinessLogicLayer businessLogicLayer;
        public ICommand AddProductCommand { get; set; }
        public ICommand ModifyProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public object SelectedItem { get; set; } = null;

        public TableProductViewModel()
        {
            Products = new List<Product>();
            businessLogicLayer = new BusinessLogicLayer();
            Products = businessLogicLayer.GetAllProducts();
            AddProductCommand = new RelayCommand((o) =>
            {
                if (o is not Page page)
                {
                    return;
                }

                page.NavigationService.Navigate(new EditProductPage());
            });

            ModifyProductCommand = new RelayCommand((o) =>
            {
                if (o is not Page page)
                {
                    return;
                }
                if (SelectedItem == null)
                {
                    return;
                }
                page.NavigationService.Navigate(new EditProductPage(SelectedItem as Product));
            });

            DeleteProductCommand = new RelayCommand((o) =>
            {
                if (SelectedItem == null)
                {
                    return;
                }

                Product product = SelectedItem as Product;
                businessLogicLayer.DeleteProduct(product.ProductId);
                

            });
        }

        public List<Product> PRODUCTS
        {             get { return Products; }
                   set { Products = value;
            OnPropertyChanged("PRODUCTS");
            }
        }
    }
}
