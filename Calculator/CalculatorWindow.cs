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
        private Stack<string> m_PolishStack = new Stack<string>();
        private bool resultStringActive = false;

        public CalculatorWindow()
        {
            InitializeComponent();
        }

        private void UpdateDebugPoland()
        {
            string polishString = "";
            foreach (string str in m_PolishStack)
            {
                polishString += str + " ";
            }
            debugBox.Text = polishString;
        }

        private void AddToPolishString(string strbit)
        {
            if ( strbit == "" || strbit == "=" ) return;

            m_PolishStack.Push(strbit);
        }

        private void ClearPoland()
        {
            ClearPolandNumber();
            m_PolishStack.Clear();
        }

        string numberString = "";
        private void AddToPolishStringNumber(string number)
        {
            numberString += number;
        }

        private void ClearPolandNumber()
        {
            if (numberString == "") return;

            m_PolishStack.Push(numberString);
            numberString = "";
        }

        private void BuildCalculationString()
        {
            string calcString = "";
            List<string> revString = m_PolishStack.Reverse().ToList();

            foreach (string str in revString)
            {
                calcString += str;
            }

            label2.Text = calcString;
        }

        private void CalculateAnswer()
        {
            if (m_PolishStack.Count <= 1) return;

            TokenReader reader = new TokenReader();

            ICalculationExpression resultExpression = reader.ReadToken(m_PolishStack.ToList());

            ResetInputString();
            BuildCalculationString();

            if (resultExpression != null)
            {
                calcResultLabel.Text = resultExpression.Interpret().ToString();
            }
            else
            {
                calcResultLabel.Text = "0";
                ClearCalculations();
                MessageBox.Show("Kut!");
            }
            UpdateResultOffset(calcResultLabel.Text, calcResultLabel);
            UpdateResultOffset(label2.Text, label2);
        }

        private void ClearCalculations()
        {
            debugBox.Clear();
            ClearPoland();
            heldCalc = "";
        }

        private void ResetInputString()
        {
            m_InputString = "0";
            label2.Text = "0";
            label2.Location = new Point(503, label2.Location.Y);
            calcResultLabel.Text = m_InputString;
            calcResultLabel.Location = new Point(503, calcResultLabel.Location.Y);
        }

        private void UpdateResultOffset(string input, Label label)
        {
            int offsetLabelBy = (input.Length - 1) * 14;
            label.Location = new Point(503 - offsetLabelBy, label.Location.Y);
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button inputButton = (Button)sender;
            AddToPolishStringNumber(inputButton.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ResetInputString();
            ClearCalculations();
        }

        string heldCalc = "";
        private void buttonParseAndAddCalculation_Click(object sender, EventArgs e)
        {
            ResetInputString(); // Reset the input string again

            Button inputButton = (Button)sender;

            string polishString = inputButton.Text;
            ClearPolandNumber();

            if (heldCalc == "")
            {
                if (polishString != heldCalc)
                    heldCalc = polishString;
            }
            else
            {
                AddToPolishString(heldCalc);
                heldCalc = "";
            }

            if (inputButton.Text == "=")
            {
                AddToPolishString(heldCalc);
                heldCalc = "";
            }

            UpdateDebugPoland();

            resultStringActive = true;
            CalculateAnswer();
        }
    }
}
