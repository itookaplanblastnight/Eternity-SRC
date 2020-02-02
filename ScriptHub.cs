using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eternity
{
    public partial class Form2 : Form
    {
        WebClient script = new WebClient();
        public Form2()
        {
            InitializeComponent();
        }

        #region Useless SHIT
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        #endregion Useless SHIT

        #region Close/Minimize Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion Close/Minimize Buttons

        #region Scripts
        private void button8_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(script.DownloadString("https://pastebin.com/raw/k4paUazE"));
            MessageBox.Show("Script has been copied!", "Eternity - Script Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(script.DownloadString("https://pastebin.com/raw/GXgmb9S3"));
            MessageBox.Show("Script has been copied!", "Eternity - Script Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(script.DownloadString("https://pastebin.com/raw/irABr6xi"));
            MessageBox.Show("Script coming soon!", "Eternity - Script Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button11v3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(script.DownloadString("https://pastebin.com/raw/akBp4xMj"));
            MessageBox.Show("Script has been copied!", "Eternity - Script Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(script.DownloadString("https://pastebin.com/raw/gz83pDWn"));
            MessageBox.Show("Script has been copied!", "Eternity - Script Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(script.DownloadString("https://pastebin.com/raw/Skj32XQj"));
            MessageBox.Show("Script has been copied!", "Eternity - Script Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(script.DownloadString("https://pastebin.com/raw/ecnzHzrU"));
            MessageBox.Show("Script has been copied!", "Eternity - Script Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(script.DownloadString("https://pastebin.com/raw/TXi26KLf"));
            MessageBox.Show("Script has been copied!", "Eternity - Script Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(script.DownloadString("https://cdn.wearedevs.net/scripts/Fly.txt"));
            MessageBox.Show("Script has been copied!", "Eternity - Script Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(script.DownloadString("https://cdn.wearedevs.net/scripts/WRD%20Aimbot.txt"));
            MessageBox.Show("Script has been copied!", "Eternity - Script Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion Scripts
    }
}
