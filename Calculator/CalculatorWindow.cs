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

        private bool PrepareInputString(string n)
        {
            if (n == "." && m_InputString.Contains("."))
                return false;
            if (n == m_InputString && n == "0")
                return false;
            if (m_InputString == "0" && n != "0")
                m_InputString = "";
            if (n == "." && m_InputString == "")
                m_InputString = "0";
            return true;
        }

        private void AddToInputString(string n)
        {
            if (!PrepareInputString(n))
                return;
            m_InputString += n;
            calcResultLabel.Text = m_InputString;
            int offsetLabelBy = (m_InputString.Length - 1) * 14;
            calcResultLabel.Location = new Point(503 - offsetLabelBy, 51);
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button inputLabel = (Button)sender;
            AddToInputString(inputLabel.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ResetInputString();
        }
    }
}
