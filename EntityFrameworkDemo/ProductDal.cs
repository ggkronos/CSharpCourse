using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetProducts()
        {
            using (ETradeContext context = new ETradeContext())
            {
               return context.Products.ToList();
            }
        }

        public Product GetProductById(int productId)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //Tek değer döndüreceğimiz için where komutunu kullanamayız.Where ıquarible tipi yani bir liste döndürür
                //Onun yerine sıklıkla FirstOrDefault ile tek kayıt döndürüz.
                //data bulamazsa null bulursa datanın kendini döndürür.
                return context.Products.FirstOrDefault(p => p.Id == productId);
            }
        }

        //Arama işlemini veritabanına yaptırıyoruz.
        public List<Product> GetProductsByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }

        public List<Product> GetProductsByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();
            }
        }

        public List<Product> GetProductsByUnitPrice(decimal minPrice,decimal maxPrice)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= minPrice && p.UnitPrice<= maxPrice).ToList();
            }
        }

        public void AddProduct(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(product);
                //var entity = context.Entry(product);
                //entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //parametre olarak gönderdiğimiz product ı veritabanındaki product ile eşliyor
                //bunu yaparken primary keye bakarak buluyor bu örnekte Id değeri oluyor.
                var entity = context.Entry(product);
                //durumunu güncellendi olarak işaretliyor 
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
