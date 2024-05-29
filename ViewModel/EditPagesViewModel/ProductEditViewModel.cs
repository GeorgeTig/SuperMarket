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
    public class ProductEditViewModel : BaseViewModel
    {
        public string _name { get; set; }
        public string _barcode { get; set; }
        public string Title { get; set; }
        public string ButtonN { get; set; }
        public List<Producer> producers { get; set; }
        public List<string > producersName { get; set; }
        public List<Category> categories { get; set; }
        public List<string> categoriesName { get; set; }
        BusinessLogicLayer businessLogicLayer = new BusinessLogicLayer();
        public object SelectedProducer { get; set; } = null;
        public object SelectedCategory { get; set; } = null;
        public ICommand Button { get; set; }
        public ProductEditViewModel()
        {
            _name = "";
            _barcode = "";
            categories = new List<Category>();
            producers = new List<Producer>();
            categories = businessLogicLayer.GetAllCategories();
            categoriesName = new List<string>();
            for (int i = 0; i < categories.Count; i++)
            {
                categoriesName.Add(categories[i].Name);
            }
            producers = businessLogicLayer.GetAllProducers();
            producersName = new List<string>();
            for (int i = 0; i < producers.Count; i++)
            {
                producersName.Add(producers[i].Name);
            }
            Button = new RelayCommand((o) => Add());
            Title = "Add Product";
            ButtonN = "Add";
        }
        public ProductEditViewModel(Product product)
        {
            _name = product.Name;
            _barcode = product.Barcode;
            categories = new List<Category>();
            producers = new List<Producer>();
            categories = businessLogicLayer.GetAllCategories();
            categoriesName = new List<string>();
            for (int i = 0; i < categories.Count; i++)
            {
                categoriesName.Add(categories[i].Name);
            }
            producers = businessLogicLayer.GetAllProducers();
            producersName = new List<string>();
            for (int i = 0; i < producers.Count; i++)
            {
                producersName.Add(producers[i].Name);
            }
            Button = new RelayCommand((o) => Modify(product));
            SelectedCategory = businessLogicLayer.GetCategoryById(product.CategoryId).Name;
            SelectedProducer = businessLogicLayer.GetProducerById(product.ProducerId).Name;
            Title = "Modify Product";
            ButtonN = "Save";
        }
        

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                OnPropertyChanged("Barcode");
            }
        }

        public void Add()
        {
            if (_name == "")
            {
                System.Windows.MessageBox.Show("Introduceti un nume!");
                return;
            }
            if (_barcode == "")
            {
                System.Windows.MessageBox.Show("Introduceti un cod de bare!");
                return;
            }
            if (SelectedCategory == null)
            {
                System.Windows.MessageBox.Show("Selectati o categorie!");
                return;
            }
            if (SelectedProducer == null)
            {
                System.Windows.MessageBox.Show("Selectati un producator!");
                return;
            }

           

            Product product = new Product();
            string producerName = SelectedProducer as string;
            string categoryName = SelectedCategory as string;
            product.Name = _name;
            product.Barcode = _barcode;
            product.ProducerId = businessLogicLayer.FindProducer(producerName).ProducerId;
            product.CategoryId = businessLogicLayer.GetCategory(categoryName).CategoryID;
            businessLogicLayer.AddProduct(product.Name, product.Barcode, product.CategoryId, product.ProducerId);
        }

        public void Modify(Product product)
        {
            if (_name == "")
            {
                System.Windows.MessageBox.Show("Introduceti un nume!");
                return;
            }
            if (_barcode == "")
            {
                System.Windows.MessageBox.Show("Introduceti un cod de bare!");
                return;
            }
            if (SelectedCategory == null)
            {
                System.Windows.MessageBox.Show("Selectati o categorie!");
                return;
            }
            if (SelectedProducer == null)
            {
                System.Windows.MessageBox.Show("Selectati un producator!");
                return;
            }

            product.Name = _name;
            product.Barcode = _barcode;
            product.ProducerId = businessLogicLayer.FindProducer(SelectedProducer as string).ProducerId;
            product.CategoryId = businessLogicLayer.GetCategory(SelectedCategory as string).CategoryID;
            businessLogicLayer.UpdateProduct(product.ProductId, product.Name, product.Barcode, product.CategoryId, product.ProducerId);

        }
    }
}
