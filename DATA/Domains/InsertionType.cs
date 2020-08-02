using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
   public class InsertionType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ledger> Ledger { get; set; }
    }
}
