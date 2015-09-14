using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class NumberExpression : ICalculationExpression
    {
        private double number;

        public NumberExpression(double number)
        {
            this.number = number;
        }

        double ICalculationExpression.Interpret()
        {
            double result = number;

            return result;
        }
    }

    class AddExpression : ICalculationExpression
    {
        private ICalculationExpression leftEx;
        private ICalculationExpression rightEx;

        public AddExpression(ICalculationExpression left, ICalculationExpression right)
        {
            this.leftEx = left;
            this.rightEx = right;
        }

        double ICalculationExpression.Interpret()
        {
            double result = leftEx.Interpret() + rightEx.Interpret();
#if DEBUG
            Console.WriteLine("AddExpression: " + result);
#endif
            return result;
        }
    }

    class SubtractExpression : ICalculationExpression
    {
        private ICalculationExpression leftEx;
        private ICalculationExpression rightEx;

        public SubtractExpression(ICalculationExpression left, ICalculationExpression right)
        {
            this.leftEx = left;
            this.rightEx = right;
        }

        double ICalculationExpression.Interpret()
        {
            double result = leftEx.Interpret() - rightEx.Interpret();
#if DEBUG
            Console.WriteLine("SubtractExpression: " + result);
#endif
            return result;
        }
    }

    class MultiplyExpression : ICalculationExpression
    {
        private ICalculationExpression leftEx;
        private ICalculationExpression rightEx;

        public MultiplyExpression(ICalculationExpression left, ICalculationExpression right)
        {
            this.leftEx = left;
            this.rightEx = right;
        }

        double ICalculationExpression.Interpret()
        {
            double result = leftEx.Interpret() * rightEx.Interpret();
#if DEBUG
            Console.WriteLine("MultiplyExpression: " + result);
#endif
            return result;
        }
    }

    class DivideExpression : ICalculationExpression
    {
        private ICalculationExpression leftEx;
        private ICalculationExpression rightEx;

        public DivideExpression(ICalculationExpression left, ICalculationExpression right)
        {
            this.leftEx = left;
            this.rightEx = right;
        }

        double ICalculationExpression.Interpret()
        {
            double result = leftEx.Interpret() / rightEx.Interpret();
#if DEBUG
            Console.WriteLine("DivideExpression: " + result);
#endif
            return result;
        }
    }

    class PowerOfTwoExpression : ICalculationExpression
    {
        private ICalculationExpression ex;

        public PowerOfTwoExpression(ICalculationExpression expr)
        {
            this.ex = expr;
        }

        double ICalculationExpression.Interpret()
        {
            double result = Math.Pow(ex.Interpret(),2.0);
#if DEBUG
            Console.WriteLine("PowerOfTwoExpression: " + result);
#endif
            return result;
        }
    }

    class SquareRootExpression : ICalculationExpression
    {
        private ICalculationExpression ex;

        public SquareRootExpression(ICalculationExpression expr)
        {
            this.ex = expr;
        }

        double ICalculationExpression.Interpret()
        {
            double result = Math.Sqrt(ex.Interpret());
#if DEBUG
            Console.WriteLine("SquareRootExpression: " + result);
#endif
            return result;
        }
    }

    class MultiplicativeInverseExpression : ICalculationExpression
    {
        private ICalculationExpression ex;

        public MultiplicativeInverseExpression(ICalculationExpression expr)
        {
            this.ex = expr;
        }

        double ICalculationExpression.Interpret()
        {
            double result = 1 / ex.Interpret();
#if DEBUG
            Console.WriteLine("MultiplicativeInverseExpression: " + result);
#endif
            return result;
        }
    }
}
