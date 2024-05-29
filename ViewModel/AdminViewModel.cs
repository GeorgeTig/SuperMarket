using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SuperMarket.ViewModel;
using ICommandDemoAgain.Commands;
using System.Windows.Controls;
using SuperMarket.View;
using System.Diagnostics;

namespace SuperMarket.ViewModel
{
    public class AdminViewModel : BaseViewModel
    {
        public Uri _frameSource { get; set; }

        public ICommand SearchButton { get; set; }
        public ICommand BiggestReceiptButton { get; set; }
        public ICommand ModifyOfferButton { get; set; }
        public ICommand CategoryButton { get; set; }
        public ICommand OfferButton { get; set; }
        public ICommand ProductButton { get; set; }
        public ICommand UserButton { get; set; }
        public ICommand ReceiptButton { get; set; }
        public ICommand ProducerButton { get; set; }
        public ICommand StockButton { get; set; }

        public AdminViewModel()
        {
            SearchButton = new RelayCommand(o => Search());
            BiggestReceiptButton = new RelayCommand(o => BiggestReceipt());
            ModifyOfferButton = new RelayCommand(o => ModifyOffer());
            CategoryButton = new RelayCommand(o => Category());
            OfferButton = new RelayCommand(o => Offer());
            ProductButton = new RelayCommand(o => Product());
            UserButton = new RelayCommand(o => User());
            ReceiptButton = new RelayCommand(o => Receipt());
            ProducerButton = new RelayCommand(o => Producer());
            StockButton = new RelayCommand(o => Stock());
        }

        public Uri FrameSource
        {
            get { return _frameSource; }
            set
            {
                _frameSource = value;
                OnPropertyChanged("FrameSource");
            }
        }

        public void Search()
        {

        }

        public void BiggestReceipt()
        {

        }

        public void ModifyOffer()
        {

        }

        public void Category()
        {
            FrameSource = new Uri("/View/Tables/CategoryTable.xaml", UriKind.Relative);
        }

        public void Offer()
        {
            FrameSource = new Uri("/View/Tables/OfferTable.xaml", UriKind.Relative);
        }

        public void Product()
        {
            FrameSource = new Uri("/View/Tables/ProductTable.xaml", UriKind.Relative);
        }

        public void User()
        {
            FrameSource = new Uri("/View/Tables/UserTable.xaml", UriKind.Relative);
        }

        public void Receipt()
        {
            FrameSource = new Uri("/View/Tables/ReceiptTable.xaml", UriKind.Relative);
        }

        public void Producer()
        {
            FrameSource = new Uri("/View/Tables/ProducerTable.xaml", UriKind.Relative);
        }

        public void Stock()
        {
            FrameSource = new Uri("/View/Tables/StockTable.xaml", UriKind.Relative);
        }

        

    }
}
