using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DATA.Domains;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class UserModel:BaseEntity
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
        //public Trademark Trademark { get; set; }
        //public List<Ledger> Ledger { get; set; }
    }
}