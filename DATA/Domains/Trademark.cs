using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
    public class Trademark : BaseEntity
    {
        public Trademark()
        {
            AccountHolder = new List<AccountHolder>();
        }

        [MaxLength(30)]
        public string BussinessName { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(300)]
        public string Detail { get; set; }
        [MaxLength(15)]
        public string Contact { get; set; }
        [MaxLength(20)]
        public string OwnerName { get; set; }

        public List<Category> Category { get; set; }
        public List<User> User { get; set; }
        public List<AccountHolder> AccountHolder { get; set; }
        public string UniqueKey { get; set; }
        public bool OnTrial { get; set; }
        public bool TrialExpired { get; set; }
        public DateTime TrialStartedOn { get; set; }
        public int TrialPeriod { get; set; }
    }
}
