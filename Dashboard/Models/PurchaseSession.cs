using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Models
{
    public class PurchaseSession : DATA.Domains.BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Availability { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public string Detail { get; set; }
        public string Color { get; set; }
        public string BarCode { get; set; }
        public string ImeNumber { get; set; }

    }
}