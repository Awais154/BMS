﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
    public class SoldItems:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
