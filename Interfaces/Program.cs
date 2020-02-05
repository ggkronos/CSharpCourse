using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //InterfacesIntro();


            //Interface i kendi başına new edemeyiz ,onu implement eden sınıflarla birlikte kullanırız.
            //IPerson person= new Customer(); gibi kullanımı mevcuttur.


            //RealLifeInterfaces();


            //Aynı anda iki veritabanına işlem yapmak için ICustomerDal tipinde bir array oluşturup içine ekliyoruz.
            ICustomerDal[] customerDals =new ICustomerDal[]
            {
                new OracleCustomerDal(), 
                new SqlServerCustomerDal(), 
            };
            //Oluşturduğumuz array i foreach ile dönebiliriz.
            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }

            Console.ReadLine();
        }

        private static void RealLifeInterfaces()
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new SqlServerCustomerDal());
            customerManager.Update(new OracleCustomerDal());
        }

        private static void InterfacesIntro()
        {
            PersonManager manager = new PersonManager();
            Customer customer = new Customer
            {
                Id = 3,
                FirstName = "Niyazi",
                LastName = "Gittigider",
                Address = "Güzelköy Muhtarlığı"
            };
            Student student = new Student
            {
                Id = 4,
                FirstName = "Hikmet",
                LastName = "Deli",
                Departmant = "Astronomi"
            };
            manager.Add(student);
            manager.Add(customer);
        }
    }

    //interface tanımlarken başına interface gelir ve interface adının başına "I" konur.
    interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
    class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
    }

    class Worker:IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Departmant { get; set; }
        public int year { get; set; }
    }
    class Student : IPerson
    {
        //Sınıflar interfacelerinin özelliklerini implement etmek zorundalar.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Sınıfların interface dışı özelliği olabilir.
        public string Departmant { get; set; }
    }

    class PersonManager
    {
        public void Add(IPerson person)
        {
            Console.WriteLine(person.FirstName);
        }   
    }
}
