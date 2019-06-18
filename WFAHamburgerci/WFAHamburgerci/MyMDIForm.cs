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
    public partial class MyMDIForm : Form
    {
        public MyMDIForm()
        {
            InitializeComponent();
        }

        void ChildForm(Form childform)
        {
            //default size 

            bool durum = false;
            foreach (Form frm in this.MdiChildren)
            {
                if(frm.Text ==childform.Text )
                {
                    durum = true;
                    frm.Activate();
                }
                else
                {
                    frm.Close();
                }
            }

            if(durum==false)
            {
                childform.MdiParent = this;
                childform.Show();
            }
        }
       
        private void siparişOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm(new Form1());
        }

        private void hamburgerEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm(new Form2());
        }

        private void extraMalzemeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm(new Form3());
        }

        private void siparişBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm(new Form4());
        }
    }


}