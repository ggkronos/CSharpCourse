using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList();

            //List();

            //Dictionary<anahtar değer ,karşılığı olan değer>
            Dictionary<string,string> dictionary = new Dictionary<string, string>();
            dictionary.Add("book","kitap");
            dictionary.Add("table","tablo");
            dictionary.Add("computer","bilgisayar");

            Console.WriteLine(dictionary["table"]);
            //key değeri listemizde olmadığı için hata verir.
            //Console.WriteLine(dictionary["glass"]);

            foreach (var item in dictionary)
            {
                //Console.WriteLine(item);
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
            Console.WriteLine(dictionary.ContainsKey("glass"));
            Console.WriteLine(dictionary.ContainsKey("table"));
            Console.ReadLine();
        }

        private static void List()
        {
            //Tip güvenli collection List<> tipini belirtmemiz gerek
            List<string> cityList = new List<string>();
            cityList.Add("Muğla");
            cityList.Add("Çanakkale");

            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer
            //{
            //    Id = 1,
            //    FirstName = "Umut"

            //});
            //customers.Add(new Customer
            //{
            //    Id = 2,
            //    FirstName = "Hulk"
            //});
            List<Customer> customers = new List<Customer>
            {
                new Customer {Id = 1, FirstName = "Umut"},
                new Customer {Id = 2, FirstName = "Hulk"}
            };

            var count = customers.Count;
            var customer2 = new Customer
            {
                Id = 3,
                FirstName = "Ironman"
            };
            customers.Add(customer2);
            customers.AddRange(new Customer[2]
            {
                new Customer {Id = 4, FirstName = "Spiderman"},
                new Customer {Id = 5, FirstName = "Thor"}
            });

            //Listedeki elemanları temizler.
            //customers.Clear();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }

            foreach (var city in cityList)
            {
                Console.WriteLine(city);
            }
        }

        private static void ArrayList()
        {
            ArrayList cityList = new ArrayList();
            cityList.Add("Antalya");
            cityList.Add("İzmir");
            //Arraylistlerde value safe özelliği yoktur her tip veri girilebilir.
            cityList.Add(7);
            cityList.Add('U');

            foreach (var city in cityList)
            {
                Console.WriteLine(city);
            }
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
