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
    public partial class CalculatorWindow : Form
    {
        private string m_InputString = "0";
        public CalculatorWindow()
        {
            InitializeComponent();
        }

        private void ResetInputString()
        {
            m_InputString = "0";
            calcResultLabel.Text = m_InputString;
            calcResultLabel.Location = new Point(503, 51);
        }

        private void AddToInputString(string n)
        {
            m_InputString += n;
            calcResultLabel.Text = m_InputString;
            int offsetLabelBy = (m_InputString.Length - 1) * 14;
            calcResultLabel.Location = new Point(503 - offsetLabelBy, 51);
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            AddToInputString("0");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ResetInputString();
        }
    }
}
