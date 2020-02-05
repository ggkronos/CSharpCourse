using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            //new CustomerManager(); la aslında biz cunstructor metodu çalıştırıyoruz.Parametre aladabilir
            //parametresiz oladabilir.Sınıf içinde tanımlamak için ctor yazıp tab a basıyoruz.
            CustomerManager customerManager = new CustomerManager(10);
            customerManager.List();

            Product product =new Product();
            Product product2 =new Product(2,"LG");

            EmployeeManager employeeManager =new EmployeeManager(new DatabaseLogger());
            employeeManager.Add();

            PersonManager personManager =new PersonManager("Product");

            //Statik nesneyi newlemeden kullanırız.
            Teacher.Number = 10;
            Utilities.Validate();

            Manager.DoSomeThing();
            Manager manager = new Manager();
            manager.DoSomeThing2();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private int _count =15;
        //bir başlangıç değeri veriyoruz ki parametreyi biz göndermezsek bu değeri alıp işlem yapsın.
        //field tanımlarken yazma alışkanlığı olarka _count şeklinde "_" kullanılır.

        //Parametreli constructor metot
        public CustomerManager(int count)
        {
            _count = count;
        }

        //Parametresiz metot ,parametre vermezsek default değere göre işlem yapar.
        public CustomerManager()
        {
            
        }
        public void List()
        {
            Console.WriteLine("Listed {0} items",_count);
        }

        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Product()
        {
            
        }

        private int _id;
        private string _name;
        //Bu değişkenleri constructor a parametre olarak gelen veriyi atayabilmek için kullanıyoruz.
        public Product(int id,string name)
        {
            _id = id;
            _name = name;
        }
    }

    interface ILogger
    {
        void log();
    }

    class DatabaseLogger:ILogger
    {   
        public void log()
        {
            Console.WriteLine("Logged to database");
        }
    }

    class FileLogger:ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged to file");
        }
    }

    class EmployeeManager
    {
        private ILogger _logger;
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.log();
            Console.WriteLine("Added");
        }
    }

    class Person
    {
        private string _message;

        public Person(string message)
        {
            _message = message;
        }
        public void Message()
        {
            Console.WriteLine("{0} Message",_message);
        }
            
    }

    class PersonManager:Person
    {
        public PersonManager(string message) : base(message)
        {
        }

        public void Add()
        {
            Console.WriteLine("Added!!!");
            Message();
        }
    }

    static class Teacher
    {
        public static int Number { get; set; } 
    }

    static class Utilities
    {
        public static void Validate()
        {
            Console.WriteLine("Validation is complete");
        }
    }

    class Manager
    {
        public static void DoSomeThing()
        {
            Console.WriteLine("DONE");
        }

        public void DoSomeThing2()
        {
            Console.WriteLine("DONE II");
        }
    }
}
