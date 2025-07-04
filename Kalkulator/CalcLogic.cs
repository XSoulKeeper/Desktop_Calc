namespace Kalkulator;

public class CalcLogic
{
    public decimal CalculateTwo(decimal a, decimal b, string operation)
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
            case "^": return (decimal)Math.Pow((double)a, (double)b); // Power operation
            case "sqrt":
                if (a >= 0) return (decimal)Math.Sqrt((double)a);
                else throw new ArgumentException("Cannot calculate square root of a negative number");
            // case "sin()":
            // case "cos()":
            // case "tan()":
            // case "log()":
            // case "ln()":
            // case "10^":
            // case "factorial":
            default: throw new ArgumentException($"Invalid operation: {operation}. Expected value: +,-,*,/");
                
        }
        
        return 0;
    }

    public decimal CalculateOne(decimal a, string operation)
    {
        switch (operation)
        {
            case "sqrt":
                if (a >= 0) return (decimal)Math.Sqrt((double)a);
                else throw new ArgumentException("Cannot calculate square root of a negative number");
            // case "sin()":
            // case "cos()":
            // case "tan()":
            // case "log()":
            // case "ln()":
            // case "10^":
            // case "factorial":
            default: throw new ArgumentException("Unexpected operation for single operand: " + operation);
        }
    }
    
    
}