using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
   public class Product:BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int Availability { get; set; }
        [MaxLength(10)]
        public string Size { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        [MaxLength(100)]
        public string Detail { get; set; }
        [MaxLength(20)]
        public string Color { get; set; }
        [MaxLength(50)]
        public string BarCode { get; set; }
        [MaxLength(50)]
        public string ImeNumber { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<PurchaseItem> PurchaseItem { get; set; }
        public List<SoldItems> SoldItems { get; set; }
    }
}
