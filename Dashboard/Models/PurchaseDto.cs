using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DATA.Domains;

namespace Dashboard.Models
{
    public class purchaseDto:BaseEntity
    {
        public int ProductId { get; set; }
        public int PurchaseId { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal AmountIn { get; set; }
        public decimal AmountOut { get; set; }
        public decimal Balance { get; set; }
    }
}