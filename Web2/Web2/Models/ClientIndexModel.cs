using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web2.Models
{
    public class ClientIndexModel
    {
        public string Title { get; set; }

        public  IList<Product> Products { get; set; }

        public  Product product;

        public ClientIndexModel()
        {
            Products = new List<Product>();
        }
    }
}