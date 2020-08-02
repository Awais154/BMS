using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
   public class Ledger:BaseEntity
    {
        public string Transection { get; set; }
        public decimal Total { get; set; }
        public decimal AmountIn { get; set; }
        public decimal AmountOut { get; set; }
        public decimal Balance { get; set; }

        public int? SaleId { get; set; }
        public Sale Sale { get; set; }

        public int? PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        public int AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }

        public int InsertionTypeId { get; set; }
        public InsertionType InsertionType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
