using ICommandDemoAgain.Commands;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperMarket.ViewModel.EditPagesViewModel
{
    public  class StockEditViewModel : BaseViewModel
    {
        BusinessLogicLayer businessLogicLayer { get; set; }
        public decimal _quantity { get; set; }
        public List<string> _productsName { get; set; }
        public object SelectedProduct { get; set; }
        public List<string> _unitsName { get; set; }
       
        public object SelectedUnit { get; set; }
       
        public decimal _price { get; set; }
        public object SelectedSup { get; set; }
        public object SelectedExp { get; set; }
        public ICommand Button { get; set; }

        public StockEditViewModel()
        {
            businessLogicLayer = new BusinessLogicLayer();
            _price = 0;
            _quantity = 0;
            List<Product> products = businessLogicLayer.GetAllProducts();
            _productsName = new List<string>();
            foreach (Product product in products)
            {
                _productsName.Add(product.Name);
            }

            _unitsName = new List<string>();
            _unitsName.Add("KG");
            _unitsName.Add("L");
            _unitsName.Add("PCS");
            


            Button = new RelayCommand(o => Add());
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public List<string> ProductsName
        {
            get { return _productsName; }
            set
            {
                _productsName = value;
                OnPropertyChanged("ProductsName");
            }
        }

        public List<string> UnitsName
        {
            get { return _unitsName; }
            set
            {
                _unitsName = value;
                OnPropertyChanged("UnitName");
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        

        public void Add()
        {
            if (SelectedProduct == null)
                return;
            if(SelectedUnit==null)
                return;
            if (SelectedExp == null)
                return;
            if (SelectedSup == null)
                return;
            string productName = SelectedProduct as string;
             
            string unitName = SelectedUnit as string;

            DateTime exp = (DateTime)SelectedExp;
            DateTime sup = (DateTime)SelectedSup;
            
            
            if(productName== "" || unitName=="" || _price==0||_quantity==0)
            {        
                System.Windows.MessageBox.Show("campurile nu pot fi goale!");
                return;
            }

            Product product = businessLogicLayer.GetProduct(productName);
            int unit = 0;
            if (unitName == "KG")
                unit = 0;
            if (unitName == "L")
                unit = 1;
            if (unitName == "PCS")
                unit = 2;

            businessLogicLayer.AddStock(product.ProductId, (int)_quantity, unit, _price, sup, exp);



            
        }
    }
}
