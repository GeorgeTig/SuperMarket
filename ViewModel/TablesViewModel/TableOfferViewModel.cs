using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.ViewModel.TablesViewModel
{
    public class TableOfferViewModel
    {
        public List<Offer> Offerss;
        public BusinessLogicLayer BusinessLogicLayer;
        public TableOfferViewModel() 
        {
            Offerss = new List<Offer>();
            BusinessLogicLayer = new BusinessLogicLayer();
            Offerss = BusinessLogicLayer.GetAllOffers();
        }
    }
}
