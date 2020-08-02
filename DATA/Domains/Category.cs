using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
   public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TradeMarkId { get; set; }
        public Trademark Trademark { get; set; }
        public List<Product> Product { get; set; }
    }
}
