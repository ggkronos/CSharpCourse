using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities =new Utilities();
            List<string> result = utilities.BuildList<string>("Ankara", "İstanbul", "İzmir");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }

    public class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }

    interface IProductDal
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);

    }

    //Burada implement edeceğiz
    interface ICustomerDal:IRepository<Customer>
    {

    }


    //Generic bir interface oluşturduk.
    //Sürekli tekrarlayacağımız metotları yazmak yerine bu şekilde yazıp
    //diğer yerlerde implement edebiliriz.



    //T nin referans tip ve newlenebilir olmasını istediğimiz için where koşulunu kullanırız
    //Bunu oluşabilecek hataların önüne geçmek amacıyla yaparız.Sadece T:class yazarsak referans tipleri alacağından stringide alır
    interface IRepository<T> where T:class , new()
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }


}
