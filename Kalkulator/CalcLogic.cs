namespace Kalkulator;

public class CalcLogic
{
    public double Calculate(double a, double b, string operation)
    {

        switch (operation)
        {
            case "+": return a + b; //addition
            case "-": return a - b; //substracion
            case "*": return a * b; //multiplication
            case "/":
                if (b != 0) return a / b;
                else throw new DivideByZeroException("Cannot divide by zero");
            case "%": return a % b; // Modulo operation
            case "^": return Math.Pow(a, b); // Power operation
            case "sqrt":
            case "sin()":
            case "cos()":
            case "tan()":
            case "log()":
            case "ln()":
            case "10^":
            case "factorial":
            default: throw new ArgumentException($"Invalid operation: {operation}. Expected value: +,-,*,/");
                
        }
        
        return 0;
    }
    
    
}