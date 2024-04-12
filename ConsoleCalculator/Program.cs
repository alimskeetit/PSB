using ConsoleCalculator;
using PowerArgs;

try
{
    Args.InvokeAction<CalculatorArgs>(args);
}
catch (AggregateException e)
{
    Console.WriteLine(e.Message);
}
