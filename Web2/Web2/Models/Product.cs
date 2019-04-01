using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web2.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string CodeProduct { get; set; }
        public string QualityProduct { get; set; }

        public Product()
        {

        }

        public Product(int idProduct, string nameProduct, string codeProduct, string qualityProduct)
        {
            IdProduct = idProduct;
            NameProduct = nameProduct;
            CodeProduct = codeProduct;
            QualityProduct = qualityProduct;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, NameProduct: {1}, CodeProduct: {2}, QualityProduct: {3}", IdProduct, NameProduct, CodeProduct, QualityProduct);
        }
    }
}