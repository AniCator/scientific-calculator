using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    abstract class CalculationExpression : ICalculationExpression
    {
        protected ICalculationExpression leftEx;
        protected ICalculationExpression rightEx;

        abstract public double Interpret();
    }

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

    class AddExpression : CalculationExpression
    {
        public AddExpression(ICalculationExpression left, ICalculationExpression right)
        {
            this.leftEx = left;
            this.rightEx = right;
        }

        public override double Interpret()
        {
            double result = leftEx.Interpret() + rightEx.Interpret();

            return result;
        }
    }

    class SubtractExpression : CalculationExpression
    {
        public SubtractExpression(ICalculationExpression left, ICalculationExpression right)
        {
            this.leftEx = left;
            this.rightEx = right;
        }

        public override double Interpret()
        {
            double result = 0;
            result = leftEx.Interpret() - rightEx.Interpret();

            return result;
        }
    }

    class MultiplyExpression : CalculationExpression
    {
        public MultiplyExpression(ICalculationExpression left, ICalculationExpression right)
        {
            this.leftEx = left;
            this.rightEx = right;
        }

        public override double Interpret()
        {
            double result = leftEx.Interpret() * rightEx.Interpret();

            return result;
        }
    }

    class DivideExpression : CalculationExpression
    {
        public DivideExpression(ICalculationExpression left, ICalculationExpression right)
        {
            this.leftEx = left;
            this.rightEx = right;
        }

        public override double Interpret()
        {
            double result = leftEx.Interpret() / rightEx.Interpret();

            return result;
        }
    }

    class PowerOfTwoExpression : CalculationExpression
    {
        public PowerOfTwoExpression(ICalculationExpression expr)
        {
            this.rightEx = expr;
        }

        public override double Interpret()
        {
            double result = Math.Pow(rightEx.Interpret(),2.0);

            return result;
        }
    }

    class SquareRootExpression : CalculationExpression
    {
        public SquareRootExpression(ICalculationExpression expr)
        {
            this.rightEx = expr;
        }

        public override double Interpret()
        {
            double result = Math.Sqrt(rightEx.Interpret());

            return result;
        }
    }

    class MultiplicativeInverseExpression : CalculationExpression
    {
        public MultiplicativeInverseExpression(ICalculationExpression expr)
        {
            this.rightEx = expr;
        }

        public override double Interpret()
        {
            double result = 1 / rightEx.Interpret();

            return result;
        }
    }
}
