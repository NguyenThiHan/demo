using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Web2.Service;
using Web2.Models;

namespace Web2.Controllers
{
    public class GetProductController : Controller
    {
        static HttpClient client = new HttpClient();
        //ClientIndexModel model = new ClientIndexModel();
        // GET: GetProduct
        public async System.Threading.Tasks.Task<ActionResult> GetAllProduct()
        {
            var model = new ClientIndexModel();
            model.Title = "Product List";
            //call API
            model.Products = await ApiService.GetAllProductInList();
            return View(model);
        }
        public async System.Threading.Tasks.Task<ActionResult> GetProductItem(int idProduct)
        {
            var model = new ClientIndexModel();
            model.Title = "Product Details";
            //
            model.product = await ApiService.GetProductItem(idProduct);
            return View(model);
        }


        public async System.Threading.Tasks.Task<ActionResult> AddProduct(Product product)
        {
            var model = new ClientIndexModel();
            model.Title = "Add Product";
            model.Products = await ApiService.AddProductAsync(product);

            return View(model);
        }


    }
}