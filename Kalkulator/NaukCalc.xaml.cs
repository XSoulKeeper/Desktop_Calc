using System.Windows;
using System.Windows.Controls;
using System.Media;
namespace Kalkulator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>


public partial class NaukCalc : UserControl
{
    private decimal firstNumber = 0;
    private string operation = "";
    private bool isOperator = false, isSecondNumberInput = false, isConstInput = false;
    private CalcLogic calcLogic = new CalcLogic();
    
    public NaukCalc()
    {
        InitializeComponent();
        Display.Text = "0";
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        string buttonContent = button.Content?.ToString() ?? "";
        string buttonTag = button.Tag?.ToString() ?? "";

        // Obsługa wprowadzania cyfr i kropki dziesiętnej
        if (double.TryParse(buttonContent, out _) || buttonContent == ",")
        {
            if (buttonContent == ",")
            {
                if (Display.Text.Contains(","))
                {
                    return;
                }
            }

            if (isOperator || Display.Text == "0" || isConstInput)
            {
                Display.Text = buttonContent;
                isOperator = false;
                isConstInput = false;
            }
            else
            {
                Display.Text += buttonContent;
            }
            isSecondNumberInput = !string.IsNullOrEmpty(operation);
        }
        
        //Obsługa +/-
        else if (buttonTag == "swap" || buttonContent == "+/-")
        {
            try
            {
                decimal number = decimal.Parse(Display.Text);
                number = -number;
                Display.Text = number.ToString();
            }
            catch
            {
                Display.Text = "Error: Invalid number format";
            }
        }
        
        // Obsługa operatorów binarnych (+, -, *, /)
        else if ("+-*/%^".Contains(buttonContent))
        {
            if (!string.IsNullOrEmpty(operation) && !isOperator && isSecondNumberInput)
            {
                try
                {
                    // Użyje domyślnej kultury (ustawionej globalnie na InvariantCulture)
                    decimal secondNumber = decimal.Parse(Display.Text);
                    firstNumber = calcLogic.CalculateTwo(firstNumber, secondNumber, operation);
                    // Użyje domyślnej kultury (ustawionej globalnie na InvariantCulture)
                    Display.Text = firstNumber.ToString();
                }
                catch (Exception ex)
                {
                    Display.Text = ex.Message;
                    firstNumber = 0;
                }
            }
            else
            {
                // Użyje domyślnej kultury (ustawionej globalnie na InvariantCulture)
                firstNumber = decimal.Parse(Display.Text);
            }

            operation = buttonContent;
            isOperator = true;
            isSecondNumberInput = false;
        }
        
        // Obsługa operacji unarnych (np. pierwiastek kwadratowy)
        else if ("sqrt, sin(), cos(), tan(), log(), ln(), 10^, x^2, factorial".Contains(buttonTag))
        {
            if (isOperator && !isSecondNumberInput)
            {
                Display.Text = "0"; // Reset display if operator was pressed before
            }

            try
            {
                decimal currentNumber = decimal.Parse(Display.Text);
                decimal result = calcLogic.CalculateOne(currentNumber, buttonTag);
                Display.Text = result.ToString();
                isOperator = true;
                isSecondNumberInput = false;
            }
            catch (ArgumentException ex)
            {
                Display.Text = ex.Message;
                isOperator = true;
                isSecondNumberInput = false;
            }
            catch (DivideByZeroException ex)
            {
                Display.Text = ex.Message;
                isOperator = true;
                isSecondNumberInput = false;
            }
            catch (FormatException)
            {
                Display.Text = "Error: Invalid number format.";
                isOperator = true;
                isSecondNumberInput = false;
            }
        }
        
        // Obsługa stałych liczbowych (np. pi, e)
        else if (buttonTag == "pi" || buttonTag == "e")
        {
            Display.Text = calcLogic.ConstVal(buttonTag).ToString();
            
            isOperator = false;
            isSecondNumberInput = !string.IsNullOrEmpty(operation);
            isConstInput = true;
        }
        
        //Funckje trygonometryczne
        else if ("Functions".Contains(buttonTag)) TryFunc.IsOpen= true;
        
    }

    private void Equals_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(operation))
        {
            Display.Text = Display.Text;
            isOperator = false;
            MainWindow.soundManager.PlaySound(SoundType.EqualsButtonSound);
            return;
        }
        try
        {
            decimal secondNumber = decimal.Parse(Display.Text);
            decimal result = calcLogic.CalculateTwo(firstNumber, secondNumber, operation);
            Display.Text = result.ToString();
            isOperator = true;
            MainWindow.soundManager.PlaySound(SoundType.EqualsButtonSound);
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
        MainWindow.soundManager.PlaySound(SoundType.ClearButtonSound);
    }
    
    }