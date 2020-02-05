using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();
            MySql mySql = new MySql();
            mySql.Add();

            Console.ReadLine();
        }
    }

    class Database
    {

        //virtual kullanmamızın sebebi ileride child sınıflarında override edebilmek için
        public virtual void Add()
        {
            Console.WriteLine("Added Default");
        }

        public void Delete()
        {
            Console.WriteLine("Deleted Default");
        }
    }

    class SqlServer:Database
    {
        public override void Add()
        {
            Console.WriteLine("Added with Sql Code");
            //base yani database sınıfındaki ana metot
            //bazı durumlarda burada değişiklikler yapıp o hali
            //ile ana base metotu da kullanırız.

            //base.Add();
        }
    }

    class MySql:Database
    {
        
    }
}
