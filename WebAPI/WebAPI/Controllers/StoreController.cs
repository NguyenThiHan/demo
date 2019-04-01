using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface;
using WebAPI.Service;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        IStore service;
        public StoreController()
        {
            //
            service = new StoreService();
        }

        //GET
        //api/store/GetAllStore
        [HttpGet]
        [Route("GetAllStore")]
        public List<Store> GetAllStore()
        {
            return service.GetListStore();
        }

        //GET
        //api/store/GetItemStore
        [HttpGet]
        [Route("GetItemStore/{idStore}")]
        public Store GetItemStore(int idStore)
        {
            return service.FindStoreItem(idStore);

        }
        //api/store/AddProductIntoStore
        [HttpPost]
        [Route("AddProductIntoStore/{idStore}")]
        public List<Product> AddProductIntoStore(int idStore, Product product)
        {
            return service.AddProductIntoStore(idStore, product);
        }

        //api/store/DeleteProductInStore/1
        [HttpDelete]
        [Route("DeleteProductInStore/{idStore}/{idProduct}")]
        public List<Product> DeleteProductInStore(int idStore,int idProduct)
        {
            return service.RemoveProductInStore(idStore, idProduct);
        }


        [HttpPut]
        [Route("UpdateProductInStore/{idStore}/{idProduct}")]
        public List<Product> UpdateProductInStore(int idStore,int idProduct,Product product)
        {
            return service.UpdateProductInStore(idStore, idProduct, product);
        }

        //api/store/GetAllProductInStore/1
        [HttpGet]
        [Route("GetAllProductInStore/{idStore}")]
        public List<Product> GetAllProductInStore(int idStore)
        {
            return service.GetAllProductInStore(idStore);
        }

        //GET
        //
        //[HttpGet]
        //api/store/FindStore/1
        //public Store FindStore(int idStore)
        //{
        //    return service.FindStoreItem(idStore);
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}