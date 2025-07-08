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
            case "^": 
                double result = Math.Pow((double)a, (double)b);
                if (double.IsInfinity(result) || double.IsNaN(result) || result > (double)decimal.MaxValue || result < (double)decimal.MinValue)
                    throw new ArgumentException("Wynik poza zakresem!");
                return (decimal)result; // Power operation

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
            case "sin()":
                return (decimal)Math.Sin((double)a);
            case "cos()":
                return (decimal)Math.Cos((double)a);
            case "tan()":
                return (decimal)Math.Tan((double)a);
            case "log()":
                if (a > 0) return (decimal)Math.Log10((double)a);
                else throw new ArgumentException("Cannot calculate log10 of a non-positive number");
            case "ln()":
                if (Math.Abs((double)a-Math.E) < 1e-10) return 1; // Special case for ln(e)
                else if (a > 0) return (decimal)Math.Log((double)a);
                else throw new ArgumentException("Cannot calculate ln of a non-positive number"); 
            case "10^":
                return (decimal)Math.Pow(10,(double)a);
            case "x^2": return a * a;
            case "factorial":
                if (a != 0) return 1 / a;
                else throw new DivideByZeroException("Cannot calculate factorial of zero");
            default: throw new ArgumentException("Unexpected operation for single operand: " + operation);
        }
    }

    public decimal ConstVal(string operation)
    {
        switch (operation)
        {
            case "pi": return (decimal)Math.PI; // Pi constant
            case "e": return (decimal)Math.E; // Euler's number constant
            default: throw new ArgumentException("Unexpected constant: " + operation);
        }
    }
    
    
}