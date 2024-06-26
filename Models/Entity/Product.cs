﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Stock> Stocks { get; set; }
        




    }
}
