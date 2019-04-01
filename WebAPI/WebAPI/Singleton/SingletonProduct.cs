using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;

namespace WebAPI.Singleton
{
    public class SingletonProduct
    {
        private static SingletonProduct _instance;

        public static SingletonProduct Instance()
        {
            if (_instance == null)
            {
                _instance = new SingletonProduct();
            }
            return _instance;
        }

        //new ProductDB
        public ProductDB ProductDB = new ProductDB();
        public StoreDB StoreDB = new StoreDB();
        public bool IsInitDummyData = false;
        public bool CheckData=false;
    }
}
