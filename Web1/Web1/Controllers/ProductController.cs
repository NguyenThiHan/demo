using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Models;
using System.Net.Http;
using Web1.Serivice;
using System.Net;
using Web1.Controllers;


namespace Web1.Controllers
{
    public class ProductController : Controller
    {
      
        static HttpClient client = new HttpClient();
        //ClientIndexModel model = new ClientIndexModel();
        // GET: GetProduct                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
        public async System.Threading.Tasks.Task<ActionResult> GetAllProduct()
        {
            var model = new ProductIndexModel();
            model.Title = "Product List";
            //call API
            model.Products = await ApiService.GetAllProductInList();
            return View(model);
        }

        //get
        //api/product/GetProductItem/1
        //[Route("DetailProduct/{idProduct}")]
        public async System.Threading.Tasks.Task<ActionResult> DetailProduct(int ? idProduct)
        {
            var model = new ProductIndexModel();
            model.Title = "Product Details";
            Console.WriteLine(idProduct);
           
            model.product = await ApiService.GetProductItem(idProduct);
            //
            //Console.WriteLine(model.product.IdProduct);
            //Console.WriteLine(model.product.NameProduct);
            //Console.WriteLine(model.product.CodeProduct);
            return View(model);
        }

        //Get
        //Details

        //Add Product
        //product/AddProduct
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddProduct()
        {
            var model = new ProductIndexModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> AddProduct(Product product)
        {
            var model = new ProductIndexModel();
            model.Title = "Add Product";
            model.product = await ApiService.AddProductAsync(product);
            //check
            model.Products = await ApiService.GetAllProductInList();
            return RedirectToAction("GetAllProduct");
        }

        //PUT
        //product/UpdateProduct
        public async System.Threading.Tasks.Task<ActionResult> UpdateProduct(int ? idProduct)
        {
            var model = new ProductIndexModel();
            model.product = await ApiService.GetProductItem(idProduct);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> UpdateProduct(int ? idProduct, Product product)
        {
            var model = new ProductIndexModel();
            model.Title = "Update Product";
            model.product = await ApiService.UpdateProductAsync(idProduct, product);
            model.Products = await ApiService.GetAllProductInList();
            return RedirectToAction("GetAllProduct");
        }
        public async System.Threading.Tasks.Task<ActionResult> DeleteProductAsync(int ? idProduct)
        {
            var model = new ProductIndexModel();
            model.product = await ApiService.GetProductItem(idProduct);
            return View(model);
        }

        //DELETE
        //product/DeleteProduct?idProduct=1
        public async System.Threading.Tasks.Task<ActionResult> DeleteProduct(int ? idProduct)
        {
            var model = new ProductIndexModel();
            model.Title = "Delete Product";
            model.Products = await ApiService.DeleteProductAsync(idProduct);
            
            return RedirectToAction("GetAllProduct");
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> AddProductIntoStore(int? idStore)
        {
            var model = new StoreIndexModel();
            //call API
            model.Stores = await ApiService.GellAllStoreAsync();
            model.Products = await ApiService.GetAllProductInList();
            return View(model);
        }

        //product/AddProductIntoStore
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> AddProductIntoStore(int ? idStore, Product product)
        {
            var model = new StoreIndexModel();

            model.Title = "Add Product Into Store";
            model.Products = await ApiService.AddProductIntoStoreAsync(idStore, product);
            model.Stores = await ApiService.GellAllStoreAsync();
            //check
            return RedirectToAction("GetAllProductInStore","Store");
        }


    }
}