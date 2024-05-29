using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;
using SuperMarket.Models.BusinessLogicLayer;


namespace SuperMarket.Models.BusinessLogicLayer
{
    public class ProductBLL
    {
        private ProductDAL productDAL = new ProductDAL();

        public List<Product> GetAllProducts()
        {
            return productDAL.GetProducts();
        }

        public Product GetProduct(string name)
        {
            List<Product> products = new List<Product>();
            products = productDAL.GetProducts();
            foreach (Product p in products)
            {
                if (p.Name.ToLower() == name.ToLower())
                {
                    return p;
                }
            }
            return null;
        }

        public Product GetProduct(int id)
        {
            return productDAL.GetAProduct(id);
        }

        public List<Product> GetProducts(string name, string type)
        {
            List<Product> Products = new List<Product>();

            if (type == "Name")
            {
                List<Product> products = new List<Product>();
                products = productDAL.GetProducts();
                foreach (Product p in products)
                {
                    
                    if (p.Name.ToLower()==name.ToLower())
                    {
                        Products.Add(p);
                    }
                }
            }

            if (type == "Barcode")
            {
                List<Product> products = new List<Product>();
                products = productDAL.GetProducts();
                foreach (Product p in products)
                {
                    if (p.Barcode==name)
                    {
                        Products.Add(p);
                    }
                }
            }


            return null;

        }

        public Product GetProduct(string name, string type)
        {
            
            
            if(type == "Name")
            {
                List<Product> products = new List<Product>();
                products = productDAL.GetProducts();
                foreach (Product p in products)
                {
                    if (p.Name == name)
                    {
                        return p;
                    }
                }
            }

            if(type == "Barcode")
            {
                List<Product> products = new List<Product>();
                products = productDAL.GetProducts();
                foreach (Product p in products)
                {
                    if (p.Barcode == name)
                    {
                        return p;
                    }
                }
            }
            
            
            return null;

        }
        public void AddProduct(string name, string barcode, int categoryId, int producerId)
        {
            productDAL.AddProduct(name, barcode, categoryId, producerId);
        }

        public void UpdateProduct(int id, string name, string barcode, int categoryId, int producerId)
        {
            productDAL.UpdateProduct(id, name, barcode, categoryId, producerId);
        }

        public void DeleteProduct(int id)
        {
            productDAL.DeleteProduct(id);
        }
    }
}
