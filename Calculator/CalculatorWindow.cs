﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Calculator
{
    struct OpPrec
    {
        public string optoken;
        public string opprec;
        public bool opassoc;
    }

    public partial class CalculatorWindow : Form
    {
        List<OpPrec> operatorInfo = new List<OpPrec>();

        private string m_InputString = "0";
        private Stack<string> m_PolishStack = new Stack<string>();
        bool resultStringActive = false;

        private string m_sInfixString = "";

        public CalculatorWindow()
        {
            AddOperationToken("+", "2", false);
            AddOperationToken("-", "2", false);
            AddOperationToken("/", "3", false);
            AddOperationToken("*", "3", false);
            AddOperationToken("^", "4", true);

            AddOperationToken("pow2", "5", true);
            AddOperationToken("sqrt", "5", true);

            InitializeComponent();
        }

        private void AddOperationToken(string optoken_in, string opprec_in, bool opassoc_in)
        {
            OpPrec data;
            data.optoken = optoken_in;
            data.opprec = opprec_in;
            data.opassoc = opassoc_in;

            operatorInfo.Add(data);
        }

        private bool IsOperator(string token)
        {
            foreach (OpPrec op in operatorInfo)
            {
                if (op.optoken == token)
                    return true;
            }
            return false;
        }

        private bool IsAssociative(String token, bool type)
        {
            if (!IsOperator(token))
            {
                throw new ArgumentException("Invalid token: " + token);
            }
            foreach (OpPrec op in operatorInfo)
            {
                if (op.optoken == token)
                {
                    if (op.opassoc == type)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int ComparePrecedence(String token1, String token2) {
		    if (!IsOperator(token1) || !IsOperator(token2))
            {
			    throw new ArgumentException("Invalid tokens: " + token1
					    + " " + token2);
		    }

            int prec1 = 0;
            int prec2 = 0;
            foreach (OpPrec op in operatorInfo)
            {
                if (op.optoken == token1)
                {
                    prec1 = int.Parse(op.opprec);
                }
                if (op.optoken == token2)
                {
                    prec2 = int.Parse(op.opprec);
                }
            }

            return prec1 - prec2;
	    }

        private void UpdateDebugPoland()
        {
            return;
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
            PushNumberString();
            m_PolishStack.Clear();
        }

        string numberString = "";
        private void AddToPolishStringNumber(string number)
        {
            numberString += number;
        }

        private void PushNumberString()
        {
            if (numberString == "") return;

            bool NumberOnTop = false;

            try
            {
                Double.Parse(m_PolishStack.Peek());
                // Fails if it can't parse
                NumberOnTop = true;
            }
            catch (System.Exception ex)
            {
                NumberOnTop = false;
            }

            if (NumberOnTop)
            {
                string PreviousString = m_PolishStack.Pop();
                numberString = PreviousString + numberString;
            }

            m_PolishStack.Push(numberString);
            //m_sInfixString = ConvertRPNToInfix(m_PolishStack.ToArray());
            m_sInfixString += numberString + " ";

            numberString = "";
        }

        private void BuildCalculationString()
        {
            if (m_PolishStack.Count < 1) return;

            string polishString = "";
            foreach (string str in m_PolishStack)
            {
                polishString += str + " ";
            }

            polishString = polishString.Substring(0, polishString.Length - 1);

            //calculationLabel.Text = ConvertRPNToInfix(polishString.Split(' '));
            calculationLabel.Text = m_sInfixString;

            UpdateResultOffset(calculationLabel.Text, calculationLabel);
        }

        private void UpdateResultLabel()
        {
            //calculationLabel.Text = ConvertRPNToInfix(m_PolishStack.ToArray());
            //calculationLabel.Text = m_sInfixString;
            UpdateResultOffset(calculationLabel.Text, calculationLabel);
        }

        private bool IsEmptySpace(string s)
        {
            if (s == " ")
                return true;
            return false;
        }

        private void CalculateAnswer()
        {
            //if (m_PolishStack.Count <= 1) return;

            TokenReader reader = new TokenReader();

            List<string> polishTokenList = m_PolishStack.ToList();
            List<string> splitString = m_sInfixString.Split(' ').ToList();
            splitString.RemoveAll(IsEmptySpace);
            splitString.RemoveAt(splitString.Count - 1);

            string rpnString = ConvertInfixToRPN(splitString.ToArray());
            List<string> rpnDisplayString = rpnString.Split(' ').ToList();
            rpnDisplayString.Reverse();
            //rpnDisplayString.RemoveAt(rpnDisplayString.Count - 1);
            rpnDisplayString.RemoveAt(0);

            string stackRpnString = "";
            foreach (string token in polishTokenList)
            {
                stackRpnString += token + " ";
            }

            //debugBox.Text = stackRpnString + Environment.NewLine + m_sInfixString;

            ICalculationExpression resultExpression = null;
            try
            {
                resultExpression = reader.ReadToken(rpnDisplayString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            ResetInputString();
            BuildCalculationString();

            if (resultExpression != null)
            {
                double result = resultExpression.Interpret();
                calcResultLabel.Text = result.ToString();
            }
            else
            {
                calcResultLabel.Text = "Error";
                //ClearCalculations();
                Console.WriteLine("Error: resultExpression is a 'null' object");
            }
            UpdateResultOffset(calcResultLabel.Text, calcResultLabel);
        }

        private void ClearCalculations()
        {
            debugBox.Clear();
            ClearPoland();
            m_sInfixString = "";
            sHeldCalc = "";
        }

        private void ResetInputString()
        {
            m_InputString = "0";
            calculationLabel.Text = "0";
            calculationLabel.Location = new Point(503, calculationLabel.Location.Y);
            calcResultLabel.Text = m_InputString;
            calcResultLabel.Location = new Point(503, calcResultLabel.Location.Y);
        }

        private void UpdateResultOffset(string input, Label label)
        {
            int offsetLabelBy = (input.Length - 1) * 11;
            label.Location = new Point(503 - offsetLabelBy, label.Location.Y);
        }

        private void AddNumber(string number_text)
        {
            if (bFinishedCalculation)
            {
                ClearCalculations();
                bFinishedCalculation = false;
            }

            bHoldingOperator = false;

            AddToPolishStringNumber(number_text);
            bCopyCalc = true;

            PushNumberString();

            UpdateResultLabel();
            BuildCalculationString();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button inputButton = (Button)sender;
            AddNumber(inputButton.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ResetInputString();
            ClearCalculations();
        }

        bool bCopyCalc = false;
        bool bFinishedCalculation = false;
        bool bHoldingOperator = false;
        string sHeldCalc = "";
        private void buttonParseAndAddCalculation_Click(object sender, EventArgs e)
        {
            ResetInputString(); // Reset the input string again

            Button inputButton = (Button)sender;

            string polishString = inputButton.Text;
            bool bOperatorInput = IsOperator(inputButton.Text);

            if (inputButton.Text != "=" && inputButton.Text != "")
            {
                m_sInfixString += polishString + " ";
            }

            // Add held calculation symbol if user wants to finish calculation
            //if (bHoldingOperator && bOperatorInput)
            {
                sHeldCalc = polishString;
                bHoldingOperator = false;
            }
            //else
            {
                if (inputButton.Text == "=")
                {
                    AddToPolishString(sHeldCalc);
                    sHeldCalc = "";
                    bFinishedCalculation = true;
                }
                else if (sHeldCalc == "")
                {
                    bFinishedCalculation = false;
                    if (polishString != sHeldCalc)
                    {
                        sHeldCalc = polishString;
                    }
                }
                else
                {
                    bFinishedCalculation = false;
                    if (bCopyCalc)
                    {
                        AddToPolishString(sHeldCalc);
                        sHeldCalc = polishString;
                        bCopyCalc = false;
                    }
                    else
                    {
                        sHeldCalc = "";
                    }
                }

                bHoldingOperator = bOperatorInput;
            }

            UpdateResultLabel();

            resultStringActive = true;
            CalculateAnswer();
        }

        private string ConvertInfixToRPN(string[] inputTokens)
        {
            List<string> output = new List<string>();
            Stack<string> stack = new Stack<string>();

            foreach (string token in inputTokens)
            {
                if (IsOperator(token)) // If token is operator
                {
                    while (stack.Count != 0 && IsOperator(stack.Peek())) // check stack not empty and top item in stack is operator
                    {
                        if ((IsAssociative(token, false) && ComparePrecedence(
							token, stack.Peek()) <= 0)
							|| (IsAssociative(token, true) && ComparePrecedence(
									token, stack.Peek()) < 0)) // check which operator should go in first
                        {
                            output.Add(stack.Pop());
                            continue;
                        }
                        break;
                    }
                    stack.Push(token); // push operator to the stack
                }
                else if (token.Equals("("))
                {
                    stack.Push(token); // push it directly
                }
                else if (token.Equals(")"))
                {
                    while (stack.Count != 0 && !stack.Peek().Equals("(")) // while stack isn't empty and next item in the stack isn't a (
                    {
					    output.Add(stack.Pop()); // pop it and add it to the output list
                    }
                    if (stack.Count != 0)
                        stack.Pop(); // pop whatever
                }
                else
                {
                    output.Add(token); // a number, just add it
                }
            }

            while (stack.Count != 0) // add items from the stack to the output list until it is empty
            {
                output.Add(stack.Pop());
            }

            // Construct output string
            string[] outputStringArray = new string[output.Count];
            outputStringArray = output.ToArray();

            string outputString = "";
            foreach (string str in outputStringArray)
            {
                outputString += str + " ";
            }
            return outputString;
        }

        private string ConvertRPNToInfix(string[] inputTokens) // TODO: Still requires a bunch of work
        {
            List<string> output = new List<string>();
            Stack<string> stack = new Stack<string>();

            debugBox.Clear();

            foreach (string token in inputTokens)
            {
                debugBox.Text += token + " ";
                if (IsOperator(token))
                {
                    stack.Push(token);
                    continue;
                }
                else if (token.Equals("("))
                {
                    stack.Push(token); // push it directly
                }
                else if (token.Equals(")"))
                {
                    while (stack.Count != 0 && !stack.Peek().Equals("(")) // while stack isn't empty and next item in the stack isn't a (
                    {
                        output.Add(stack.Pop()); // pop it and add it to the output list
                    }
                    if(stack.Count != 0)
                        stack.Pop(); // pop whatever
                }
                else
                {
                    output.Add(token);
                }
                
                while (stack.Count != 0)
                {
                    output.Add(stack.Pop());
                }
            }

            // Construct output string
            output.Reverse();
            string[] outputStringArray = new string[output.Count];
            outputStringArray = output.ToArray();

            string outputString = "";
            foreach (string str in outputStringArray)
            {
                outputString += str + " ";
            }

            return outputString;
        }

        private void CalculatorWindow_KeyPress(object sender, KeyEventArgs e)
        {
            string value = "nan";

            if (e.KeyValue >= ((int)Keys.NumPad0) && e.KeyValue <= ((int)Keys.NumPad9))
            {
                // Numpad key
                value = (e.KeyValue - ((int)Keys.NumPad0)).ToString();
            }
            else if (e.KeyValue >= ((int)Keys.D0) && e.KeyValue <= ((int)Keys.D9))
            {
                // Regular number key
                value = (e.KeyValue - ((int)Keys.D0)).ToString();
            }

            if (value != "nan")
            {
                AddNumber(value.ToString());
            }
            else
            {
                switch (e.KeyData)
                {
                    case Keys.Add:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
