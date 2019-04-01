using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web1.Models
{
    public class StoreIndexModel
    {
        public string Title { get; set; }

        public List<Store> Stores { get; set; }

        public List<Product> Products { get; set; }
        public Product product;

        public Boolean value;

        public Store store;
        public StoreIndexModel()
        {
            Stores = new List<Store>();

            Products = new List<Product>();
        }
    }
}