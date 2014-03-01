using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace eABM_tisk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listAllPrinters();
            this.TopMost = checkAlwaysTop.Checked;
        }

        private void listAllPrinters()
        {
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                this.listBox1.Items.Add(item.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pname = this.listBox1.SelectedItem.ToString();
            myPrinters.SetDefaultPrinter(pname);
        }

        public static class myPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);
        }

        private void checkAlwaysTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkAlwaysTop.Checked;
        }
    }
}
