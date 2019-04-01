using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Web1.Models;
using Web1.Serivice;


namespace Web1.Controllers
{
    public class StoreController : Controller
    {
        static HttpClient client = new HttpClient();
        //Get All Product
        [HttpGet]

        //api/store/GetAllStore
        public async System.Threading.Tasks.Task<ActionResult> GetAllStore()
        {
            var model = new StoreIndexModel();
            model.Title= " List Store ";
            //call API
            model.Stores = await ApiService.GellAllStoreAsync();
            return View(model);
        }
        //Get Item Product
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> GetItemStore(int ? idProduct)
        {
            var model = new StoreIndexModel();
            model.Title = "Store";
            //call API
            model.Stores = await ApiService.GetItemStoreAsync(idProduct);
            return View(model);
        }

        //Add Product Into Store
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> GetAllProductInStore(int ? idStore)
        {
            var model = new StoreIndexModel();
            model.Title = "All Product In Store";
            //call API
            model.Products = await ApiService.GetAllProductInStoreAsync(idStore);
            return View(model);
        }

        //[HttpGet]
        //public ActionResult AddProductIntoStore()
        //{
        //    var model = new StoreIndexModel();
        //    return View(model);
        //}
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> AddProductIntoStore(int? idStore)
        {
            var model = new StoreIndexModel();
            //call API
            model.Stores = await ApiService.GellAllStoreAsync();
            model.Products = await ApiService.GetAllProductInList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> AddProduct(int idStore,Product product)
        {
            var model = new StoreIndexModel();
            model.Title = "Add Product Into Store";
            model.Products= await ApiService.AddProductIntoStoreAsync(idStore,product);
            //check
            return RedirectToAction("GetAllProductInStore");
        }

        //Update Product In Store
        //public ActionResult Index()
        //{
        //    return View();
        //}

    }
}