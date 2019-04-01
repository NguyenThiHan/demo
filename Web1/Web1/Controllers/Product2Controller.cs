using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Models;
using System.Net.Http;
using Web1.Serivice;
using System.Net;
using System.Threading.Tasks;

namespace Web1.Controllers
{
    public class Product2Controller : Controller
    {

        static HttpClient client = new HttpClient();
        //ClientIndexModel model = new ClientIndexModel();
        // GET: product2/GetAllProduct

         [HttpGet]
        public async Task<ActionResult> GetAllProduct()
        {
            //var model = new ProductIndexModel();
            //model.Title = "Product List";
            ////call API
            //model.Products = await ApiService.GetAllProductInList();
            //return View(model);
            //return View();

            var model = new ProductIndexModel();
            model.Title = "Product List";
            //call API
            model.Products = await ApiService.GetAllProductInList();

            //model.Products = await Task.Run(() => ApiService.GetAllProductInList());

            return PartialView("Partials/_GetAllProduct", model);
        }

        //[HttpGet]
        ////product2/GetAllProduct2
        //public async Task<ActionResult> GetAllProduct2()
        //{
        //    var model = new ProductIndexModel();
        //    model.Title = "Product List";
        //    //call API
        //    model.Products = await ApiService.GetAllProductInList();

        //    //model.Products = await Task.Run(() => ApiService.GetAllProductInList());

        //    return PartialView("Partials/_GetAllProduct", model);
        //}

        [HttpGet]
        //product2/GetAllProduct2
        public ActionResult GetTest()
        {
            var content = "Test " + DateTime.Now;
            return Content(content);
        }

        //get
        //api/product/GetProductItem/1
        //[Route("DetailProduct/{idProduct}")]
        //public async System.Threading.Tasks.Task<ActionResult> DetailProduct(int? idProduct)
        //{
        //    var model = new ProductIndexModel();
        //    model.Title = "Product Details";
        //    Console.WriteLine(idProduct);

        //    model.product = await ApiService.GetProductItem(idProduct);
        //    //
        //    //Console.WriteLine(model.product.IdProduct);
        //    //Console.WriteLine(model.product.NameProduct);
        //    //Console.WriteLine(model.product.CodeProduct);
        //    return View(model);
        //}
        public async Task<ActionResult> DetailProduct(int? idProduct)
        {
            var model = new ProductIndexModel();
            model.Title = "Product Details";
            Console.WriteLine(idProduct);

            model.product = await ApiService.GetProductItem(idProduct);
            return PartialView("Partials/_DetailProduct", model);
        }



        //Get
        //Details

        //Add Product
        //product/AddProduct
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult AddProduct()
        //{
        //    var model = new ProductIndexModel();
        //    return View(model);
        //}

        public ActionResult AddProduct()
        {
            var model = new ProductIndexModel();
            model.Title = "Add Product";
            return PartialView("Partials/_AddProduct");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async System.Threading.Tasks.Task<ActionResult> AddProduct(Product product)
        //{
        //    var model = new ProductIndexModel();
        //    model.Title = "Add Product";
        //    model.product = await ApiService.AddProductAsync(product);
        //    //check
        //    model.Products = await ApiService.GetAllProductInList();
        //    return RedirectToAction("GetAllProduct");

        //}
        //
        public async Task<ActionResult> AddProduct(Product product)
        {
            var model = new ProductIndexModel();
            model.Title = "Add Product";
            model.product = await ApiService.AddProductAsync(product);
            //check
            model.Products = await ApiService.GetAllProductInList();
            //return RedirectToAction("GetAllProduct");
            return PartialView("Partials/_GetAllProduct", model);
        }
        //PUT
        //product/UpdateProduct
        //public async System.Threading.Tasks.Task<ActionResult> UpdateProduct(int? idProduct)
        //{
        //    var model = new ProductIndexModel();
        //    model.product = await ApiService.GetProductItem(idProduct);
        //    return View(model);
        //}

        public async Task<ActionResult> UpdateProduct(int? idProduct)
        {
            var model = new ProductIndexModel();
            model.product = await ApiService.GetProductItem(idProduct);
            return PartialView("Partials/_UpdateProduct", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async System.Threading.Tasks.Task<ActionResult> UpdateProduct(int? idProduct, Product product)
        //{
        //    var model = new ProductIndexModel();
        //    model.Title = "Update Product";
        //    model.product = await ApiService.UpdateProductAsync(idProduct, product);
        //    model.Products = await ApiService.GetAllProductInList();
        //    return RedirectToAction("GetAllProduct");
        //}

        public async Task<ActionResult> UpdateProduct(int? idProduct, Product product)
        {
            var model = new ProductIndexModel();
            model.Title = "Update Product";
            model.product = await ApiService.UpdateProductAsync(idProduct, product);
            model.Products = await ApiService.GetAllProductInList();
            return PartialView("Partials/_GetAllProduct", model);
        }

        //public async Task<ActionResult> DeleteProduct(int? idProduct)
        //{
        //    var model = new ProductIndexModel();
        //    model.product = await ApiService.GetProductItem(idProduct);
        //    return PartialView("Partials/_DeleteProduct",model);
        //}

        //DELETE
        //product/DeleteProduct?idProduct=1
        //public async System.Threading.Tasks.Task<ActionResult> DeleteProduct(int? idProduct)
        //{
        //    var model = new ProductIndexModel();
        //    model.Title = "Delete Product";
        //    model.Products = await ApiService.DeleteProductAsync(idProduct);

        //    return RedirectToAction("GetAllProduct");
        //}

        //Delete
        public async Task<ActionResult> DeleteProduct(int? idProduct)
        {
            var model = new ProductIndexModel();
            model.Title = "Delete Product";
            model.Products = await ApiService.DeleteProductAsync(idProduct);
            return PartialView("Partials/_GetAllProduct", model);
        }
    }
}