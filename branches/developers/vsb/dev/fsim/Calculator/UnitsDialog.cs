using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Units;
using System.ComponentModel;

namespace Calculator
{
    public partial class fsUnitsDialog : Form
    {
        public Dictionary<fsCharacteristic, fsUnit> Characteristics = new Dictionary<fsCharacteristic, fsUnit>();
        
        private readonly Dictionary<fsCharacteristic, ComboBox> m_characteristicToComboBox = new Dictionary<fsCharacteristic, ComboBox>();
        private readonly Dictionary<fsCharacteristic, Label> m_characteristicToLabel = new Dictionary<fsCharacteristic, Label>();
        private readonly Dictionary<fsModule, CheckBox> m_moduleToCheckBox = new Dictionary<fsModule, CheckBox>();
        private List<fsModule> m_modules;

        private class Scheme
        {
            public Dictionary<fsCharacteristic, fsUnit> CharacteristicToUnit { get; private set; }

            public string Name { get; private set; }

            Scheme (string name, params KeyValuePair<fsCharacteristic, fsUnit> [] characteristicToUnit)
            {
                CharacteristicToUnit = new Dictionary<fsCharacteristic, fsUnit>();
                Name = name;
                foreach (var pair in characteristicToUnit)
                {
                    CharacteristicToUnit.Add(pair.Key, pair.Value);
                }
            }

            public static Scheme SI = new Scheme("SI", new[] {
                new KeyValuePair<fsCharacteristic, fsUnit>(fsCharacteristic.Mass, fsUnit.KiloGramme),
                new KeyValuePair<fsCharacteristic, fsUnit>(fsCharacteristic.Area, fsUnit.SquareMeter),
                new KeyValuePair<fsCharacteristic, fsUnit>(fsCharacteristic.MassFlowrate, fsUnit.KiloGrammePerSec),
                new KeyValuePair<fsCharacteristic, fsUnit>(fsCharacteristic.Volume, fsUnit.CubicMeter)
            });

            public static Scheme Laboratory = new Scheme("Laboratory", new[] {
                new KeyValuePair<fsCharacteristic, fsUnit>(fsCharacteristic.Mass, fsUnit.KiloGramme),
                new KeyValuePair<fsCharacteristic, fsUnit>(fsCharacteristic.Area, fsUnit.SquareSantiMeter),
                new KeyValuePair<fsCharacteristic, fsUnit>(fsCharacteristic.MassFlowrate, fsUnit.KiloGrammePerMin),
                new KeyValuePair<fsCharacteristic, fsUnit>(fsCharacteristic.Volume, fsUnit.Liter)
            });
        }

        public fsUnitsDialog()
        {
            InitializeComponent();
            InitializeShemeBox();
        }

        private void InitializeShemeBox()
        {
            schemeBox.Items.Add("Custom");
            schemeBox.SelectedItem = schemeBox.Items[0];

            schemeBox.Items.Add(Scheme.SI.Name);
            schemeBox.Items.Add(Scheme.Laboratory.Name);
        }

        private void UnitsDialogLoad(object sender, EventArgs e)
        {
            InitializeElementListing();
            InitializeUnitsPanel();
            ShowHideSecondaryCharacteristics(m_showSecondaryCheckbox.Checked);
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

        private fsCharacteristic[] GetPrimaryCharacteristics()
        {
            return new fsCharacteristic[]{
                fsCharacteristic.Time,
                fsCharacteristic.Area,
                fsCharacteristic.Mass,
                fsCharacteristic.Volume,
                fsCharacteristic.MassFlowrate
            }; 
        }

        private fsCharacteristic[] GetSecondaryCharacteristics()
        {
            return new fsCharacteristic[]{
                fsCharacteristic.Pressure,
                fsCharacteristic.Viscosity,
                fsCharacteristic.Density,
                fsCharacteristic.SurfaceTension,
                fsCharacteristic.CakeWashOutContent,
                fsCharacteristic.Frequency
            };
        }

        private void InitializeUnitsPanel()
        {
            var primaryCharacteristics = GetPrimaryCharacteristics();
            var secondaryCharacteristics = GetSecondaryCharacteristics();

            var allCharacteristics = new List<fsCharacteristic>();
            allCharacteristics.AddRange(primaryCharacteristics);
            allCharacteristics.AddRange(secondaryCharacteristics);

            var characteristicControls = new List<KeyValuePair<Label, ComboBox>>();
            unitsPanel.Width = 0;
            foreach (fsCharacteristic characteristic in allCharacteristics)
            {
                var characteristicLabel = new Label { Text = characteristic.Name, AutoSize = true };
                
                var unitsComboBox = new ComboBox();
                               
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
                m_characteristicToComboBox[characteristic] = unitsComboBox;
                m_characteristicToLabel[characteristic] = characteristicLabel;
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

                currentHeight += 32;
            }
        }
        private void Button1Click(object sender, EventArgs e)
        {
            foreach (var pair in m_characteristicToComboBox)
            {
                Characteristics[pair.Key] = fsUnit.UnitFromText(pair.Value.Text);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button2Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ParametersDisplay_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideSecondaryCharacteristics(m_showSecondaryCheckbox.Checked);
        }

        private void ShowHideSecondaryCharacteristics(bool isVisible)
        {
            foreach (var characteristic in GetSecondaryCharacteristics())
            {
                m_characteristicToComboBox[characteristic].Visible = isVisible;
                m_characteristicToLabel[characteristic].Visible = isVisible;
            }
        }

        private void schemeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedScheme = schemeBox.SelectedItem.ToString();
            if (selectedScheme == "Custom")
                return;
            var type = typeof(Scheme);
            foreach (var field in type.GetFields())
            {
                var scheme = ((Scheme)field.GetValue(null));
                if (selectedScheme == scheme.Name)
                {
                    UpdateSchemeBox(scheme.CharacteristicToUnit);
                    return;
                }
            }
        }

        private void UpdateSchemeBox(Dictionary<fsCharacteristic, fsUnit> dictionary)
        {
            foreach (var pair in dictionary)
            {
                m_characteristicToComboBox[pair.Key].Text = pair.Value.Name;
            }    
        }
    }
}
