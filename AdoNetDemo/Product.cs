using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    //class ı public yapıyoruz.
    public class Product
    {
        //veritabanındaki tabloya karşılık geliyor
        //tablo karşılığı tekildir ve class ı public yaparız
        //veriyi karşılayacak nesne(sınıf)
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
