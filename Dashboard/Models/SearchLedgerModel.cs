using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Models
{
    public class SearchLedgerModel
    {
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public int AccountHolderId { get; set; }
        public int InsertionTypeId { get; set; }
    }
}