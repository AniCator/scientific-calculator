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
        private List<ICalculation> calculations = new List<ICalculation>();
        private string m_InputString = "0";
        private bool resultStringActive = false;

        public CalculatorWindow()
        {
            InitializeComponent();
        }

        private void CalculateAnswer()
        {
            double result = 0;
            string lastString = "0";
            string debugString = "";
            for(int i=0;i<calculations.Count;i++)
            {
                ICalculation calc = calculations[i];

                if (calc.GetCalculationType() == CalculationEnum.Number)
                {
                    debugString += calc.GetDataString() + Environment.NewLine;
                }
                if (calc.GetCalculationType() == CalculationEnum.Add)
                {
                    debugString += "+" + Environment.NewLine;
                }
                if (calc.GetCalculationType() == CalculationEnum.Multiply)
                {
                    debugString += "*" + Environment.NewLine;
                }

                result += calc.Operate(lastString);
                lastString = calc.GetDataString();
            }
            debugBox.Text = debugString;
            ResetInputString();
            calcResultLabel.Text = result.ToString();
            UpdateResultOffset(result.ToString());
        }

        private void ClearCalculations()
        {
            calculations.Clear();
            debugBox.Clear();
        }

        private void ResetInputString()
        {
            m_InputString = "0";
            calcResultLabel.Text = m_InputString;
            calcResultLabel.Location = new Point(503, 51);
        }

        private bool PrepareInputString(string n)
        {
            if (resultStringActive)
            {
                resultStringActive = false;
                ResetInputString();
            }
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
            UpdateResultOffset();
        }

        private void UpdateResultOffset()
        {
            int offsetLabelBy = (m_InputString.Length - 1) * 14;
            calcResultLabel.Location = new Point(503 - offsetLabelBy, 51);
        }

        private void UpdateResultOffset(string input)
        {
            int offsetLabelBy = (input.Length - 1) * 14;
            calcResultLabel.Location = new Point(503 - offsetLabelBy, 51);
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button inputButton = (Button)sender;
            AddToInputString(inputButton.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ResetInputString();
            ClearCalculations();
        }

        private void buttonParseAndAddCalculation_Click(object sender, EventArgs e)
        {
            // Add input string to calculations list
            Number newNumber = new Number();
            newNumber.SetDataString(m_InputString);
            calculations.Add(newNumber);
            ResetInputString(); // Reset the input string again

            Button inputButton = (Button)sender;
            switch (inputButton.Text)
            {
                case "+":
                    CalculationAdd newAdd = new CalculationAdd();
                    newAdd.SetDataString(newNumber.GetDataString());
                    calculations.Add(newAdd);
                    break;
                case "*":
                    CalculationMultiply newMultiply = new CalculationMultiply(); ;
                    newMultiply.SetDataString(newNumber.GetDataString());
                    calculations.Add(newMultiply);
                    break;

            }
            resultStringActive = true;
            CalculateAnswer();
        }
    }
}
