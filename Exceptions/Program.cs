using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExceptionIntro();

            
            try
            {
                RecordFind();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                
            }

            //Method
            //özel kullanım ()=>{}
            //tür olarak string int gibi türler yerine tür olarak metot alıyor.
            HandleException(() =>
            {
                RecordFind();
            });


            Console.ReadLine();
        }


        //Action handleException içindeki bu örnekte RecordFind içinde bulunduğu bloğa karşılık geliyor.
        private static void HandleException(Action action)
        {
            //throw new NotImplementedException();
            //try catch bloğunu buraya yazıyoruz.
            try
            {
                //action ı kapsayan bloğu invoke ederek çalıştırıyoruz.
                action.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                
            }
        }

        private static void RecordFind()
        {
            List<string> students = new List<string>
            {
                "Thor", "Hulk", "Ironman", "Captain America"
            };

            //spiderman students listesinde yok ise if içindeki ifade true olup
            //RecordNotFound hatası fırlatacak yoksa kayıt bulundu diyecek.
            if (!students.Contains("Spiderman"))
            {
                throw new RecordNotFoundException("Record Not Found");
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }

        private static void ExceptionIntro()
        {
            try
            {
                string[] students = new[] {"Ironman", "Thor", "Captain America"};
                students[3] = "Spiderman";
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                //throw;
            }
            //catch (IndexOutOfRangeException exception)
            //{

            //    Console.WriteLine(exception.Message);
            //    //throw;
            //}
            //catch (DivideByZeroException exception)
            //{

            //    Console.WriteLine(exception.Message);
            //    //throw;
            //}
        }
    }
}
