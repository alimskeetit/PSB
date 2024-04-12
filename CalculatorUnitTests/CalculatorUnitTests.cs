using System.Runtime.CompilerServices;
using Calculator;
using Microsoft.VisualBasic;

namespace CalculatorUnitTests;

public class CalculatorUnitTests
{
    private readonly ICalculator _calculator;

    public CalculatorUnitTests()
    {
        _calculator = new Calculator.Calculator();
    }
    
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(1, -1, 0)]
    [InlineData(-1, -1, -2)]
    [InlineData(0.25, -1, -0.75)]
    public void Sum_TwoNumbers_ShouldReturn_ExpectedSum(double firstNumber, double secondNumber, double expectedSum)
    {
        //Act
        var actualSum = _calculator.Sum(firstNumber, secondNumber);
        //Assert
        Assert.Equal(expectedSum, actualSum);
    }
    
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(0, -1, 1)]
    [InlineData(-1, -1, 0)]
    [InlineData(1, 1, 0)]
    [InlineData(1, 0.25, 0.75)]
    public void Subtraction_TwoNumbers_ShouldReturn_ExpectedSubtraction(double firstNumber, double secondNumber, double expectedSubtraction)
    {
        //Act
        var actualSubtraction = _calculator.Subtraction(firstNumber, secondNumber);
        //Assert
        Assert.Equal(expectedSubtraction, actualSubtraction);
    }
    
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 0)]
    [InlineData(0, -1, 0)]
    [InlineData(-1, -1, 1)]
    [InlineData(1, 1, 1)]
    [InlineData(1, 0.25, 0.25)]
    public void Multiplication_TwoNumbers_ShouldReturn_ExpectedMultiplication(double firstNumber, double secondNumber, double expectedMultiplication)
    {
        //Act
        var actualMultiplication = _calculator.Multiplication(firstNumber, secondNumber);
        //Assert
        Assert.Equal(expectedMultiplication, actualMultiplication);
    }
    
    [Theory]
    [InlineData(0, 1, 0)]
    [InlineData(0, -1, 0)]
    [InlineData(-1, -1, 1)]
    [InlineData(1, 1, 1)]
    [InlineData(1, 0.25, 4)]
    public void Division_TwoNumbers_ShouldReturn_ExpectedDivision(double firstNumber, double secondNumber, double expectedDivision)
    {
        //Act
        var actualDivision = _calculator.Division(firstNumber, secondNumber);
        //Assert
        Assert.Equal(expectedDivision, actualDivision);
    }

    [Fact]
    public void Division_ByZero_ShouldThrow_DivideByZeroException()
    {
        var ex = Assert.Throws<DivideByZeroException>(() => _calculator.Division(default, 0));
        Assert.Equal("You can't divide by zero", ex.Message);
    }
}