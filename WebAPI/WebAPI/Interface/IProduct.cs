using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Data;

namespace WebAPI.Interface
{
    public interface IProduct
    {
        List<Product> GetListProduct();
        //Product AddProduct(Product product);
        void AddProduct(Product product);
        void Add(Product product);
        void RemoveProduct(Product product);
        Product FindProduct(int idProduct);
        void UpdateProduct(int idProduct,Product product);
        Boolean RemoveInProduct(int idProduct);
    }
}
