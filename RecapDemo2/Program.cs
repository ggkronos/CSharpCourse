using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();

            //Aşağısı önemli logger = new DatabaseLogger ı kullanmak zorunlu bu durumda
            customerManager.Logger = new DatabaseLogger();
            customerManager.Add();

            Console.ReadLine();
        }
    }
    /* Loglama örneği yapmak istiyoruz.Kötü örnekler yapıp kodu biraz daha
     * iyi hale getireceğiz.Kötü yazma alışanlıklarını yorum satırı arasına
     * alacağız.
     *Eğer ki bir sınıfın herhangi bir interface i yada inheritence ı yoksa ondan korkun ,kötü bir kodlama yaklaşımıdır.
     * Program ileride geliştirilecekse interface gibi yapılar lazım.
     */
    class CustomerManager
    {
        public ILogger Logger { get; set; }
        public void Add()
        {

            Logger.Log();

            //Logger logger = new Logger();
            //logger.Log();

            Console.WriteLine("Customer added!");
        }
    }

    class DatabaseLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database");
        }
    }

    class FileLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file");
            //throw new NotImplementedException();
        }
    }

    interface ILogger
    {
        void Log();
    }
}
