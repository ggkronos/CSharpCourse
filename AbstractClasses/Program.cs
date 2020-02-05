using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Oracle();
            Database database2 = new SqlServer();
            database.Add();
            database.Delete();
            database2.Add();
            database2.Delete();

            Console.ReadLine();
        }
    }

    abstract class Database
    {

        //Tamamlanmış metot
        public void Add()
        {
            Console.WriteLine("Added Default");
        }

        //Tamamlanmamış metot database in alt sınıflarında override edilir.
        //Kullanım amacı farklı sınıflar için oluşabilecek değişikliler için override edebilmek
        public abstract void Delete();

        //abstract metotların gövdesi tanımlandığı yerde olmaz.Override ederken olur.

    }

    class SqlServer : Database
    {
        public override void Delete()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Deleted Sql");
        }
    }

    class Oracle : Database
    {
        public override void Delete()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Deleted Oracle");
        }
    }
}
