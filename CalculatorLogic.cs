using System.Data;

namespace CalculatorApp.Logic
{
    public class CalculatorLogic
    {
        private string _currentState = "0";
        private string _currentOperator = "";
        private double _firstOperand = 0;
        private bool _isOperatorClicked = false;
        private bool _isResultCalculated = false;

        public string DisplayValue => _currentState;

        public void InputDigit(string digit)
        {
            if (_isResultCalculated)
            {
                ClearAll();
            }

            if (_currentState == "0" && digit != ".")
            {
                _currentState = "";
            }

            if (digit == "." && _currentState.Contains("."))
            {
                return;
            }

            _currentState += digit;
            _isOperatorClicked = false;
        }

        public void InputOperator(string op)
        {
            if (_isOperatorClicked)
            {
                _currentOperator = op;
                return;
            }

            if (!string.IsNullOrEmpty(_currentOperator))
            {
                CalculateResult();
            }

            _firstOperand = double.Parse(_currentState);
            _currentOperator = op;
            _currentState = "0";
            _isOperatorClicked = true;
            _isResultCalculated = false;
        }

        public void PerformUnaryOperation(string op)
        {
            double number = double.Parse(_currentState);
            double result = 0;

            switch (op)
            {
                case "√x":
                    result = Math.Sqrt(number);
                    break;
                case "x²":
                    result = Math.Pow(number, 2);
                    break;
                case "1/x":
                    result = 1 / number;
                    break;
                case "±":
                    result = -number;
                    break;
                case "log":
                    result = Math.Log10(number);
                    break;
                case "ln":
                    result = Math.Log(number);
                    break;
                case "10^x":
                    result = Math.Pow(10, number);
                    break;
                case "n!":
                    result = Factorial((int)number);
                    break;
            }
            _currentState = result.ToString();
        }

        public void InputConstant(string constant)
        {
            if (_isResultCalculated)
            {
                ClearAll();
            }
            switch (constant)
            {
                case "π":
                    _currentState = Math.PI.ToString();
                    break;
                case "e":
                    _currentState = Math.E.ToString();
                    break;
            }
            _isResultCalculated = false;
        }

        public void CalculateResult()
        {
            if (string.IsNullOrEmpty(_currentOperator) || _isOperatorClicked)
                return;

            double secondOperand = double.Parse(_currentState);
            double result = 0;

            switch (_currentOperator)
            {
                case "+": result = _firstOperand + secondOperand; break;
                case "−": result = _firstOperand - secondOperand; break;
                case "×": result = _firstOperand * secondOperand; break;
                case "÷": result = _firstOperand / secondOperand; break;
                case "Mod": result = _firstOperand % secondOperand; break;
                case "x^y": result = Math.Pow(_firstOperand, secondOperand); break;
                case "y√x": result = Math.Pow(_firstOperand, 1.0 / secondOperand); break;
            }

            _currentState = result.ToString();
            _currentOperator = "";
            _isResultCalculated = true;
        }

        public void ClearEntry()
        {
            _currentState = "0";
        }

        public void ClearAll()
        {
            _currentState = "0";
            _currentOperator = "";
            _firstOperand = 0;
            _isOperatorClicked = false;
            _isResultCalculated = false;
        }

        public void Backspace()
        {
            if (_isResultCalculated)
            {
                ClearAll();
                return;
            }

            if (_currentState.Length > 1)
            {
                _currentState = _currentState.Substring(0, _currentState.Length - 1);
            }
            else
            {
                _currentState = "0";
            }
        }

        private double Factorial(int n)
        {
            if (n < 0) return double.NaN; // Factorial is not defined for negative numbers
            if (n == 0) return 1;
            double result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}