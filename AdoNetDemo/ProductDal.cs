using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    public class ProductDal
    {
        //    Dal veya Dao =Data Access Layer ya da Object
        //    anlamlarına geliyor ve data ile ilgili işlemleri 
        //    gerçekleştirmek için kullanıyoruz.
        //    Veri insert update select delete gibi işlemleri bu sınıfta yapıyoruz.


        //Kurumsal mimaride ProductDal ı bir IProductDal interfacesinden türetmemiz gerekir
        //Bu örnekte kullanmayacağız

        //Sınıfın içinde metotların dışında tanımlandığı için connection başına _ yazılır _connection olarak kullanılır
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");
        //bağlantı nesnesi oluşturduk henüz bağlantı açmadık

        public List<Product> GetProducts()  //Bütün productları getirsin istiyorum List<Product>
        {
            ConnectionControl();

            SqlCommand command= new SqlCommand("Select * from Products", _connection); //sorguyu connection a gönderiyoruz

            SqlDataReader dataReader= command.ExecuteReader(); //bir tablo döneceğini bildiğimiz için executeReader kullandık duruma göre değişiyor
           
            List<Product> products = new List<Product>();

            //adonet eski bir bağlantı türü olduğu için

            while (dataReader.Read()) //içinde okuyacak veri oldukça
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(dataReader["Id"]), //"Id" veritabanından gelen tablo adı
                    Name =Convert.ToString(dataReader["Name"]),
                    StockAmount = Convert.ToInt32(dataReader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(dataReader["UnitPrice"])
                    
                };
                //her okuduğumuz veriyi nesneye ekliyoruz onu da products listesine ekleyeceğiz
                products.Add(product);
            }


            dataReader.Close();
            //iş bittiği için bağlantıyı kapatıyoruz
            _connection.Close();
            return products;
        }

        private void ConnectionControl()
        {
//bu metodu her yerde kullanacağımız için refactor ile değiştiriyoruz
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open(); //bağlantıyı açtık eğer kapalı ise
            }
        }

        public DataTable GetProducts2()  //Bütün productları getirsin istiyorum List<Product>
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open(); //bağlantıyı açtık eğer kapalı ise
            }

            SqlCommand command = new SqlCommand("Select * from Products", _connection); //sorguyu connection a gönderiyoruz

            SqlDataReader dataReader = command.ExecuteReader(); //bir tablo döneceğini bildiğimiz için executeReader kullandık duruma göre değişiyor
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader); //bunu yaptıktan sonra reader ı kapatıyoruz
            dataReader.Close();
            //iş bittiği için bağlantıyı kapatıyoruz
            _connection.Close();
            return dataTable;
        }


        //Ekleme işlemi yapıyor birşey döndürmüyor
        public void AddProduct(Product product)
        {
            ConnectionControl(); //bağlantı kapalı ise açacak açık ise işlem yapmayacak kendimiz yazdık metodu
            //sql command i yazıp _connection a yani açtığımız bağlantıya gönderiyoruz.
            SqlCommand command =new SqlCommand(
                "Insert into Products values(@name,@unitPrice,@stockAmount)",_connection);
            //parametre varsa aşağıdaki kodu yazıyoruz bu şekilde yazıp sql injection a karşı önlem alıyoruz
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void UpdateProduct(Product product)
        {
            ConnectionControl(); //bağlantı kapalı ise açacak açık ise işlem yapmayacak kendimiz yazdık metodu
            //sql command i yazıp _connection a yani açtığımız bağlantıya gönderiyoruz.
            SqlCommand command = new SqlCommand(
                "Update Products set Name=@name,UnitPrice=@unitPrice,StockAmount=@stockAmount where Id=@id", _connection);
            //parametre varsa aşağıdaki kodu yazıyoruz bu şekilde yazıp sql injection a karşı önlem alıyoruz
            command.Parameters.AddWithValue("@id", product.Id);

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void DeleteProduct(int id)
        {
            ConnectionControl(); //bağlantı kapalı ise açacak açık ise işlem yapmayacak kendimiz yazdık metodu
            //sql command i yazıp _connection a yani açtığımız bağlantıya gönderiyoruz.
            SqlCommand command = new SqlCommand(
                "Delete from Products where Id=@id", _connection);
            //parametre varsa aşağıdaki kodu yazıyoruz bu şekilde yazıp sql injection a karşı önlem alıyoruz
            command.Parameters.AddWithValue("@id",id);

            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
