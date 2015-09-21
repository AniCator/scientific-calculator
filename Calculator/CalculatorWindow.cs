using System;
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
    struct OperatorPrecedenceInfo
    {
        public string Token;
        public string Precedence;
        public bool Associative;
    }

    public partial class CalculatorWindow : Form
    {
        List<OperatorPrecedenceInfo> m_OperatorPrecedenceInfo = new List<OperatorPrecedenceInfo>();

        private string m_InputString = "0";
        private string m_InfixString = "";
        private double m_Memory = 0.0;

        private Stack<string> m_PolishStack = new Stack<string>();

        public CalculatorWindow()
        {
            // Standard operators
            AddOperationToken("+", "2", false);
            AddOperationToken("-", "2", false);
            AddOperationToken("/", "3", false);
            AddOperationToken("*", "3", false);
            AddOperationToken("^", "4", true);

            // Function operators
            AddOperationToken("pow2", "5", true);
            AddOperationToken("√", "5", true);

            InitializeComponent();
        }

        private void AddOperationToken(string inToken, string inPrecedence, bool inAssociative)
        {
            OperatorPrecedenceInfo data;
            data.Token = inToken;
            data.Precedence = inPrecedence;
            data.Associative = inAssociative;

            m_OperatorPrecedenceInfo.Add(data);
        }

        private bool IsOperator(string token)
        {
            foreach (OperatorPrecedenceInfo OperatorType in m_OperatorPrecedenceInfo)
            {
                if (OperatorType.Token == token)
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
            foreach (OperatorPrecedenceInfo op in m_OperatorPrecedenceInfo)
            {
                if (op.Token == token)
                {
                    if (op.Associative == type)
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
            foreach (OperatorPrecedenceInfo op in m_OperatorPrecedenceInfo)
            {
                if (op.Token == token1)
                {
                    prec1 = int.Parse(op.Precedence);
                }
                if (op.Token == token2)
                {
                    prec2 = int.Parse(op.Precedence);
                }
            }

            return prec1 - prec2;
	    }

        private void UpdateDebugPoland()
        {
            return;
            /*string polishString = "";
            foreach (string str in m_PolishStack)
            {
                polishString += str + " ";
            }
            debugBox.Text = polishString;*/
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

        string m_NumberString = "";
        private void AddToPolishStringNumber(string number)
        {
            m_NumberString += number;
        }

        private void PushNumberString()
        {
            if (m_NumberString == "") return;

            bool NumberOnTop = false;

            try
            {
                Double.Parse(m_PolishStack.Peek());
                // Fails if it can't parse
                NumberOnTop = true;
            }
            catch (System.Exception)
            {
                NumberOnTop = false;
            }

            if (NumberOnTop)
            {
                string PreviousString = m_PolishStack.Pop();
                //m_NumberString = PreviousString + m_NumberString;
            }

            m_PolishStack.Push(m_NumberString);
            //m_InfixString = ConvertRPNToInfix(m_PolishStack.ToArray());
            m_InfixString += m_NumberString + " ";

            m_NumberString = "";
        }

        private void BuildCalculationString()
        {
            calculationLabel.Text = m_InfixString;

            if (m_NumberString != "")
            {
                calculationLabel.Text += m_NumberString;
            }
        }

        private void UpdateResultLabel()
        {
            //calculationLabel.Text = ConvertRPNToInfix(m_PolishStack.ToArray());
            //calculationLabel.Text = m_sInfixString;
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

            TokenReader PolishTokenReader = new TokenReader();

            string m_CombinedInfixString = m_InfixString;
            if(m_NumberString != "")
            {
                m_CombinedInfixString += m_NumberString + ' ';
            }

            List<string> polishTokenList = m_PolishStack.ToList();
            List<string> infixStringArray = m_CombinedInfixString.Split(' ').ToList();
            infixStringArray.RemoveAll(IsEmptySpace);
            infixStringArray.RemoveAt(infixStringArray.Count - 1);

            string rpnString = ConvertInfixToRPN(infixStringArray.ToArray());
            List<string> rpnDisplayString = rpnString.Split(' ').ToList();
            rpnDisplayString.Reverse();
            //rpnDisplayString.RemoveAt(rpnDisplayString.Count - 1);
            rpnDisplayString.RemoveAt(0);

            debugBox.Text = rpnString;

            string stackRpnString = "";
            foreach (string token in polishTokenList)
            {
                stackRpnString += token + " ";
            }

            //debugBox.Text = stackRpnString + Environment.NewLine + m_sInfixString;

            ICalculationExpression resultExpression = null;
            try
            {
                resultExpression = PolishTokenReader.ReadToken(rpnDisplayString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            ResetInputString();
            BuildCalculationString();

            if (resultExpression != null)
            {
                string resultString = "Infinity?";
                try {
                    double result = resultExpression.Interpret();
                    resultString = result.ToString();
                }
                catch(NullReferenceException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                calcResultLabel.Text = resultString;
            }
            else
            {
                calcResultLabel.Text = "Error";
                //ClearCalculations();
                Console.WriteLine("Error: resultExpression is a 'null' object");
            }
        }

        private void ClearCalculations()
        {
            debugBox.Clear();
            ClearPoland();
            m_InfixString = "";
            m_sHeldOperator = "";
        }

        private void ResetInputString()
        {
            m_InputString = "0";
            calculationLabel.Text = "0";
            calcResultLabel.Text = m_InputString;
        }

        private void AddNumber(string numberText)
        {
            if (m_bFinishedCalculation)
            {
                ClearCalculations();
                m_bFinishedCalculation = false;
            }
            
            m_bHoldingOperator = false;

            AddToPolishStringNumber(numberText);
            m_bCopyCalc = true;

            UpdateResultLabel();
            CalculateAnswer();
        }

        private void ParseButton(String polishString)
        {
            ResetInputString(); // Reset the input string again
            PushNumberString();

            bool bOperatorInput = IsOperator(polishString);

            if (!(bOperatorInput && m_bHoldingOperator && (m_sHeldOperator != "(" || m_sHeldOperator != ")")))
            {
                if (polishString != "=" && polishString != "")
                {
                    m_InfixString += polishString + " ";
                }

                {
                    if (polishString == "=")
                    {
                        AddToPolishString(m_sHeldOperator);
                        m_sHeldOperator = "";
                        m_bFinishedCalculation = true;
                    }
                    else if (m_sHeldOperator == "")
                    {
                        m_bFinishedCalculation = false;
                        if (polishString != m_sHeldOperator)
                        {
                            m_sHeldOperator = polishString;
                        }
                    }
                    else
                    {
                        m_bFinishedCalculation = false;
                        if (m_bCopyCalc)
                        {
                            AddToPolishString(m_sHeldOperator);
                            m_sHeldOperator = polishString;
                            m_bCopyCalc = false;
                        }
                        else
                        {
                            m_sHeldOperator = "";
                        }
                    }
                }
            }
            else
            {
                if(m_sHeldOperator != polishString)
                {
                    int Length = m_InfixString.Length - 2;
                    if (Length > 0)
                    {
                        m_InfixString = m_InfixString.Substring(0, Length);
                        m_sHeldOperator = polishString;
                        m_InfixString += polishString + " ";
                    }
                }
            }

            m_bHoldingOperator = bOperatorInput;

            UpdateResultLabel();
            CalculateAnswer();
        }

        private void ClearEntry()
        {
            if (m_NumberString != "")
            {
                if (!m_bHoldingOperator)
                {
                    m_NumberString = "";
                    m_sHeldOperator = "";
                    m_bHoldingOperator = true;
                }
            }
            else
            {
                if (m_bHoldingOperator)
                {
                    int Length = m_InfixString.Length - 2;
                    if (Length > 0)
                    {
                        m_InfixString = m_InfixString.Substring(0, Length);
                        m_sHeldOperator = "";
                        m_bHoldingOperator = true;
                    }
                }
            }

            CalculateAnswer();
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

        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            ClearEntry();
        }

        bool m_bCopyCalc = false;
        bool m_bFinishedCalculation = false;
        bool m_bHoldingOperator = false;
        string m_sHeldOperator = "";
        private void buttonParseAndAddCalculation_Click(object sender, EventArgs e)
        {
            Button inputButton = (Button)sender;

            ParseButton(inputButton.Text);
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

            debugBox.Text = "ConvertRPNToInfix\r\nRPN: ";
            foreach (string token in inputTokens)
            {
                debugBox.Text += token + " ";
            }

            debugBox.Text += "\r\n";

            foreach (string token in inputTokens)
            {
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

            debugBox.Text += "Infix: " + outputString;

            return outputString;
        }

        private void CalculatorWindow_KeyDown(object sender, KeyEventArgs e)
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
                BuildCalculationString();
            }
            else
            {
                switch (e.KeyData)
                {
                    case Keys.Add:
                        ParseButton("+");
                        break;
                    case Keys.Subtract:
                        ParseButton("-");
                        break;
                    case Keys.Multiply:
                        ParseButton("*");
                        break;
                    case Keys.Divide:
                        ParseButton("/");
                        break;
                    case Keys.Delete:
                    case Keys.Back:
                        ClearEntry();
                        break;
                    default:
                        break;
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (((keyData & Keys.Enter) == Keys.Enter) && (this.ContainsFocus))
            {
                ParseButton("=");
                return false;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void buttomMemoryClear_Click(object sender, EventArgs e)
        {
            m_Memory = 0.0;
        }

        private void buttonMemoryAdd_Click(object sender, EventArgs e)
        {
            try
            {
                m_Memory += Double.Parse(calcResultLabel.Text);
            }
            catch (Exception) { }
        }

        private void buttonMemorySubtract_Click(object sender, EventArgs e)
        {
            try
            {
                m_Memory -= Double.Parse(calcResultLabel.Text);
            }
            catch (Exception) { }
        }

        private void buttonMemoryAssign_Click(object sender, EventArgs e)
        {
            try
            {
                m_Memory = Double.Parse(calcResultLabel.Text);
            }
            catch (Exception) { }
        }

        private void buttonMemoryRead_Click(object sender, EventArgs e)
        {
            m_NumberString = m_Memory.ToString();
            CalculateAnswer();
        }
    }
}
