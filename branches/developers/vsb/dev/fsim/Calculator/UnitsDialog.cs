using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Units;

namespace Calculator
{
    public partial class fsUnitsDialog : Form
    {
        private readonly Dictionary<fsCharacteristic, ComboBox> m_unitsToComboBox = new Dictionary<fsCharacteristic, ComboBox>();
        public Dictionary<fsCharacteristic, fsCharacteristic.fsUnit> Units = new Dictionary<fsCharacteristic, fsCharacteristic.fsUnit>();
        private readonly Dictionary<fsModule, CheckBox> m_moduleToCheckBox = new Dictionary<fsModule, CheckBox>();
        private List<fsModule> m_modules;

        public fsUnitsDialog()
        {
            InitializeComponent();
        }

        private void UnitsDialogLoad(object sender, EventArgs e)
        {
            InitializeElementListing();
            InitializeUnitsPanel();
        }

        public List<fsModule> GetModifiedModules()
        {
            var modifiedModules = new List<fsModule>();
            foreach (var pair in m_moduleToCheckBox)
            {
                if (pair.Value.Checked)
                {
                    modifiedModules.Add(pair.Key);
                }
            }
            return modifiedModules;
        }

        public bool GetFutureModulesModified()
        {
            return m_futureCheckBox.Checked;
        }

        private void InitializeElementListing()
        {
            var checkBox = new CheckBox {Parent = listingPanel, Location = new Point(8, 16), Text = @"All"};
            checkBox.CheckStateChanged += CheckBoxCheckStateChanged;

            if (m_modules != null)
            {
                foreach (var module in m_modules)
                {
                    AddModuleToList(module.Name, false, module);
                }
            }
        }

        public void AssignModulesList(List<fsModule> modules)
        {
            m_modules = modules;
        }

        void CheckBoxCheckStateChanged(object sender, EventArgs e)
        {
            var allCheckBox = (CheckBox) sender;
            foreach (var checkBox in m_moduleToCheckBox.Values)
            {
                checkBox.Checked = allCheckBox.Checked;
            }
        }

        private void AddModuleToList(string text, bool isChecked, fsModule module)
        {
            var checkBox = new CheckBox
                               {
                                   Parent = listingPanel,
                                   Location = new Point(8, 48 + 8 + (m_moduleToCheckBox.Count) * 24),
                                   Text = text,
                                   Checked = isChecked,
                                   AutoSize = true
                               };
            m_moduleToCheckBox[module] = checkBox;
        }

        private void InitializeUnitsPanel()
        {
            Type type = typeof(fsCharacteristic);
            FieldInfo[] fields = type.GetFields();
            var characteristicControls = new List<KeyValuePair<Label, ComboBox>>();
            unitsPanel.Width = 0;
            foreach (var field in fields)
            {
                var characteristicLabel = new Label {Text = field.Name, AutoSize = true};

                var unitsComboBox = new ComboBox();
                var characteristic = ((fsCharacteristic)field.GetValue(null));
                foreach (var unit in characteristic.Units)
                {
                    unitsComboBox.Items.Add(unit.Name);
                }
                unitsComboBox.Text = characteristic.CurrentUnit.Name;

                int width = 8 + characteristicLabel.Width + 8 + unitsComboBox.Width + 8 + 48;
                if (unitsPanel.Width < width)
                {
                    unitsPanel.Width = width;
                }

                characteristicControls.Add(new KeyValuePair<Label, ComboBox>(characteristicLabel, unitsComboBox));
                m_unitsToComboBox[characteristic] = unitsComboBox;
            }

            int currentHeight = 8;
            foreach (var pair in characteristicControls)
            {
                var characteristicLabel = pair.Key;
                var unitsComboBox = pair.Value;

                unitsComboBox.Parent = unitsPanel;
                unitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                unitsComboBox.Location = new Point(unitsPanel.Width - unitsComboBox.Width - 24, currentHeight);

                characteristicLabel.Parent = unitsPanel;
                characteristicLabel.Location = new Point(unitsComboBox.Location.X - 8 - characteristicLabel.Width - 8, currentHeight + 4);

                currentHeight += 24;
            }
        }
        private void Button1Click(object sender, EventArgs e)
        {
            foreach (var pair in m_unitsToComboBox)
            {
                Units[pair.Key] = fsCharacteristic.fsUnit.UnitFromText(pair.Value.Text);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button2Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
