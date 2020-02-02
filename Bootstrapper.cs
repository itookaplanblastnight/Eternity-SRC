using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eternity
{
    public partial class Bootstrapper : Form
    {
        public Bootstrapper()
        {
            InitializeComponent();
        }
        bool urgei;

        #region Useless SHIT
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        #endregion Useless SHIT

        #region Form Load
        private void Bootstrapper_Load(object sender, EventArgs e)
        {
            timer1.Start();
            urgei = true;
        }
        #endregion Form Load

        #region Bootstrapper Loading...
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (urgei)
            {
                this.panel4.Width += 4;
                if (panel4.Width >= 231)
                {
                    timer1.Stop();
                }
                if (panel4.Width >= 84)
                {
                    label2.Text = "Downloading Files...";
                }
                if (panel4.Width >= 170)
                {
                    label2.Text = "Downloading Updated Adressess...";
                }
                if (panel4.Width >= 210)
                {
                    label2.Text = "Launching...";
                }
                if(panel4.Width == 230)
                {
                    this.Hide();
                    Form1 execer = new Form1();
                    execer.Show();
                }
            }
        }
        #endregion Bootstrapper Loading...
    }
}

