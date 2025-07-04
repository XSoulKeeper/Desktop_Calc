using System.Windows;
using System.Windows.Controls;

namespace Kalkulator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>


public partial class ProstyCalc : UserControl
{
    private double firstNumber = 0;
    private string operation = "";
    private bool isOperator = false;
    private CalcLogic calcLogic = new CalcLogic();
    
    public ProstyCalc()
    {
        InitializeComponent();
        Display.Text = "0";
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        string buttonContent = button.Content.ToString();

        if (double.TryParse(buttonContent, out _) || buttonContent == ".")
        {
            if (isOperator || Display.Text == "0")
                Display.Text = buttonContent;
            else
               Display.Text += buttonContent;
            isOperator = false;
        }
        else if ("+-*/".Contains(buttonContent))
        {
            firstNumber = double.Parse(Display.Text);
            operation = buttonContent;
            isOperator = true;

        }
    }

    private void Equals_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            double secondNumber = double.Parse(Display.Text);
            double result = calcLogic.Calculate(firstNumber, secondNumber, operation);
            Display.Text = result.ToString();
            isOperator = true;
        }
        catch (DivideByZeroException ex)
        {
            Display.Text = ex.Message;
            isOperator = true;
        }
        catch (ArgumentException ex)
        {
            Display.Text = ex.Message;
            isOperator = true;
        }
        catch
        {
            Display.Text = "Unexpected error";
            isOperator = true;
        }
    }
    
    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        Display.Text = "0";
        firstNumber = 0;
        operation = "";
        isOperator = false;
    }
    
}