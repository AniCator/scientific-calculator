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
            return number;
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
            return leftEx.Interpret() + rightEx.Interpret();
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
            return leftEx.Interpret() - rightEx.Interpret();
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
            return leftEx.Interpret() * rightEx.Interpret();
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
            return leftEx.Interpret() / rightEx.Interpret();
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
            return Math.Pow(ex.Interpret(),2.0);
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
            return Math.Sqrt(ex.Interpret());
        }
    }
}
