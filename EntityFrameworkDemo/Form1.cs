using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            // dgwProducts.DataSource = _productDal.GetProducts();
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetProducts();
        }

        private void SearchProducts(string key)
        {
            //Tolist yapmazsak hata alırız.Veritabanında çalışmadığımız için büyük küçük harflerde sorgu sorunu yaşarız
            //Bu sorunu çözmek için ToLower kullanırız.Sorguyu veritabanı kısmında yaparsak bu tarz sorunlarımız olmaz.
            //dgwProducts.DataSource = _productDal.GetProducts().Where(p=>p.Name.ToLower().Contains(key.ToLower())).ToList();
            _productDal.GetProductsByName(key);
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            _productDal.AddProduct(new Product
            {
                Name = tbxName.Text,
                StockAmount = Convert.ToInt32(tbxStockAmount.Text),
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text)
            });

            LoadProducts();
            MessageBox.Show("Product Added!");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.UpdateProduct(new Product
            {
                Id =Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            });
            LoadProducts();
            MessageBox.Show("Product Updated!");
        }

        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            _productDal.DeleteProduct(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Product Deleted!");
        }

        private void DgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void TbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);
        }
    }
}
