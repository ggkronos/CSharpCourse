using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    public delegate void StockControl();
    //Kontrol eventini tanımladık.
    public class Product
    {
        private int _stock;

        public Product(int stock)
        {
            _stock = stock;
        }

        public string ProductName { get; set; }

        //Event kullanacağımız için get ve set i kendimiz ayarlamamız gerek
        public int Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                if (value<=15 && StockControlEvent!=null)
                {
                    StockControlEvent();
                }
            }
        }

        public event StockControl StockControlEvent;

        public void Sell(int amount)
        {
            Stock -= amount;
            Console.WriteLine("{1} Stock amount: {0}",Stock,ProductName);
        }

    }
}
