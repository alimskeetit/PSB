using System.Globalization;
using Microsoft.Extensions.Configuration;
using PowerArgs;
using System.Globalization;

namespace ConsoleCalculator;

[ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
public class CalculatorArgs
{
    private readonly HttpClient _client;
    
    public CalculatorArgs()
    {
       
        _client = new HttpClient();
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        _client.BaseAddress = new Uri(config.GetRequiredSection("calculatorUrl").Value!);
    }
    
    [ArgActionMethod]
    [ArgDescription("Sums up two numbers")]
    public async Task Sum(double firstNumber, double secondNumber)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        var response = await _client.GetAsync($"sum?firstNumber={firstNumber}&secondNumber={secondNumber}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
    
    [ArgActionMethod]
    [ArgDescription("Subtracts two numbers")]
    public async Task Subtraction(double firstNumber, double secondNumber)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        var response = await _client.GetAsync($"subtraction?firstNumber={firstNumber}&secondNumber={secondNumber}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
    
    [ArgActionMethod]
    [ArgDescription("Multiplies two numbers")]
    public async Task Multiplication(double firstNumber, double secondNumber)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        var response = await _client.GetAsync($"multiplication?firstNumber={firstNumber}&secondNumber={secondNumber}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
    
    [ArgActionMethod]
    [ArgDescription("Divides two numbers")]
    public async Task Division(double firstNumber, double secondNumber)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        var response = await _client.GetAsync($"division?firstNumber={firstNumber}&secondNumber={secondNumber}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}