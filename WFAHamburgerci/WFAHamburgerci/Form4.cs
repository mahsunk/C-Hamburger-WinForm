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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            decimal ciro = 0;
            int satisAdedi = 0;
            decimal exMalzemeGeliri = 0;
            foreach (Siparis item in Form1.siparisler)
            {
                ciro += item.ToplamTutar;
                foreach (Extra ex in item.ExtraMalzemeler)
                {
                    exMalzemeGeliri += ex.Fiyati;
                }

                satisAdedi += item.Adet;
                lstSiparisler.Items.Add(item);


            }

            lblSiparisSayisi.Text = lstSiparisler.Items.Count.ToString();
            lblCiro.Text = ciro.ToString("C2");
            lblSatilanUrunAdedi.Text = satisAdedi.ToString();
            lblExtraMalzemeGeliri.Text = exMalzemeGeliri.ToString("C2");

        }
    }
}
