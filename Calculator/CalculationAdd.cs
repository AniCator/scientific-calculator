using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class CalculationAdd : ICalculation
    {
        private string _dataString;

        public CalculationAdd()
        {
            
        }

        public CalculationEnum GetCalculationType()
        {
            return CalculationEnum.Add;
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
            double operation = Double.Parse(_dataString) + Double.Parse(other);
            return operation;
        }
    }
}
