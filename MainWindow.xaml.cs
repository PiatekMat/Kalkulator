using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Kalkkulator
{
    /// <summary>
    /// Główne okno kalkulatora.
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stack<double> stack;
        double operand2 = 0;
        double operand1 = 0;
        string buttonText;
        string operation = "";
        bool operand = false;
        bool both = false;

        /// <summary>
        /// Konstruktor klasy MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            stack = new Stack<double>();
        }

        /// <summary>
        /// Obsługuje kliknięcie przycisku cyfry.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Argumenty zdarzenia.</param>
        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Display.Text += button.Content.ToString();
        }

        /// <summary>
        /// Obsługuje kliknięcie przycisku operacji arytmetycznej.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Argumenty zdarzenia.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            buttonText = button.Content.ToString();
            double result = 0;

            if (!operand)
            {
                stack.Push(double.Parse(Display.Text));
                operand = true;
            }
            else
            {
                stack.Push(Double.Parse(Display.Text));
                both = true;
            }

            if (buttonText == "+" || buttonText == "-" || buttonText == "*" || buttonText == "/")
            {
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

        /// <summary>
        /// Obsługuje kliknięcie przycisku "Clear".
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie.</param>
        /// <param name="e">Argumenty zdarzenia.</param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            Display.Text = "";
            operand1 = 0;
            operand2 = 0;
            stack.Clear();
            both = false;
            operand = false;
        }

        /// <summary>
        /// Wykonuje operację arytmetyczną na dwóch operandach.
        /// </summary>
        /// <param name="operation">Operator arytmetyczny.</param>
        /// <returns>Wynik operacji.</returns>
        private double Operations(string operation)
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
                        }
                        else
                            return operand1 / operand2;
                    }
                default:
                    return 0;
            }
        }
    }
}
