// Copyright (C) 2018. Written by Ahmed Reza Rafsanzani | github.com/medreza | rza272@gmail.com
// Check MIT License for usage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace focus_bar
{
    public static class Global
    {
        public static int formCount { get; set; }
    }

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height+100;
            this.TopMost = true;
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.TopMost = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Global.formCount -= 1;
            Console.WriteLine(Global.formCount);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Global.formCount >= 4)
            {
                MessageBox.Show("For you convenience, we cannot create more than 5 bars :)", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                Form1 newForm = new Form1();
                newForm.Show();
                Global.formCount += 1;
                newForm.button2.Text = "Close";
                Console.WriteLine(Global.formCount);
            }
        }
    }
}
