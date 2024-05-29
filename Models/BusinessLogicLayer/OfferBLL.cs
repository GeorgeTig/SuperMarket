using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;

namespace SuperMarket.Models.BusinessLogicLayer
{
    class OfferBLL
    {
        private OfferDAL offerDAL = new OfferDAL();

        public List<Offer> GetAllOffers()
        {
            return offerDAL.GetOffers();
        }
    }
}
