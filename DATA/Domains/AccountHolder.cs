using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
  public class AccountHolder:BaseEntity
    {
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string Contact { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(200)]
        public string Detail { get; set; }
        public string TradeMarkUniqueKey { get; set; }
        [MaxLength(50)]
        public string BankAccountNumber { get; set; }

        public int AccountHolderTypeID { get; set; }
        public AccountHolderType AccountHolderType { get; set; }

        public int TradeMarkID { get; set; }
        public Trademark Trademark { get; set; }
        public List<Ledger> Ledger { get; set; }
    }
}
