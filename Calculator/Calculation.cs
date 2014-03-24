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

    interface ICalculation
    {
        CalculationEnum GetCalculationType();
        string GetDataString();
        void SetDataString(string data);
        double Operate(string other);
    }
}
