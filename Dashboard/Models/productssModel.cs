using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dashboard.Models
{
    public class ProductsModel
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public string Size { get; set; }

        public string Brand { get; set; }

        public string Detail { get; set; }

        public string Color { get; set; }

        public string ImeNumber { get; set; }

        public int ProductId { get; set; }

    }
}