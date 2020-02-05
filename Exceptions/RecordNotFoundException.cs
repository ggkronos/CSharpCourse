using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    //Exception sınıfını miras alıyoruz ki kendi yazdığımız exception sınıfıda
    //bir exception özelliklerinde olsun.
    class RecordNotFoundException:Exception
    {
        public RecordNotFoundException(string message):base(message)
        {
            
        }
    }
}
