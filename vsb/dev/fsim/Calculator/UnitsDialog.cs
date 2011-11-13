using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Units;

namespace Calculator
{
    public partial class UnitsDialog : Form
    {
        public Dictionary<Type, ComboBox> Characteristics = new Dictionary<Type, ComboBox>();

        public UnitsDialog()
        {
            InitializeComponent();
        }

        private void UnitsDialog_Load(object sender, EventArgs e)
        {
            Type type = typeof(fsCharacteristic);
            FieldInfo[] fields = type.GetFields();
            List<KeyValuePair<Label, ComboBox>> characteristicControls = new List<KeyValuePair<Label, ComboBox>>();
            panel1.Width = 0;
            foreach (var field in fields)
            {
                var characteristicLabel = new Label();
                characteristicLabel.Text = field.Name;
                
                var unitsComboBox = new ComboBox();
                foreach (var unit in ((fsCharacteristic)field.GetValue(null)).Units)
                {
                    unitsComboBox.Items.Add(unit.Name);
                }
                unitsComboBox.Text = unitsComboBox.Items[0].ToString();

                int width = 8 + characteristicLabel.Width + 8 + unitsComboBox.Width + 8;
                if (panel1.Width < width)
                {
                    panel1.Width = width;
                }
                
                characteristicControls.Add(new KeyValuePair<Label, ComboBox>(characteristicLabel, unitsComboBox));
                Characteristics[type] = unitsComboBox;
            }

            int currentHeight = 8;
            foreach (var pair in characteristicControls)
            {
                var characteristicLabel = pair.Key;
                var unitsComboBox = pair.Value;

                characteristicLabel.Parent = panel1;
                characteristicLabel.Location = new Point(8, currentHeight + 4);

                unitsComboBox.Parent = panel1;
                unitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                unitsComboBox.Location = new Point(panel1.Width - unitsComboBox.Width - 8, currentHeight);

                currentHeight += 24;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
