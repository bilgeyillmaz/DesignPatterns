using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public class CustomerManager
        {
            private static CustomerManager _customerManager;
            static object _lockobject = new object();
            private CustomerManager()
            {
                //burada nesneyi newleyemiyoruz. 
                var customerManager = CustomerManager.CreateAsSingleton(); //nesneye ancak bu şekilde erişebiliriz.
                customerManager.Save();

            }
            public static CustomerManager CreateAsSingleton()
            {
                lock (_lockobject)
                {
                    if (_customerManager == null)// customer manager daha önce oluşturulmuş mu? Oluşturulmamış ise oluştur.
                    {
                        _customerManager = new CustomerManager();
                    }
                }

                return _customerManager;
            }
            public void Save()
            {
                Console.WriteLine("Saved!");
            }

        }
    }
}
