using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ETradeContext:DbContext
    {
        //Products veritabanındaki tablo adı ile eşleşmeli yoksa mapping gerekli
        public DbSet<Product> Products { get; set; }
    }
}
