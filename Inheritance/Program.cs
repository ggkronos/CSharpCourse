using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[]
            {
                new Person()
                {
                    FirstName = "Killer"    
                }, 
                new Customer()
                {
                    FirstName = "Bee"
                }, 
                new Student()
                {
                    FirstName = "Ko"
                }, 
            };
            foreach (var person in persons)
            {
                Console.WriteLine(person.FirstName);
            }

            Console.ReadLine();
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Customer : Person
    {
        public int City { get; set; }
    }

    class Student : Person
    {
        public string Departmant { get; set; }
    }
}
