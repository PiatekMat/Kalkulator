using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkkulator
{
    public partial class MainWindow : Window{
        private Stack<double> stack;
        double operand2 = 0;
        double operand1 = 0;
        string buttonText;
        string operation = "";
        bool operand = false;
        bool both = false;

        public MainWindow()
        {
            InitializeComponent();
            stack = new Stack<double>();
        }
        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Display.Text += button.Content.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            buttonText = button.Content.ToString();
            double result = 0;
            

            if (!operand){
                stack.Push(double.Parse(Display.Text));
                operand = true;
            }else{
                stack.Push(Double.Parse(Display.Text));
                both = true;
            }

            if (buttonText == "+" || buttonText == "-" || buttonText == "*" || buttonText == "/"){
                operation = buttonText;
                Display.Text = "";

            }


            if (buttonText == "Enter")
            {
                operand2 = stack.Pop();
                operand1 = stack.Pop();
                result = Operations(operation);
                stack.Clear();
                stack.Push(result);

                Display.Text = result.ToString();
                both = false;
                }
            }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Display.Text = "";
            operand1 = 0;
            operand2 = 0;
            stack.Clear();
            both= false;
            operand = false;
        }

        double Operations(string operation)
        {
            switch (operation)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    {
                        if (operand2 == 0)
                        {
                            MessageBox.Show("Nie można dzielić przez 0");
                            return 0;
                        }else 
                            return operand1 / operand2;
                    }
                    
                default: return 0;
            }
        }
    }
}

