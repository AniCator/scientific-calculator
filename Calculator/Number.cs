using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class Number : ICalculation
    {
        private string _dataString;

        public Number()
        {
            
        }

        public CalculationEnum GetCalculationType()
        {
            return CalculationEnum.Number;
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
            return Double.Parse(_dataString);
        }
    }
}
