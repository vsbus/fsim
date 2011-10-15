using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int m_counter;
        readonly List<fsModule> m_modules = new List<fsModule>();

        private void RebuildWindowsList()
        {
            DataGridViewCell cell = windowsDataGrid.CurrentCell;
            string currentWindowName = cell == null || cell.Value == null
                ? ""
                : cell.Value.ToString();
            windowsDataGrid.Rows.Clear();
            foreach (var module in m_modules)
            {
                int ind = windowsDataGrid.Rows.Add(module.Name);
                if (module.Name == currentWindowName)
                {
                    windowsDataGrid.CurrentCell = windowsDataGrid[0, ind];
                }
            }
        }

        void FormClose(object sender, EventArgs e)
        {
            string text = ((Form)sender).Text;
            foreach (var f in m_modules)
            {
                if (f.Name == text)
                {
                    m_modules.Remove(f);
                    RebuildWindowsList();
                    return;
                }
            }
        }

        private void WindowsDataGridCurrentCellChanged(object sender, EventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            DataGridViewCell cell = dataGrid.CurrentCell;
            if (cell != null && cell.Value != null)
            {
                string text = cell.Value.ToString();
                foreach (var module in m_modules)
                {
                    if (module.Name == text)
                    {
                        module.Form.Activate();
                        dataGrid.Focus();
                    }
                }
            }
        }

        private void AddModuleButtonClick(object sender, EventArgs e)
        {
            var modulesForm = new fsModulesForm();
            modulesForm.ShowDialog();
            if (modulesForm.DialogResult == DialogResult.OK)
            {
                ++m_counter;
                var module = new fsModule("Module #" + m_counter, modulesForm.SelectedModule);
                m_modules.Add(module);
                module.Form.MdiParent = this;
                module.Form.Closed += FormClose;
                RebuildWindowsList();
                windowsDataGrid.CurrentCell = windowsDataGrid[0, windowsDataGrid.RowCount - 1];
            }
        }

        private void WindowTilesToolStripMenuItemClick(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            int maxHeight = 0;
            foreach (var module in m_modules)
            {
                if (x > 0 && x + module.Form.Width > ClientSize.Width)
                {
                    x = 0;
                    y += maxHeight;
                    maxHeight = 0;
                }
                module.Form.Left = x;
                module.Form.Top = y;
                x += module.Form.Width;
                maxHeight = Math.Max(maxHeight, module.Form.Height);
            }
        }

        private void CloseToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            addModuleButton.PerformClick();
        }
    }
}
