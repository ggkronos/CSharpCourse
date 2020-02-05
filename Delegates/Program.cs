using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        //void bir delegate tanımladık.Elçilik gibi düşenebiliriz.
        //Bundan bizden fazla elçi tanımlayabilir onlara görev atayabiliriz.
        public delegate void MyDelegate();
        static void Main(string[] args) 
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            //elçiye görevi verdik.Elçiyi çağırmadan yani execute etmeden görevi yerine getirmez.
            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert;

            myDelegate();
        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Send Nudes!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Ready to depart");
        }
    }
}
