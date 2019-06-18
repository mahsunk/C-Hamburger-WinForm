using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAHamburgerci
{
    public static class Method
    {
        public static void Temizle(Control.ControlCollection collection)
        {
            foreach (Control item in collection)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
                else if (item is CheckBox)
                {
                    CheckBox chb = (CheckBox)item;
                    chb.Checked = false;

                }
                else if (item is RadioButton)
                {
                    RadioButton rb = (RadioButton)item;
                    if (rb.Name == "rbKucuk")
                    {
                        rb.Checked = true;
                    }
                    else
                    {
                        rb.Checked = false;
                    }

                }
                else if(item is NumericUpDown)
                {
                    NumericUpDown nud = (NumericUpDown)item;
                    nud.Value = 1;
                }
                else if(item is FlowLayoutPanel)
                {
                    FlowLayoutPanel flp = (FlowLayoutPanel)item;
                    Temizle(flp.Controls); //recursive method
                }
                else if (item is ComboBox)
                {
                    ComboBox cb = (ComboBox)item;
                    cb.SelectedIndex = 0;
                }

            }
        }
    }
}
