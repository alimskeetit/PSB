using System.Net;
using Calculator;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//di services
builder.Services.AddScoped<ICalculator, Calculator.Calculator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//exception handler middleware
app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (Exception e)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (e)
        {
            case DivideByZeroException:
                code = (HttpStatusCode)418;
                result = e.Message;
                break;
        }

        context.Response.ContentType = "application/text";
        context.Response.StatusCode = (int)code;
        
        await context.Response.WriteAsync(result);
    }
});

//routes
app.MapGet("/sum", ([FromServices] ICalculator calculator, double firstNumber, double secondNumber) => calculator.Sum(firstNumber, secondNumber));
app.MapGet("/subtraction", ([FromServices] ICalculator calculator, double firstNumber, double secondNumber) => calculator.Subtraction(firstNumber, secondNumber));
app.MapGet("/multiplication", ([FromServices] ICalculator calculator, double firstNumber, double secondNumber) => calculator.Multiplication(firstNumber, secondNumber));
app.MapGet("/division", ([FromServices] ICalculator calculator, double firstNumber, double secondNumber) => calculator.Division(firstNumber, secondNumber));

app.Run();