using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int counter = 0;
        List<Form> activeForms = new List<Form>();

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Text = "Form #" + counter.ToString();
            ++counter;
            activeForms.Add(form);
            form.MdiParent = this;
            form.Show();
            form.Closed += FormClose;
            RebuildWindowsList();
        }

        private void RebuildWindowsList()
        {
            windowToolStripMenuItem.DropDownItems.Clear();
            foreach( var f in activeForms)
            {
                var item = windowToolStripMenuItem.DropDownItems.Add(f.Text);
                item.Click += ActivateWindow;
            }
        }

        void FormClose(object sender, EventArgs e)
        {
            string text = ((Form)sender).Text;
            foreach (var f in activeForms)
            {
                if (f.Text == text)
                {
                    activeForms.Remove(f);
                    RebuildWindowsList();
                    return;
                }
            }
        }

        void ActivateWindow(object sender, EventArgs e)
        {
            string text = ((ToolStripItem) sender).Text;
            foreach (var f in activeForms)
            {
                if (f.Text == text)
                {
                    f.Activate();
                }
            }
        }
    }
}
