using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Product harddisk = new Product(50);
            harddisk.ProductName = "Seagate";
            Product android= new Product(50);
            android.ProductName = "Huawei";
            android.StockControlEvent += Android_StockControlEvent;

            for (int i = 0; i < 10; i++)
            {
                harddisk.Sell(10);
                android.Sell(10);
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static void Android_StockControlEvent()
        {
            Console.WriteLine("Low Stock Amount!");
        }
    }
}
