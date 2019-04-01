using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web1.Models
{
    public class ProductIndexModel
    {
        public string Title { get; set; }

        public List<Product> Products { get; set; }

        public Boolean value;

        public Product product;
        public ProductIndexModel()
        {
            Products = new List<Product>();
        }
    }
}