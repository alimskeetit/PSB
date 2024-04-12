namespace Calculator;

public class Calculator: ICalculator
{
    public double Sum(double a, double b) => a + b;
    public double Subtraction(double a, double b) => a - b;
    public double Multiplication(double a, double b) => a * b;
    public double Division(double a, double b)
    {
        if (b is 0) throw new DivideByZeroException("You can't divide by zero");
        return a / b;
    }
}