using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Singleton;
using WebAPI.Interface;
using WebAPI.Service;
using WebAPI.Model;
using WebAPI.Data;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        IProduct service;

        //public  static ProductDB listProduct = new ProductDB();

        //public void AddData()
        //{
        //    Product product1 = new Product(1, "Item1", "Code1", "Good");
        //    Product product2 = new Product(2, "Item2", "Code2", "Bad");
        //    Product product3 = new Product(3, "Item3", "Code3", "Good");
        //    Product product4 = new Product(4, "Item4", "Code4", "Bad");
        //    Product product5 = new Product(5, "Item5", "Code5", "Good");

        //    listProduct._listProduct.Add(product1);
        //    listProduct._listProduct.Add(product2);
        //    listProduct._listProduct.Add(product3);
        //    listProduct._listProduct.Add(product4);
        //    listProduct._listProduct.Add(product5);
        //}

        public ProductController()
        {
            service = new ProductService();
        }

        //Get all list product
        // GET api
        [HttpGet]
        [Route("GetAllProduct")]
        public List<Product> GetAllProduct()
        {
            return service.GetListProduct();
        }
        //GET
        //api/product/GetProductItem?id=
        [HttpGet("{id}")]
        [Route("GetProductItem/{id}")]
        public Product  GetProductItem(int id)
        {
            var itemProduct = service.FindProduct(id);
            return itemProduct;
        }

        //GET
        //api/product/Get
        //POST
        //api/Product/PostAddProduct
        [HttpPost]
        [Route("PostAddProduct")]
        public void PostAddProduct(Product product)
        {
            service.Add(product);
        }

        //Put-- update
        // api/product/PutProduct/
       [HttpPut("{id}")]
       [Route("PutProduct/{id}")]
       public void PutProduct(int id,Product product)
       {
            service.UpdateProduct(id, product);
            GetProductItem(product.IdProduct);
       }

        //Delete 
        //api
        [HttpDelete("{id}")]
        [Route("DeleteProduct/{id}")]
        public List<Product> DeleteProduct(int id)
        {
            service.RemoveInProduct(id);
            return service.GetListProduct();
        }


        [HttpGet("{id}")]
        [Route("FindProduct/{id}")]
        public Product FindProduct(int id)
        {
           Product product= service.FindProduct(id);
           return product;
        }

    }
}