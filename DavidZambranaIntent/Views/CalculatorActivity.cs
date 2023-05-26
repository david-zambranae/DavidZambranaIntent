
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Text;

namespace DavidZambranaIntent.Views
{
    [Activity(Label = "Calculadora")]
    public class CalculatorActivity : AppCompatActivity
    {
        private TextView operationTextView;
        private TextView resultTextView;

        private StringBuilder currentNumber;
        private double operand1;
        private double operand2;
        private char @operator;
        private bool calculationDone;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_calculator);

            operationTextView = FindViewById<TextView>(Resource.Id.operation);
            resultTextView = FindViewById<TextView>(Resource.Id.result);

            currentNumber = new StringBuilder();
            calculationDone = false;

            Button clearButton = FindViewById<Button>(Resource.Id.clear);
            Button divisionButton = FindViewById<Button>(Resource.Id.division);
            Button multiplicationButton = FindViewById<Button>(Resource.Id.multiplication);
            Button deleteButton = FindViewById<Button>(Resource.Id.delete);
            Button sevenButton = FindViewById<Button>(Resource.Id.seven);
            Button eightButton = FindViewById<Button>(Resource.Id.eight);
            Button subtractionButton = FindViewById<Button>(Resource.Id.substraction);
            Button fourButton = FindViewById<Button>(Resource.Id.four);
            Button nineButton = FindViewById<Button>(Resource.Id.nine);
            Button fiveButton = FindViewById<Button>(Resource.Id.five);
            Button sixButton = FindViewById<Button>(Resource.Id.six);
            Button additionButton = FindViewById<Button>(Resource.Id.addition);
            Button oneButton = FindViewById<Button>(Resource.Id.one);
            Button twoButton = FindViewById<Button>(Resource.Id.two);
            Button threeButton = FindViewById<Button>(Resource.Id.three);
            Button equalButton = FindViewById<Button>(Resource.Id.equal);
            Button zeroButton = FindViewById<Button>(Resource.Id.zero);
            Button dotButton = FindViewById<Button>(Resource.Id.dot);


            clearButton.Click += ClearButton_Click;
            divisionButton.Click += DivisionButton_Click;
            multiplicationButton.Click += MultiplicationButton_Click;
            deleteButton.Click += DeleteButton_Click;
            sevenButton.Click += SevenButton_Click;
            eightButton.Click += EightButton_Click;
            nineButton.Click += NineButton_Click;
            subtractionButton.Click += SubtractionButton_Click;
            fourButton.Click += FourButton_Click;
            fiveButton.Click += FiveButton_Click;
            sixButton.Click += SixButton_Click;
            additionButton.Click += AdditionButton_Click;
            oneButton.Click += OneButton_Click;
            twoButton.Click += TwoButton_Click;
            threeButton.Click += ThreeButton_Click;
            equalButton.Click += EqualButton_Click;
            zeroButton.Click += ZeroButton_Click;
            dotButton.Click += DotButton_Click;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearCalculator();
        }

        private void DivisionButton_Click(object sender, EventArgs e)
        {
            SetOperator('/');
        }

        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            SetOperator('*');
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteCharacter();
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            AppendToExpression("7");
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            AppendToExpression("8");
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            AppendToExpression("9");
        }

        private void SubtractionButton_Click(object sender, EventArgs e)
        {
            SetOperator('-');
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            AppendToExpression("4");
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            AppendToExpression("5");
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            AppendToExpression("6");
        }

        private void AdditionButton_Click(object sender, EventArgs e)
        {
            SetOperator('+');
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            AppendToExpression("1");
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            AppendToExpression("2");
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            AppendToExpression("3");
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            PerformCalculation();
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            AppendToExpression("0");
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            AppendToExpression(".");
        }

        private void AppendToExpression(string value)
        {
            if (calculationDone)
            {
                ClearCalculator();
                calculationDone = false;
            }

            currentNumber.Append(value);
            operationTextView.Text = currentNumber.ToString();
        }

        private void ClearCalculator()
        {
            currentNumber.Clear();
            operand1 = 0;
            operand2 = 0;
            @operator = '\0';
            operationTextView.Text = "";
            resultTextView.Text = "";
        }

        private void DeleteCharacter()
        {
            if (currentNumber.Length > 0)
            {
                currentNumber.Length--;
                operationTextView.Text = currentNumber.ToString();
            }
        }

        private void SetOperator(char newOperator)
        {
            if (currentNumber.Length > 0)
            {
                operand1 = double.Parse(currentNumber.ToString());
                currentNumber.Clear();
                @operator = newOperator;
                operationTextView.Text = operand1.ToString() + " " + @operator;
            }
        }

        private void PerformCalculation()
        {
            if (currentNumber.Length > 0 && @operator != '\0')
            {
                operand2 = double.Parse(currentNumber.ToString());

                double result = 0;

                switch (@operator)
                {
                    case '+':
                        result = operand1 + operand2;
                        break;
                    case '-':
                        result = operand1 - operand2;
                        break;
                    case '*':
                        result = operand1 * operand2;
                        break;
                    case '/':
                        if (operand2 != 0)
                        {
                            result = operand1 / operand2;
                        }
                        else
                        {
                            Toast.MakeText(this, "No se puede dividir entre cero", ToastLength.Short).Show();
                            ClearCalculator();
                            return;
                        }
                        break;
                }

                resultTextView.Text = result.ToString();
                calculationDone = true;
            }
        }
    }
}