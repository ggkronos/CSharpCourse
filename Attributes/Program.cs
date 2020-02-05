using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.Id = 1;
            customer.Age = 26;
            customer.FirstName = "Umut";
            customer.LastName = "Yuksel";
            CustomerDal customerDal =new CustomerDal();
            customerDal.Add(customer);


            Console.ReadLine();
        }
    }

    //Customer nesnesi(sınıfı) veritabanında Customers a karşılık geliyor anlamında
    [ToTable("Customers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    class ToTableAttribute : Attribute
    {
        private string v;

        public ToTableAttribute(string v)
        {
            this.v = v;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class RequiredPropertyAttribute : Attribute
    {
    }

    class CustomerDal
    {
        //hazır attribute obsolete -eski demek projede değiştiremeyeceğimiz bir metod olduğunu düşünelim
        //yerine yenisini yazdık artık eski metodun kullanılmaması yenisinin kullanılmasını istiyoruz
        //bunu bu şekilde obsolete kullarak belirtiyoruz bunu yaptığımızda ide bize obsolete metod kullanıyorsun
        //şeklinde uyarı veriyor bu uyarı sayesinde kullandığımız metodu değiştiredebiliriz kullanmaya devam ededebiliriz.
        [Obsolete("Dont use this Add method anymore instead use AddNew method")]
        public void Add(Customer customer)
        {
            Console.WriteLine("Added!");
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine("Added!");
        }

    }
}
