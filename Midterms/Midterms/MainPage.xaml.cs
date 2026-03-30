using Microsoft.Maui.Controls;

namespace Midterms
{
    public partial class MainPage : ContentPage
    {
        private string _currentInput = "";
        private double _firstOperand = 0;
        private string _operator = "";
        private bool _operatorPressed = false;
        private bool _justCalculated = false;
        private bool _newEntry = true;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string digit = button.Text;

            if (_justCalculated)
            {
                _currentInput = "";
                _justCalculated = false;
                _newEntry = true;
            }

            if (_operatorPressed)
            {
                _currentInput = "";
                _operatorPressed = false;
            }

            if (_currentInput == "0" && digit == "0") return;
            if (_currentInput == "0" && digit != ".") _currentInput = "";

            _currentInput += digit;
            DisplayLabel.Text = _currentInput;
        }

        private void OnDecimalClicked(object sender, EventArgs e)
        {
            if (_justCalculated)
            {
                _currentInput = "0";
                _justCalculated = false;
            }

            if (_operatorPressed)
            {
                _currentInput = "0";
                _operatorPressed = false;
            }

            if (!_currentInput.Contains("."))
            {
                if (string.IsNullOrEmpty(_currentInput))
                    _currentInput = "0";
                _currentInput += ".";
                DisplayLabel.Text = _currentInput;
            }
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string op = button.Text;

            if (!string.IsNullOrEmpty(_currentInput))
            {
                double currentValue = double.Parse(_currentInput);

                if (!string.IsNullOrEmpty(_operator) && !_operatorPressed)
                {
                    _firstOperand = Calculate(_firstOperand, currentValue, _operator);
                    DisplayLabel.Text = FormatNumber(_firstOperand);
                }
                else
                {
                    _firstOperand = currentValue;
                }
            }

            _operator = op;
            _operatorPressed = true;
            _justCalculated = false;
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_operator) || string.IsNullOrEmpty(_currentInput))
                return;

            double secondOperand = double.Parse(_currentInput);
            double result = Calculate(_firstOperand, secondOperand, _operator);

            DisplayLabel.Text = FormatNumber(result);

            _firstOperand = result;
            _currentInput = FormatNumber(result);
            _operator = "";
            _operatorPressed = false;
            _justCalculated = true;
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            _currentInput = "";
            _firstOperand = 0;
            _operator = "";
            _operatorPressed = false;
            _justCalculated = false;
            _newEntry = true;
            DisplayLabel.Text = "0";
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_justCalculated)
            {
                OnClearClicked(sender, e);
                return;
            }

            if (_currentInput.Length > 1)
            {
                _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
                DisplayLabel.Text = _currentInput;
            }
            else
            {
                _currentInput = "";
                DisplayLabel.Text = "0";
            }
        }

        private double Calculate(double a, double b, string op)
        {
            return op switch
            {
                "+" => a + b,
                "-" => a - b,
                "x" => a * b,
                "/" => b != 0 ? a / b : 0,
                _ => b
            };
        }

        private string FormatNumber(double value)
        {
            if (value == Math.Floor(value) && !double.IsInfinity(value))
                return ((long)value).ToString();
            else
                return value.ToString("G10");
        }
    }
}