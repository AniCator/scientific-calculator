using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    enum CalculationEnum
    {
        Number,
        Add,
        Multiply
    }

    struct CalcOp
    {
        string  op;
        int     no;
    }

    interface ICalculationExpression
    {
        double Interpret();
    }
}
