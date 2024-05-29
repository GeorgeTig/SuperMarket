
using ICommandDemoAgain.Commands;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperMarket.ViewModel
{
    internal class UserViewModel : BaseViewModel
    {
        public object _selectedSearchType { get; set; }
        public object _selectedProduct { get; set; }
        BusinessLogicLayer businessLogicLayer { get; set; }
        public string _name { get; set; }
        public string _barcode { get; set; }
        public string _producer { get; set; }
        public string _category { get; set; }
        List<Product> products { get; set; }
        public List<string> SearchSources { get; set; }
        public List<string> SearchType { get; set; }
        public List<string> _searchList { get; set; }
        
        public string _searchBar { get; set; }
        public User _user { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        
        public ICommand AddButton { get; set; }
        public ICommand Search { get; set; }
        public ICommand AddProductCommand { get; set; }

        public UserViewModel(User user)
        {
            if (Products == null)
            {
                Products = new ObservableCollection<Product>();
            }
            businessLogicLayer = new BusinessLogicLayer();
            _user = user;
            SearchType = new List<string> { "Name", "Barcode", "Producer", "Category", "ExpDate" };
            _searchBar = "";
            _searchList = new List<string>();
            products = new List<Product>();
            List<Product> productss = new List<Product>();
            productss = businessLogicLayer.GetAllProducts();
            foreach (Product product in productss)
            {
                _searchList.Add(product.Name);
                _searchList.Add(product.Barcode);
               
            }
            List<Producer> producers = new List<Producer>();
            producers = businessLogicLayer.GetAllProducers();
            foreach (Producer producer in producers)
            {
                _searchList.Add(producer.Name);
            }
            List<Category> categories = new List<Category>();
            categories = businessLogicLayer.GetAllCategories();
            foreach (Category category in categories)
            {
                _searchList.Add(category.Name);
            }
            List<Stock> stocks = new List<Stock>();
            stocks = businessLogicLayer.GetAllStocks();
            
            _name = ""; 
            _barcode = "";
            _producer = "";
            _category = "";
            
            AddButton = new RelayCommand(o => Add());
            Search = new RelayCommand(o => SearchButton());

        }

        

        public object SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value;
                  OnPropertyChanged("SelectedProduct");
                                                                   }
        }

        public object SelectedSearchType
        {
            get { return _selectedSearchType; }
            set { _selectedSearchType = value;
               
                                                            OnPropertyChanged("SelectedSearchType");
                                                        }
        }

        public List<string> SearchList
        {
            get { return _searchList; }
            set { _searchList = value;
                                                 OnPropertyChanged("SearchList");
                                             }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value;
                           OnPropertyChanged("Name");
                       }
        }

        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value;
                                      OnPropertyChanged("Barcode");
                                  }
        }

        public string Producer
        {
            get { return _producer; }
            set { _producer = value;
                                                 OnPropertyChanged("Producer");
                                             }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value;
                                                            OnPropertyChanged("Category");
                                                        }
        }

        public void SearchButton()
        {
            if(SelectedProduct == null)
            {
                return;
            }

            List<Product > p = new List<Product>();
            p = businessLogicLayer.GetAllProducts();
           
            Products.Clear();
            
            foreach (Product product in p)
            {
                if(product.Name == SelectedProduct.ToString())
                {
                    Products.Add(product);
                }
                if(product.Barcode == SelectedProduct.ToString())
                {
                    Products.Add(product);
                }
                
            }

            
        }

        public void Add()
        {

        }

        public void SearchListClk()
        {

        }

    }
}
