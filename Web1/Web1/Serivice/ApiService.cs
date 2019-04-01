using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web1.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Web1.Serivice
{
    public class ApiService
    {
        static HttpClient client = new HttpClient();
        //string pathGetAll = "https://localhost:5001/api/product/GetAllProduct";
        //string pathGetProductItem = "https://localhost:5001/api/product/GetProductItem/";
        //string pathPostProductItem = "https://localhost:5001/api/product/PostAddProduct";
        //string pathPutProduct="https://localhost:5001/api/product/PutProduct/"
        //string pathDeleteProduct= "https://localhost:5001/api/product/DeleteProduct/"

        //Store
        //string pathGetAllStore="https://localhost:5001/api/store/GetAllStore";
        //string pathGetItemStore="https://localhost:5001/api/store/GetItemStore/1";
        //string pathAddProductIntoStore="https://localhost:5001/api/store/AddProductIntoStore/1";
        //string pathUpdateProductInStore="https://localhost:5001/api/store/UpdateProductInStore/1/1";
        //string pathDeleteProductInStore="https://localhost:5001/api/store/DeleteProductInStore/1/1";
        //string pathGetAllProductInStore="https://localhost:5001/api/store/GetAllProductInStore/1";

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
        //
        public static async Task<Product> GetProductItem(int? idProduct)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/product/GetProductItem/" + idProduct);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<Product>(content);
                Console.WriteLine(product.NameProduct);
            }
            return product;
        }

        //Add Product
        public static async Task<Product> AddProductAsync(Product product)
        {
            Product item;
            string stringData = JsonConvert.SerializeObject(product);

            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/api/product/PostAddProduct", contentData);
            response.EnsureSuccessStatusCode();
            //return response.Headers.Location;

            var content = await response.Content.ReadAsStringAsync();
            item = JsonConvert.DeserializeObject<Product>(content);

            return item;
        }
        //Put
        //Update Product

        public static async Task<Product> UpdateProductAsync(int? idProduct, Product product)
        {
            Product item;
            string stringData = JsonConvert.SerializeObject(product);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(
                $"https://localhost:5001/api/product/PutProduct/" + idProduct, contentData);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            item = JsonConvert.DeserializeObject<Product>(content);
            return item;
        }

        //Delete
        //Delete Product
        public static async Task<List<Product>> DeleteProductAsync(int? idProduct)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:5001/api/product/DeleteProduct/" + idProduct);
            //list_product = await response.Content.ReadAsAsync<List<Product>>();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Product>>(content);
            return result;
        }

        //<----------------------Store---------------------------->>

        //Gel All Store
        public static async Task<List<Store>> GellAllStoreAsync()
        {
            List<Store> listStore = new List<Store>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/store/GetAllStore");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listStore = JsonConvert.DeserializeObject<List<Store>>(content);
            }
            return listStore;
        }

        //Get Item Store

        public static async Task<List<Store>> GetItemStoreAsync(int? idStore)
        {
            List<Store> store = new List<Store>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/store/GetItemStore/" + idStore);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                store = JsonConvert.DeserializeObject<List<Store>>(content);
            }
            return store;
        }

        //Add Product Into Store

        public static async Task<List<Product>> AddProductIntoStoreAsync(int? idStore, Product product)
        {
            List<Product> _listProduct = new List<Product>();

            string stringData = JsonConvert.SerializeObject(product);

            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/api/store/AddProductIntoStore/" + idStore, contentData);
            response.EnsureSuccessStatusCode();
            //return response.Headers.Location;

            var content = await response.Content.ReadAsStringAsync();
            _listProduct = JsonConvert.DeserializeObject<List<Product>>(content);

            return _listProduct;
        }

        //Update Product In Store

        public static async Task<List<Product>> UpdateProductInStoreAsync(int? idStore, int? idProduct, Product product)
        {
            List<Product> _listProduct = new List<Product>();
            string stringData = JsonConvert.SerializeObject(product);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(
                $"https://localhost:5001/api/store/UpdateProductInStore/" + idStore + "/" + idProduct, contentData);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            _listProduct = JsonConvert.DeserializeObject<List<Product>>(content);

            return _listProduct;
        }

        //Remove Product In Store

        public static async Task<List<Product>> DeleteProductInStoreAsync(int? idStore, int? idProduct)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:5001/api/store/DeleteProductInStore/" + idStore + "/" + idProduct);
            //list_product = await response.Content.ReadAsAsync<List<Product>>();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Product>>(content);
            return result;
        }


        //Get all product in Store

        public static async Task<List<Product>> GetAllProductInStoreAsync(int? idStore)
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/store/GetAllProductInStore/" + idStore);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Product>>(content);
            return result;
        }
    } 
}