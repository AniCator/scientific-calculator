using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class TokenReader
    {
        public ICalculationExpression ReadToken(List<string> tokenList)
        {
            return ReadNextToken(tokenList);
        }

        private ICalculationExpression ReadNextToken(List<string> tokenList)
        {
            double i = 0.0;
            try
            {
                if (double.TryParse(tokenList.First(), out i))
                {
                    tokenList.RemoveAt(0);
                    Console.WriteLine("Processing number: " + i);
                    return new NumberExpression(i);
                }
                else
                {
                    return ReadNonTerminal(tokenList);
                }
            }
            catch
            {
                return new NumberExpression(0);
            }
        }

        private ICalculationExpression ReadNonTerminal(List<string> tokenList)
        {
            string token = tokenList.First();
            tokenList.RemoveAt(0);
            ICalculationExpression right = ReadNextToken(tokenList);
            ICalculationExpression left = ReadNextToken(tokenList);

            Console.WriteLine("Processing token: " + token);

            if (token == "+")
                return new AddExpression(left, right);
            else if (token == "-")
                return new SubtractExpression(left, right);
            else if (token == "*")
                return new MultiplyExpression(left, right);
            else if (token == "/")
                return new DivideExpression(left, right);
            else if (token == "pow2")
                return new PowerOfTwoExpression(right);
            else if (token == "sqrt")
                return new SquareRootExpression(right);
            else if (token == "1/x")
                return new MultiplicativeInverseExpression(right);
            
            return null;
        }
    }
}
