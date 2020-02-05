using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();
            customerManager.Update();

            ProductManager productManager = new ProductManager();
            productManager.Add();
            productManager.Update();
            Console.ReadLine();

            Customer customer = new Customer();

            customer.Id = 1;
            customer.FirstName = "Umut";
            customer.LastName = "Yüksel";
            customer.City = "Antalya";

            Customer customer2 = new Customer
            {
                Id = 2, FirstName = "Who", LastName = "How", City = "Florida"
            };
        }
    }

    //class CustomerManager
    //{
    //    public void Add()
    //    {
    //        //Add işlemleri için ilgili kodları yazdığımızı varsayıyoruz
    //        Console.WriteLine("Customer Added!");
    //    }

    //    public void Update()
    //    {
    //        Console.WriteLine("Customers information updated!");
    //    }
    //}

    //class ProductManager
    //{
    //    public void Add()
    //    {
    //        Console.WriteLine("Product Added!");
    //    }

    //    public void Update()
    //    {
    //        Console.WriteLine("Product Updated!");
    //    }
    //}
}
