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
        public UnitsDialog()
        {
            InitializeComponent();
        }

        private void UnitsDialog_Load(object sender, EventArgs e)
        {
            Type type = typeof(fsCharacteristic);
            FieldInfo[] fields = type.GetFields();
            int currentHeight = 8;
            foreach (var field in fields)
            {
                var row = new DataGridViewRow();
                //var cells = new DataGridViewCell[2];
                var characteristicLabel = new Label();
                characteristicLabel.Parent = panel1;
                characteristicLabel.Location = new Point(8, currentHeight);
                characteristicLabel.Text = field.Name;
                var unitsComboBox = new ComboBox();
                unitsComboBox.Parent = panel1;
                unitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                unitsComboBox.Location = new Point(8 + 100, currentHeight);
                foreach (var unit in ((fsCharacteristic)field.GetValue(null)).Units)
                {
                    unitsComboBox.Items.Add(unit.Name);
                }
                unitsComboBox.Text = unitsComboBox.Items[0].ToString();

                currentHeight += 28;

//                 object temp = field.GetValue(null); // Get value
//                 if (temp is int) // See if it is an integer.
//                 {
//                     int value = (int)temp;
//                     Console.Write(name);
//                     Console.Write(" (int) = ");
//                     Console.WriteLine(value);
//                 }
//                 else if (temp is string) // See if it is a string.
//                 {
//                     string value = temp as string;
//                     Console.Write(name);
//                     Console.Write(" (string) = ");
//                     Console.WriteLine(value);
//                 }
            }
        }
    }
}
