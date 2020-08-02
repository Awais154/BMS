using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
   public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<PurchaseItem> PurchaseItem { get; set; }
        public List<Ledger> Ledger { get; set; }
    }
}
