using Microsoft.Extensions.Configuration;
using PowerArgs;

namespace ConsoleCalculator;
[ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
public class CalculatorArgs
{
    private readonly HttpClient _client;
    private readonly string _baseAddress;
    
    public CalculatorArgs()
    {
        _client = new HttpClient();
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        _baseAddress = config.GetRequiredSection("calculatorUrl").Value!;
    }
    
    [ArgActionMethod]
    [ArgDescription("Sums up two numbers")]
    public async Task Sum(double firstNumber, double secondNumber)
    {
        var response = await _client.GetAsync($"{_baseAddress}/sum?firstNumber={firstNumber}&secondNumber={secondNumber}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
    
    [ArgActionMethod]
    [ArgDescription("Subtracts two numbers")]
    public async Task Subtraction(double firstNumber, double secondNumber)
    {
        var response = await _client.GetAsync($"{_baseAddress}/subtraction?firstNumber={firstNumber}&secondNumber={secondNumber}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
    
    [ArgActionMethod]
    [ArgDescription("Multiplies two numbers")]
    public async Task Multiplication(double firstNumber, double secondNumber)
    {
        var response = await _client.GetAsync($"{_baseAddress}/multiplication?firstNumber={firstNumber}&secondNumber={secondNumber}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
    
    [ArgActionMethod]
    [ArgDescription("Divides two numbers")]
    public async Task Division(double firstNumber, double secondNumber)
    {
        var response = await _client.GetAsync($"{_baseAddress}/division?firstNumber={firstNumber}&secondNumber={secondNumber}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}