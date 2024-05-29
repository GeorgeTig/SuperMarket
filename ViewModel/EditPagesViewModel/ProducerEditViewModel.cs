using ICommandDemoAgain.Commands;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SuperMarket.ViewModel.EditPagesViewModel
{
    public class ProducerEditViewModel : BaseViewModel
    {
        public BusinessLogicLayer BusinessLogicLayer { get; set; }
        public string _producername;
        public string _producercountry;
        public string butonN;
        public string title;
        Producer producer;
        public string Title { get; set; }
        public string ButtonN { get; set; }
        public ICommand Button { get; set; }

        public ProducerEditViewModel()
        {
            BusinessLogicLayer = new BusinessLogicLayer();
            _producername = "";
            _producercountry = "";
            Button = new RelayCommand(o => Add());
            ButtonN = "Add";
            Title = "Add Producer";
        }

        public ProducerEditViewModel(Producer producer)
        {
            BusinessLogicLayer = new BusinessLogicLayer();
            this.producer = producer;
            _producername = producer.Name;
            _producercountry = producer.OriginCountry;
            Button = new RelayCommand(o => Modify());
            ButtonN = "Save";
            Title = "Modify Producer";
        }

        public string Name
        {
            get { return _producername; }
            set { _producername = value;
                OnPropertyChanged("Name");
            }
        }

        public string Country
        {
            get { return _producercountry; }
            set { _producercountry = value;
                OnPropertyChanged("Country");
            }
        }

        public void Add()
        {
            if(_producercountry == "" || _producername == "")
            {
                System.Windows.MessageBox.Show("campurile nu pot fi goale!");
                return;
            }

            if(BusinessLogicLayer.FindProducer(_producername)!=null)
            {
                MessageBox.Show("Producatorul exista deja!");
                return;
            }

            BusinessLogicLayer.AddProducer(_producername, _producercountry);
        }

        public void Modify()
        {
            if (_producercountry == "" || _producername == "")
            {
                System.Windows.MessageBox.Show("campurile nu pot fi goale!");
                return;
            }

            BusinessLogicLayer.UpdateProducer(producer.ProducerId, _producername, _producercountry);

        }

    }
}
