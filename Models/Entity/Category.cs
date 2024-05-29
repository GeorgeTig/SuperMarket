using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.Entity
{
     public  class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
