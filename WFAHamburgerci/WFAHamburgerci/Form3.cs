using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAHamburgerci
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Form1.extralar.Add(new Extra {ExtraAdi=txtAd.Text, Fiyati=nmrFiyat.Value });
            Method.Temizle(this.Controls);
            MessageBox.Show("Extra başarıyla eklendi");
        }
    }
}
