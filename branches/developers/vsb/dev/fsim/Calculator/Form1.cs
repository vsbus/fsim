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
            
        }

        private void RebuildWindowsList()
        {
            DataGridViewCell cell = windowsDataGrid.CurrentCell;
            string currentWindowName = cell == null || cell.Value == null
                ? ""
                : cell.Value.ToString();
            windowsDataGrid.Rows.Clear();
            foreach (var f in activeForms)
            {
                int ind = windowsDataGrid.Rows.Add(f.Text);
                if (f.Text == currentWindowName)
                {
                    windowsDataGrid.CurrentCell = windowsDataGrid[0, ind];
                }
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

        private void windowsDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;
            DataGridViewCell cell = dataGrid.CurrentCell;
            if (cell != null && cell.Value != null)
            {
                string text = cell.Value.ToString();
                foreach (var form in activeForms)
                {
                    if (form.Text == text)
                    {
                        form.Activate();
                        dataGrid.Focus();
                    }
                }
            }
        }

        private void addModuleButton_Click(object sender, EventArgs e)
        {
            var modulesForm = new ModulesForm();
            modulesForm.ShowDialog();
            if (modulesForm.DialogResult == DialogResult.OK)
            {
                var form = new Form();
                form.Text = "Form #" + counter.ToString();
                form.Width = modulesForm.SelectedModule.Width + 10;
                form.Height = modulesForm.SelectedModule.Height + 10;
                modulesForm.SelectedModule.Parent = form;
                modulesForm.SelectedModule.Dock = DockStyle.Fill;
                ++counter;
                activeForms.Add(form);
                form.MdiParent = this;
                form.Show();
                form.Closed += FormClose;
                RebuildWindowsList();
                windowsDataGrid.CurrentCell = windowsDataGrid[0, windowsDataGrid.RowCount - 1];
            }
        }

        private void windowTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            int maxHeight = 0;
            foreach (var form in activeForms)
            {
                if (x > 0 && x + form.Width > ClientSize.Width)
                {
                    x = 0;
                    y += maxHeight;
                    maxHeight = 0;
                }
                form.Left = x;
                form.Top = y;
                x += form.Width;
                maxHeight = Math.Max(maxHeight, form.Height);
            }
        }
    }
}
