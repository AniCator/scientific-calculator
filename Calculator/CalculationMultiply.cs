using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class CalculationMultiply : ICalculation
    {
        private string _dataString;

        public CalculationMultiply()
        {

        }

        public CalculationEnum GetCalculationType()
        {
            return CalculationEnum.Multiply;
        }

        public string GetDataString()
        {
            return _dataString;
        }

        public void SetDataString(string data)
        {
            _dataString = data;
        }

        public double Operate(string other)
        {
            double operation = Double.Parse(_dataString) * Double.Parse(other);
            return operation;
        }
    }
}
