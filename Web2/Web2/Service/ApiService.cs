using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web2.Service
{
    public class ApiService
    {
        static HttpClient client = new HttpClient();

        //string pathGetAll = "https://localhost:5001/api/product/GetAllProduct";
        //string pathGetProductItem = "https://localhost:5001/api/product/GetProductItem?id=";
        //string pathPostProductItem = "https://localhost:5001/api/product/PostAddProduct";
        //string pathPutProduct="https://localhost:5001/api/product/PutProduct?id="
        //string pathDeleteProduct= "https://localhost:5001/api/product/DeleteProduct?id="

        //Get All Product In List
        public static async Task<List<Product>> GetAllProductInList()
        {
            List<Product> listproduct = new List<Product>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/product/GetAllProduct");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listproduct = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            return listproduct;

            //HttpResponseMessage response = client.GetAsync("https://localhost:5001/api/product/GetAllProduct").Result;
            //if (result.IsSuccessStatusCode)
            //{

            //    string stringData = result.Content.ReadAsStringAsync().Result;
            //    List<Product> data = JsonConvert.DeserializeObject<List<Product>>(listproduct);
            //}

        }


        //Get Product Item
        public static async Task<Product> GetProductItem(int idProduct)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/product/GetProductItem?id=" + idProduct);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<Product>(content);

                Console.WriteLine(product.NameProduct);
            }
            return product;
        }

        //Add Product
        public static async Task<List<Product>> AddProductAsync(Product product)
        {
            List<Product> listproduct;
            string stringData = JsonConvert.SerializeObject(product);

            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/api/product/PostAddProduct", contentData);
            response.EnsureSuccessStatusCode();
            //return response.Headers.Location;

            var content = await response.Content.ReadAsStringAsync();
            listproduct = JsonConvert.DeserializeObject<List<Product>>(content);

            return listproduct;
        }

        //Put
        //Update Product

        public static async Task<List<Product>> UpdateProduct(int idProduct, Product product)
        {
            string stringData = JsonConvert.SerializeObject(product);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(
                $"https://localhost:5001/api/product/PutProduct?id=" + idProduct, contentData);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var listproduct = JsonConvert.DeserializeObject<List<Product>>(content);
            return listproduct;
        }

        //Delete
        //Delete Product
        public static async Task<List<Product>> DeleteProduct(int idProduct)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:5001/api/product/DeleteProduct?id=" + idProduct);
            //list_product = await response.Content.ReadAsAsync<List<Product>>();

            var content = await response.Content.ReadAsStringAsync();
            var listproduct = JsonConvert.DeserializeObject<List<Product>>(content);
            return listproduct;
        }
    }
}