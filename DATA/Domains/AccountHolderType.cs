using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
   public class AccountHolderType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AccountHolder> AccountHolder { get; set; }
    }
}
