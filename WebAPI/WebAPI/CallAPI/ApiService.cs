using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Data;
using WebAPI.Controllers;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebAPI.CallAPI
{
    public static class ApiService
    {

        static HttpClient client = new HttpClient();

        //string pathGetAll = "api/product/GetAllProduct";
        //string pathGetProductItem = "api/product/GetProductItem?id=";
        //string pathPostProductItem = "api/product/PostAddProduct";
        //string pathPutProduct="api/product/PutProduct?id="

        //Get All Product In List
        public static async Task<List<Product>> GetAllProductInList()
        {
            List<Product> listproduct = null;
            HttpResponseMessage response = await client.GetAsync("api/product/GetAllProduct");
            if (response.IsSuccessStatusCode)
            {
                listproduct = await response.Content.ReadAsAsync<List<Product>>();
            }
            return listproduct;
        }

        //Get Product Item
        public static async Task<Product> GetProductItem(int idProduct)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync("api/product/GetProductItem?id=" + idProduct);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
                Console.WriteLine(product.NameProduct);
            }
            return product;
        }

        //Add Product 
        public  static async Task<List<Product>> AddProductAsync(Product product)
        {
            List<Product> list_product;
            HttpResponseMessage response = await client.PostAsJsonAsync("api/product/PostAddProduct", product);
            response.EnsureSuccessStatusCode();
            //return response.Headers.Location;
            list_product = await response.Content.ReadAsAsync<List<Product>>();
            return list_product;
        }

        //Put
        //Update Product

        public static async Task<List<Product>> UpdateProduct(int idProduct, Product product)
        {
            List<Product> list_product;
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/product/PutProduct?id=" + idProduct, product);
            response.EnsureSuccessStatusCode();
            list_product = await response.Content.ReadAsAsync<List<Product>>();
            return list_product;
        }
       
        //Delete
        //Delete Product
        public static async Task<List<Product>> DeleteProduct(int idProduct)
        {
            List<Product> list_product;
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/product/DeleteProduct?id=" + idProduct);
            list_product = await response.Content.ReadAsAsync<List<Product>>();
            return list_product;
        }
    }

}
