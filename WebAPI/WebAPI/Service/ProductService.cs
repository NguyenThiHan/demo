using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Data;
using WebAPI.Singleton;
using WebAPI.Interface;


namespace WebAPI.Service
{
    public class ProductService : IProduct
    {
        ProductDB db;
        public ProductService()
        {
            var instance = SingletonProduct.Instance();
            db = instance.ProductDB;

            if (!instance.IsInitDummyData)
            {
                instance.IsInitDummyData = true;
                InitDummyData();
            }
        }

        //ham lay tat ca list
        public List<Product> GetListProduct()
        {
            return db._listProduct;
        }

        //Them 1 san pham
        public void AddProduct(Product product)
        {
            //get max id
            //var maxProductId = (from c in db._listProduct select c.IdProduct).Max();
            //var maxProductId = db._listProduct.Max(n => n.IdProduct);
            //product.IdProduct = ++maxProductId; 

            db._listProduct.Add(product);
        }

        public void Add(Product product)
        {
            var maxProductId = db._listProduct.Max(n => n.IdProduct);
            product.IdProduct = ++maxProductId;

            db._listProduct.Add(product);
        }
        //xoa 1 san pham
        public void RemoveProduct(Product product)
        {
            db._listProduct.Remove(product);
        }
        //cap nhat 1 sản phẩm
        public void UpdateProduct(int idProduct, Product p)
        {
            Product product = db._listProduct.Find(item => item.IdProduct == idProduct);
            if (product != null)
            {
                product.IdProduct = p.IdProduct;
                product.NameProduct = p.NameProduct;
                product.CodeProduct = p.CodeProduct;
                product.QualityProduct = p.QualityProduct;
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        //tim kiem 1 san pham  tra ve san pham
        Product IProduct.FindProduct(int idProduct)
        {
            Product product = db._listProduct.Find(item => item.IdProduct == idProduct);
            if (product != null)
            {
                return product;
            }
            return null;
        }
        // Xoa 1 san pham
        public Boolean RemoveInProduct(int idProduct)
        {
            Product product = db._listProduct.Find(item => item.IdProduct == idProduct);
            if (product != null)
            {
                RemoveProduct(product);
                return true;
            }
            return false;
        }

        public void InitDummyData()
        {
            Product product1 = new Product(1, "Item1", "Code1", "Good");
            Product product2 = new Product(2, "Item2", "Code2", "Bad");
            Product product3 = new Product(3,"Item3", "Code3", "Good");
            Product product4 = new Product(4,"Item4", "Code4", "Bad");
            Product product5 = new Product(5, "Item5", "Code5", "Good");

            AddProduct(product1);
            AddProduct(product2);
            AddProduct(product3);
            AddProduct(product4);
            AddProduct(product5);
        }
    }
}
