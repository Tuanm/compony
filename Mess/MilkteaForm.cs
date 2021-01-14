using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mess
{
    public partial class MilkteaForm : Form
    {
        int i = 0, j = 0;
        public MilkteaForm()
        {

            InitializeComponent();
        }
        IMilkTea milktea = new MilkTea();

        private void btnFruit_Click(object sender, EventArgs e)
        {
            milktea = new Fruit(milktea);
            tbxChoosing.Text = milktea.Name();
        }

        private void btnJelly_Click(object sender, EventArgs e)
        {
            milktea = new Jelly(milktea);
            tbxChoosing.Text = milktea.Name();
        }

        private void btnPudding_Click(object sender, EventArgs e)
        {
            milktea = new Pudding(milktea);
            tbxChoosing.Text = milktea.Name();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (tbxChoosing.Text != "")
            {
                i++;
                if (i <= lbxBill.Items.Count) lbxBill.Items[i - 1] = tbxChoosing.Text;
                else
                {
                    lbxBill.Items.Add(tbxChoosing.Text);
                }
                lbxBill.Text += i.ToString() + ". " + tbxChoosing.Text + "\n";
                tbxChoosing.Text = "";
                milktea = new MilkTea();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                for (j = lbxBill.SelectedIndex; j < lbxBill.Items.Count - 1; j++)
                {
                    lbxBill.Items[j] = lbxBill.Items[j + 1];
                }
                /*lbxBill.Items[j] = "";*/
                lbxBill.Items.RemoveAt(j);
                i--;
            }
            catch
            { MessageBox.Show("No object selected!"); }
        }
    }
}
