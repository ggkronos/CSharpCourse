using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aritmetics aritmetics = new Aritmetics(4,7);
            //aritmetics.Add2();

            //Reflection için benim çalışacağım bir type var oda aricmetics diyoruz.
            //Reflection da activator diye bir sınıf var.
            var type = typeof(Aritmetics);
            //Activator.CreateInstance(type);

            //var aritmetics = Activator.CreateInstance(type); 
            //Aritmetics aritmetics = (Aritmetics) Activator.CreateInstance(type);
            //aritmetics.Add(4, 5);
            //Console.WriteLine(aritmetics.Add(4, 5));

            var instance = Activator.CreateInstance(type,9,4);
            //instance.GetType().GetMethod("Add2").Invoke(instance,null);
            MethodInfo methodInfo = instance.GetType().GetMethod("Add2");
            Console.WriteLine(methodInfo.Invoke(instance, null));

            Console.WriteLine("----------------------");
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine("Method name: {0}",method.Name);
                foreach (var parametersInfo in method.GetParameters())
                {
                    Console.WriteLine("Parameters: {0}",parametersInfo.Name);
                }

            }
            Console.ReadLine();
        }
    }

    public class Aritmetics
    {
        private int _number1;
        private int _number2;
        public Aritmetics(int number1, int number2)
        {
            _number1 = number1;
            _number2 = number2;
        }

        public Aritmetics()
        {
            
        }
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }


        //Parametreleri olmadığı için parametreyi ctor dan alıyorlar
        public int Add2()
        {
            return _number1 + _number2;
        }

        public int Multiply2()
        {
            return _number1 * _number2;
        }
    }
}
