using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
   public class PurchaseItem:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
    }
}
