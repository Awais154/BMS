using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
    public class User:BaseEntity
    {
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        [MaxLength(10)]
        public string Role { get; set; }

        public int TradeMarkId { get; set; }
        public Trademark Trademark { get; set; }
        public List<Ledger> Ledger { get; set; }
    }
}
