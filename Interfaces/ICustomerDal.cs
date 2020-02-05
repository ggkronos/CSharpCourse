using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface ICustomerDal
    {   
        //Dal = data access layer dan geliyor
        void Add();
        void Update();
        void Delete();
    }
    //Normalde ayrı dosyalarda oluştururuz ama
    //görebilmek adına aşağıdaki işlemleri burada yapıyoruz


    //Gerçek bir projede SqlServerCustomerDal şeklinde
    //isimlendirilmiyor daha farklı isimlendiriliyor.
    class SqlServerCustomerDal:ICustomerDal
    {
        public void Add()
        {
            //Exceptionları şimdilik kapatıyorum
            //throw new NotImplementedException();
            Console.WriteLine("Sql Added!");

        }

        public void Update()
        {
            //Exceptionları şimdilik kapatıyorum
            //throw new NotImplementedException();
            Console.WriteLine("Sql Updated!");
        }

        public void Delete()
        {
            //Exceptionları şimdilik kapatıyorum
            //throw new NotImplementedException();
            Console.WriteLine("Sql Deleted!");
        }
    }

    class OracleCustomerDal:ICustomerDal
    {
        public void Add()
        {
            //Exceptionları şimdilik kapatıyorum
            //throw new NotImplementedException();
            Console.WriteLine("Oracle Added!");
        }

        public void Update()
        {
            //Exceptionları şimdilik kapatıyorum
            //throw new NotImplementedException();
            Console.WriteLine("Oracle Updated!");
        }

        public void Delete()
        {
            //Exceptionları şimdilik kapatıyorum
            //throw new NotImplementedException();
            Console.WriteLine("Oracle Deleted!");
        }
    }

    class CustomerManager
    {
        /* Parametre olarak ICustomerDal veriyoruz çünkü
         oracle yada sql e bağımlı olmasını istemiyoruz.İki serverda
         interface e bağlı olduğu için bu sayede istediğimizi gerekli 
         olduğu anda rahatlıkla seçebileceğiz.*/
        public void Add(ICustomerDal customerDal)
        {
            customerDal.Add();
        }

        public void Update(ICustomerDal customerDal)
        {
            customerDal.Update();
        }

        public void Delete(ICustomerDal customerDal)
        {
            customerDal.Delete();
        }
    }
}
