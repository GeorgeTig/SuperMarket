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
    internal class TableProducerViewModel
    {
        public List<Producer> Producers { get; set; }
        public BusinessLogicLayer BusinessLogicLayer { get; set; }
        public ICommand AddProducerCommand { get; set; }
        public ICommand ModifyProducerCommand { get; set; }
        public ICommand DeleteProducerCommand { get; set; }
        public object SelectedItem { get; set; } = null;
        public TableProducerViewModel() 
        {
            Producers = new List<Producer>();
            BusinessLogicLayer = new BusinessLogicLayer();
            Producers = BusinessLogicLayer.GetAllProducers();
            AddProducerCommand = new RelayCommand((o) =>
            {
                if (o is not Page page)
                {
                    return;
                }
                
                page.NavigationService.Navigate(new EditProducerPage());
            });

            ModifyProducerCommand = new RelayCommand((o) =>
            {
                if (o is not Page page)
                {
                    return;
                }
                if (SelectedItem == null)
                {
                    return;
                }
                page.NavigationService.Navigate(new EditProducerPage(SelectedItem as Producer));
            });

            DeleteProducerCommand = new RelayCommand((o) =>
            {
                if (SelectedItem == null)
                {
                    return;
                }

                Producer producer = SelectedItem as Producer;
                BusinessLogicLayer.DeleteProducer(producer.ProducerId);
                Producers = BusinessLogicLayer.GetAllProducers();
                
            });
        }
    }
}
