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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<Siparis> siparisler = new List<Siparis>();
        public static List<Siparis> mevcutSiparisler = new List<Siparis>();
        public static List<Menu> menuler = new List<Menu>()
        {
            new Menu{MenuAdi = "SteakHouse", Fiyati = 18m},
            new Menu{MenuAdi = "Fish", Fiyati = 18m},
            new Menu{MenuAdi = "Whooper", Fiyati = 18m},
            new Menu{MenuAdi = "Chicken", Fiyati = 18m},
            new Menu{MenuAdi = "BigKing", Fiyati = 18m}

        };

        public static List<Extra> extralar = new List<Extra>()
        {
            new Extra{ExtraAdi="BBQ", Fiyati = 0.5m},
            new Extra{ExtraAdi="Ranch", Fiyati = 0.5m},
            new Extra{ExtraAdi="Soğan", Fiyati = 0.5m},
            new Extra{ExtraAdi="Ketçap", Fiyati = 0.5m},
            new Extra{ExtraAdi="Sarımsaklı Mayonez", Fiyati = 0.5m}
        };

        private decimal TutarHesapla()
        {
            decimal toplamTutar = 0;
            for (int i = 0; i < lstSiparisler.Items.Count; i++)
            {
                Siparis gelen = (Siparis)lstSiparisler.Items[i];
                toplamTutar += gelen.ToplamTutar;
            }
            lblToplamTutar.Text = toplamTutar.ToString("C2");
            return toplamTutar;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(Menu item in menuler)
            {
                cbMenuler.Items.Add(item);
            }

            foreach(Extra item in extralar)
            {
                flpExtraMalzemeler.Controls.Add(new CheckBox() { Text = item.ExtraAdi, Tag = item });
            }

            foreach(Siparis item in mevcutSiparisler)
            {
                lstSiparisler.Items.Add(item);
            }

            TutarHesapla();
            cbMenuler.SelectedIndex = 0;
        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            Siparis yeniSiparis = new Siparis();
            yeniSiparis.SeciliMenusu = (Menu)cbMenuler.SelectedItem;
            if(rbKucuk.Checked)
            {
                yeniSiparis.Boyutu = Boyut.Kucuk;
            }
            else if (rbOrta.Checked)
            {
                yeniSiparis.Boyutu = Boyut.Orta;
            }
            else if(rbBuyuk.Checked)
            {
                yeniSiparis.Boyutu = Boyut.Buyuk;
            }

            yeniSiparis.ExtraMalzemeler = new List<Extra>();
            foreach(CheckBox item in flpExtraMalzemeler.Controls)
            {
                if(item.Checked)
                {
                    yeniSiparis.ExtraMalzemeler.Add((Extra)item.Tag);
                }
            }

            yeniSiparis.Adet = Convert.ToInt32(nmrAdet.Value);
            yeniSiparis.Hesapla();
            mevcutSiparisler.Add(yeniSiparis);
            siparisler.Add(yeniSiparis);
            lstSiparisler.Items.Add(yeniSiparis);

            TutarHesapla();
            Method.Temizle(this.Controls);

        }

        private void btmSiparisTamamla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Toplam ücret : "+TutarHesapla().ToString("C2") + "Satın almayı tamamlama ister misiniz ?","Sipariş Bilgis", MessageBoxButtons.YesNo, MessageBoxIcon.Information );

            if(dr == DialogResult.Yes)
            {
                lstSiparisler.Items.Clear();
                mevcutSiparisler.Clear();
                TutarHesapla();
                MessageBox.Show("Sipariş Tamamlandı!!");
            }
            else
            {
                MessageBox.Show("İptal edildi.");
            }

        }
    }
}

