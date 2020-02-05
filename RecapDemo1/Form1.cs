using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Uygulama ilk açıldığında çalışacak kod bloğu burası
            // Button button = new Button();  bunu kullanmıyoruz çünkü 64 buton lazım ve ayrı ayrı kullanabilmeliyiz.
            //O yüzden array işimizi daha düzgün yapmamızı sağlıyor.
            //button.Width = 50;
            //button.Height = 50;
            //this.Controls.Add(button); //ekrana ekleme işlemini yaptık.

            Button[,] buttons=new Button[8,8];
            //Sol üst köşeden itibaren buttonları hizalamak için top ve left değerleri kullanıyoruz.
            int top = 0;
            int left = 0;
            for (int i = 0; i <= buttons.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                {
                    buttons[i,j] = new Button(); //her döngüde bir buton nesnesi oluşturuyoruz.
                    buttons[i, j].Width = 50; //her nesneye genişlik ve yükseklik değeri veriyoruz.
                    buttons[i, j].Height = 50;
                    buttons[i, j].Left = left; //left değişkeninin değerini buttonun left değerine atıyoruz.left değişkeninin değerini
                    // satır içinde arttırırken satır sonu tekrar sıfırlamalıyız.
                    buttons[i, j].Top = top; // Butonun top değeri sadece satır sonu arttırılmalı ve sıfırlanmamalı.
                    this.Controls.Add(buttons[i,j]);
                    left += 50; //buton genişlikleri 50 olduğu için her seferinde 50 birim arttırarak soldan öteliyoruz.

                    if ((i+j)%2==0)
                    {
                        buttons[i,j].BackColor= Color.Black;
                    }
                    else
                    {
                        buttons[i, j].BackColor = Color.White;
                    }
                }

                top += 50; // top değerini her satır sonunda 50 birim arttırıyoruz.
                left = 0; //satır sonu left i sıfırlayıp bir alt satırda sol kenardan başlamasını sağlıyoruz.
            }

            
        }
    }
}
