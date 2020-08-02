using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class ProductModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public int Availability { get; set; }
        [MaxLength(10)]
        public string Size { get; set; }
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(100)]
        public string Detail { get; set; }
        [MaxLength(20)]
        public string Color { get; set; }
        [MaxLength(50)]
        public string BarCode { get; set; }
        [MaxLength(50)]
        public string ImeNumber { get; set; }
        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }
    }

    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

    }
}