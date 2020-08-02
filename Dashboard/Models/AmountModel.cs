using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Models
{
    public class AmountModel
    {
        public decimal Total { get; set; }

        public decimal AmountIn { get; set; }

        public decimal AmountOut { get; set; }

        public decimal Balance { get; set; }

        public int AccountHolderId { get; set; }

        public int InsertionTypeId { get; set; }
    }
}