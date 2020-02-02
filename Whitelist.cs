using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eternity
{
    public partial class Whitelist : Form
    {
        WebClient wc = new WebClient();
        public Whitelist()
        {
            InitializeComponent();
        }

        #region Login System
        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "ebaydev")
            {
                this.Hide();
                Bootstrapper bootst = new Bootstrapper();
                bootst.Show();
            }
            string pastebin = wc.DownloadString("https://pastebin.com/raw/NQWRy2bw");
            if(textBox1.Text == pastebin)
            {
                this.Hide();
                Bootstrapper bootst = new Bootstrapper();
                bootst.Show();
            }
        }
        #endregion Login System

        #region Useless SHIT
        private void Whitelist_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion Useless SHIT

        #region Close/Minimize Buttons
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion Close/Minimize Buttons

        #region Links
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://bit.ly/2DdnsUG");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://discord.gg/F4eWqMJ");
        }
        #endregion Links
    }
}
