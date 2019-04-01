using System;
using System.Collections.Generic;
using WebAPI.Interface;
using WebAPI.Model;
using WebAPI.Data;
using WebAPI.Singleton;
using System.Linq;

namespace WebAPI.Service
{
    public class StoreService : IStore
    {
        //Data
        StoreDB db;
        public StoreService()
        {
            var instance = SingletonProduct.Instance();
            db = instance.StoreDB;
            //InitDummyData();
            if (!instance.CheckData)
            {
                instance.CheckData = true;
                DataStore();
            }
        }

        public List<Store> GetListStore()
        {
            return db._listStore;
        }

        public void AddStore(Store store)
        {
            db._listStore.Add(store);
        }

        public void Add(Store store)
        {
            var maxStoreId = db._listStore.Max(n =>n.IdStore);
            store.IdStore = ++maxStoreId;
            db._listStore.Add(store);
        }

        public List<Product> AddProductIntoStore(int idStore, Product product)
        {
            Store store = db._listStore.Find(id => id.IdStore == idStore);
            if(store != null)
            {
                store.listProduct.Add(product);
                return store.listProduct;
            }
            else
            {
                return null;
            }
        }
        public Product FindProductInStore(int idStore, int idProduct)
        {
            //find Store 
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            //check store
            return store != null ? store.listProduct.Find(item => item.IdProduct == idProduct) : null;
        }

       

       

        public List<Product> RemoveProductInStore(int idStore, int idProduct)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            Product product = store.listProduct.Find(item => item.IdProduct == idProduct);

            store.listProduct.Remove(product);
            return store.listProduct;
        }

        public List<Product> UpdateProductInStore(int idStore,int idProduct,Product product)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            Product result = store.listProduct.Find(item => item.IdProduct == idProduct);
            
           if(result!=null)
            {
                result.IdProduct = product.IdProduct;
                result.NameProduct = product.NameProduct;
                result.QualityProduct = product.QualityProduct;
                result.CodeProduct = product.CodeProduct;

                return store.listProduct;
            }
            return null;
        }

        public void RemoveStore(int idStore)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            db._listStore.Remove(store);
        }

        public void UpdateProduct(int idStore, Store store)
        {
            Store result = db._listStore.Find(item => item.IdStore == idStore);
            if (result != null)
            {
                result.IdStore = store.IdStore;
                result.NameStore = store.NameStore;
            }
            else
            {
                Console.WriteLine("NotFound");
            }
        }

        public List<Product> GetAllProductInStore(int idStore)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            return store.listProduct;
        }

        public Store FindStoreItem(int idStore)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            return store;
        }
        public void DataStore()
        {
            Store store1 = new Store(1, "Store1");
            Store store2 = new Store(2, "Store2");
            Store store3 = new Store(3, "Store3");

            AddStore(store1);
            AddStore(store2);
            AddStore(store3);
        }


      
    }
}
