using SuperMarket.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models.Entity;

namespace SuperMarket.Models.DataAccessLayer
{
    public class BusinessLogicLayer
    {
        private UserBLL userBLL = new UserBLL();
        private CategoryBLL categoryBLL = new CategoryBLL();
        private OfferBLL offerBLL = new OfferBLL();
        private StockBLL stockBLL = new StockBLL();
        private ReceiptBLL receiptBLL = new ReceiptBLL();
        private ProducerBLL producerBLL = new ProducerBLL();
        private ProductBLL productBLL = new ProductBLL();


        public void DeleteProduct(int id)
        {
            productBLL.DeleteProduct(id);
        }

        public User UserValidation(string username, string password)
        {
            return userBLL.FindUser(username, password);
        }
        public User GetUser(string username)
        {
            return userBLL.FindUser(username);
        }

        public void DeleteUser(int userId)
        {
            userBLL.DeleteUser(userId);
        }

        public List<User> GetAllUsers()
        {
            return userBLL.GetUsers();
        }

        public void AddUser(User user)
        {
            userBLL.AddUser(user);
        }

        public void UpdateUser(User user) 
        {
            userBLL.UpdateUser(user);
        }

        public List<Category> GetAllCategories()
        {
            return categoryBLL.GetAllCategories();
        }

        public Category GetCategory(int id)
        {
            return categoryBLL.GetCategory(id);
        }

        public void DeleteCategory(int id)
        {
            categoryBLL.DeleteCategory(id);
        }

        public Category GetCategory(string name)
        {
            return categoryBLL.GetCategory(name);
        }

        public Category GetCategoryById(int id)
        {
            return categoryBLL.GetCategoryById(id);
        }

        public void AddCategory(string name)
        {
            categoryBLL.AddCategory(name);
        }

        public void UpdateCategory(int Id, string Name)
        {
            categoryBLL.UpdateCategory(Id, Name);
        }

        public List<Offer> GetAllOffers()
        {
            return offerBLL.GetAllOffers();
        }

        public List<Producer> GetAllProducers()
        {
            return producerBLL.GetAllProducers();
        }

        public Producer FindProducer(string name)
        {
            return producerBLL.FindProducer(name);
        }

        public Producer GetProducerById(int id)
        {
            return producerBLL.GetProducerById(id);
        }

        public void UpdateProduct(int id, string name, string barcode, int categoryId, int producerId)
        {
            productBLL.UpdateProduct(id, name, barcode, categoryId, producerId);
        }

        public void AddProduct(string name, string barcode, int categoryId, int producerId)
        {
            productBLL.AddProduct(name, barcode, categoryId, producerId);
        }
        public void AddProducer(string name, string country)
        {
            producerBLL.AddProducer(name, country);
        }

        public void UpdateProducer(int id, string name, string country)
        {
            producerBLL.UpdateProducer(id, name, country);
        }

        public void DeleteProducer(int id)
        {
            producerBLL.DeleteProducer(id);
        }

        public List<Product> GetAllProducts() 
        {
            return productBLL.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return productBLL.GetProduct(id);
        }

        public Product GetProduct(string name,string type)
        {
            if(type != "Producer" && type != "Category")
                return productBLL.GetProduct(name, type);
            else
            {
                List<Product> products = new List<Product>();
                products = productBLL.GetAllProducts();
                foreach (Product p in products)
                {
                    if (type == "Producer")
                    {
                        Producer producer = producerBLL.GetProducerById(p.ProductId);
                        if (producer.Name == name)
                        {
                            return p;
                        }
                    }
                    if (type == "Category")
                    {
                        Category category = categoryBLL.GetCategoryById(p.ProductId);
                        if (category.Name == name)
                        {
                            return p;
                        }
                    }
                }
            }
            return null;
        }

        public Product GetProduct(string name)
        {
           return productBLL.GetProduct(name);
        }
        public void AddStock(int ProductId, int Quantity, int Unit, decimal PurchasePrice, DateTime SupplyDate, DateTime ExpiryDate)
        {
            stockBLL.AddStock(ProductId, Quantity, Unit, PurchasePrice, SupplyDate, ExpiryDate);
        }
        public List<Product> GetProductsPrefix(string name, string type)
        {

            
            
            return null;
        }


        public Product GetProduct(DateTime exp, string type)
        {
            List<Stock> stocks = new List<Stock>();
            stocks = stockBLL.GetAllStocks();
            foreach (Stock s in stocks)
            {
                if(s.ExpiryDate == exp)
                {
                    return productBLL.GetProduct(s.ProductId);
                }
            }
            return null;
        }

        public List<Receipt> GetAllReceipts()
        {
            return receiptBLL.GetAllReceipts();
        }

        public List<Stock> GetAllStocks()
        {
            return stockBLL.GetAllStocks();
        }
    }
}
