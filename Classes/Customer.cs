using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Customer
    {
        //field tanımlama
        public string UserName;

        //property tanımlama
        public int Id { get; set; }


        //Get yada set değerini özelleştirmek istersek ; leri kaldırıp {} parantez kullarınız
        //öncesinde bir field değişkenine ihtiyacımız var

        public string _firstName;

        public string FirstName
        {
            get { return "Mr." + _firstName; }  //değeri döndürüyoruz döndürürken modifiye ediyoruz.Başına Mr. ekliyoruz
                                                //aslında burada da cinsiyete göre kontrol olması lazım.
            set { _firstName = value; } //değeri set ediyoruz.
        }

        public string LastName { get; set; }
        public string City { get; set; }
    }
}
