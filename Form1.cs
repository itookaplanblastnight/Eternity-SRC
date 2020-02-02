using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API;

namespace Eternity
{
    public partial class Form1 : Form
    {
        ExploitAPI api = new ExploitAPI();
        public Form1()
        {
            InitializeComponent();
            WebClient wc = new WebClient();
            InjectionCheck_Timer.Start();
            AutoExecute_Timer.Start();
        }

        #region Monaco
        WebClient wc = new WebClient();
        private string defPath = Application.StartupPath + "//Monaco//";

        private void addIntel(string label, string kind, string detail, string insertText)
        {
            string text = "\"" + label + "\"";
            string text2 = "\"" + kind + "\"";
            string text3 = "\"" + detail + "\"";
            string text4 = "\"" + insertText + "\"";
            webBrowser1.Document.InvokeScript("AddIntellisense", new object[]
            {
                label,
                kind,
                detail,
                insertText
            });
        }
        private void addGlobalF()
        {
            string[] array = File.ReadAllLines(this.defPath + "//globalf.txt");
            foreach (string text in array)
            {
                bool flag = text.Contains(':');
                if (flag)
                {
                    this.addIntel(text, "Function", text, text.Substring(1));
                }
                else
                {
                    this.addIntel(text, "Function", text, text);
                }
            }
        }

        private void addGlobalV()
        {
            foreach (string text in File.ReadLines(this.defPath + "//globalv.txt"))
            {
                this.addIntel(text, "Variable", text, text);
            }
        }

        private void addGlobalNS()
        {
            foreach (string text in File.ReadLines(this.defPath + "//globalns.txt"))
            {
                this.addIntel(text, "Class", text, text);
            }
        }

        private void addMath()
        {
            foreach (string text in File.ReadLines(this.defPath + "//classfunc.txt"))
            {
                this.addIntel(text, "Method", text, text);
            }
        }

        private void addBase()
        {
            foreach (string text in File.ReadLines(this.defPath + "//base.txt"))
            {
                this.addIntel(text, "Keyword", text, text);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.CENTER);
            CheckInjected();
            WebClient wc = new WebClient();
            wc.Proxy = null;
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                bool flag2 = registryKey.GetValue(friendlyName) == null;
                if (flag2)
                {
                    registryKey.SetValue(friendlyName, 11001, RegistryValueKind.DWord);
                }
                registryKey = null;
                friendlyName = null;
            }
            catch (Exception)
            {
            }
            webBrowser1.Url = new Uri(string.Format("file:///{0}/Monaco/Monaco.html", Directory.GetCurrentDirectory()));
            webBrowser1.Document.InvokeScript("SetTheme", new string[]
            {
                   "Dark" 
                   /*
                    There are 2 Themes Dark and Light
                   */
            });
            addBase();
            addMath();
            addGlobalNS();
            addGlobalV();
            addGlobalF();
            webBrowser1.Document.InvokeScript("SetText", new object[]
            {
                 "Welcome " + Environment.UserName + " to Eternity made by ebay employee#1482"
            }); ;
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            ETFunctions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            ETFunctions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }
        #endregion Monaco

        #region Buttons
        private void button8_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 sh = new Form2();
            sh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlDocument document = webBrowser1.Document;
            string scriptName = "GetText";
            object[] args = new string[0];
            object obj = document.InvokeScript(scriptName, args);
            string script = obj.ToString();
            api.SendLuaScript(script);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (ETFunctions.openfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string MainText = File.ReadAllText(ETFunctions.openfiledialog.FileName);
                    webBrowser1.Document.InvokeScript("SetText", new object[]
                    {
                          MainText
                    });

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("SetText", new object[]
            {
                ""
            });
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog ef = new OpenFileDialog();
            ef.Filter = "TXT Files (*.txt)|*.txt|LUA Files (*.lua)|*.lua";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream s = saveFileDialog1.OpenFile();
                StreamWriter sw = new StreamWriter(s);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog ef = new OpenFileDialog();
            ef.Filter = "TXT Files (*.txt)|*.txt|LUA Files (*.lua)|*.lua";
            if (ef.ShowDialog() == DialogResult.OK)
            {
                api.SendLuaScript(File.ReadAllText(ef.FileName));
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion Buttons

        #region ScriptBox Shit
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                this.webBrowser1.Document.InvokeScript("SetText", new object[1]
                {
          (object) System.IO.File.ReadAllText("scripts\\" + this.listBox1.SelectedItem.ToString())
                });
            }
            else
            {
                int num = (int)MessageBox.Show("Please select a script from the list before trying to loading it in tab.", "Eternity");
            }
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                api.SendLuaScript(System.IO.File.ReadAllText("Scripts\\" + this.listBox1.SelectedItem.ToString()));
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            ETFunctions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            ETFunctions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }
        #endregion ScriptBox Shit

        #region Status Checker
        private void CheckInjected()
        {
            if (api.isAPIAttached())
            {
                label2.Text = "Online";
                label2.ForeColor = Color.LightGreen;
            }
            else
            {
                label2.Text = "Offline";
                label2.ForeColor = Color.Red;
            }
        }
        #endregion Status Checker

        #region Useless SHIT
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }
        #endregion Useless SHIT

        #region Timer Code
        private void AutoExecute_Timer_Tick(object sender, EventArgs e)
        {
            string AutoExecute_File = File.ReadAllText("./bin/AutoExec./" + "autoexec.txt");

            if (api.isAPIAttached())
            {
                api.SendLuaScript(AutoExecute_File); //Executes the lua/luac contents of the file
                AutoExecute_Timer.Enabled = false; //Disables the timer after executing
            }
        }

        private void InjectionCheck_Timer_Tick(object sender, EventArgs e)
        {
            Process[] roblox = Process.GetProcessesByName("RobloxPlayerBeta");

            if (!api.isAPIAttached())
            {
                AutoExecute_Timer.Enabled = true;
            }
            CheckInjected();
        }
        #endregion Timer Code

        #region CheckBoxes
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                this.Opacity = 0.75;
            }
            else
            {
                this.Opacity = 1;
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                Process[] DetectFSPUnlocker = Process.GetProcessesByName("rbxfpsunlocker");
                if (DetectFSPUnlocker.Length > 0)
                {
                    foreach (var Kill in Process.GetProcessesByName("rbxfpsunlocker"))
                    {
                        Kill.Kill();
                    }
                    using (Process E = new Process())
                    {
                        E.StartInfo.UseShellExecute = false;
                        E.StartInfo.FileName = "./bin/FpsUnlocker/rbxfpsunlocker.exe";
                        E.StartInfo.CreateNoWindow = true;
                        E.Start();
                    }
                }
                else
                {
                    using (Process E = new Process())
                    {
                        E.StartInfo.UseShellExecute = false;
                        E.StartInfo.FileName = "./bin/FpsUnlocker/rbxfpsunlocker.exe";
                        E.StartInfo.CreateNoWindow = true;
                        E.Start();
                    }
                }
            }
        }
        #endregion CheckBoxes
    }
}
