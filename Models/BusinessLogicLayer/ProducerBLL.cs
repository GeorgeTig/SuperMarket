using SuperMarket.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models.Entity;

namespace SuperMarket.Models.BusinessLogicLayer
{
    class ProducerBLL
    {
        private ProducerDAL producerDAL = new ProducerDAL();

        public List<Producer> GetAllProducers()
        {
            return producerDAL.GetProducers();
        }

        public void AddProducer(string name, string country)
        {
            producerDAL.AddProducer(name,country);
        }

        public void UpdateProducer(int id, string name, string country)
        {
            producerDAL.UpdateProducer(id, name, country);
        }

        public Producer GetProducerById(int id)
        {
            return producerDAL.GetAProducer(id);
        }
        public void DeleteProducer(int id)
        {
            producerDAL.DeleteProducer(id);
        }

        public Producer FindProducer(string name)
        {
            List<Producer> producers = producerDAL.GetProducers();
            foreach (Producer producer in producers)
            {
                if (producer.Name.ToLower() == name.ToLower())
                {
                    return producer;
                }
            }
            return null;
        }
    }
}
