using PHY_Calc_Lib;
using System;
using Xunit;

namespace PHY_Calc_Test
{
  public class BasicOperations : IDisposable
  {
    private readonly Calculator calc;


    public BasicOperations()
    {
      calc = new Calculator();
    }

    [Theory]
    [InlineData(0, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(1, -2, -1)]
    public void CanAddToSelf(double startingNumber, double firstOperand, double answer)
    {
      calc.SetPreviousAnswer(startingNumber);
      double addedNumber = calc.Add(firstOperand);
      Assert.Equal(answer, addedNumber);
    }

    [Theory]
    [InlineData(0, 1, -1)]
    [InlineData(3, 2, 1)]
    [InlineData(3, -2, 5)]
    public void CanSubtractToSelf(double startingNumber, double firstOperand, double answer)
    {
      calc.SetPreviousAnswer(startingNumber);
      double subtractedNumber = calc.Subtract(firstOperand);
      Assert.Equal(answer, subtractedNumber);
    }

    [Theory]
    [InlineData(0, 1, 0)]
    [InlineData(3, 2, 6)]
    [InlineData(3, -2, -6)]
    public void CanMultipyToSelf(double startingNumber, double firstOperand, double answer)
    {
      calc.SetPreviousAnswer(startingNumber);
      double multipliedNumber = calc.Multiply(firstOperand);
      Assert.Equal(answer, multipliedNumber);
    }

    [Theory]
    [InlineData(5, 5, 1)]
    [InlineData(25, -5, -5)]
    [InlineData(-25, -5, 5)]
    public void CanDivideToSelf(double startingNumber, double firstOperand, double answer)
    {
      calc.SetPreviousAnswer(startingNumber);
      double multipliedNumber = calc.Divide(firstOperand);
      Assert.Equal(answer, multipliedNumber);
    }

    [Theory]
    [InlineData(5, 2, 25)]
    [InlineData(2, 4, 16)]
    public void CanPowerSelf(double startingNumber, double firstOperand, double answer)
    {
      calc.SetPreviousAnswer(startingNumber);
      double poweredNumber = calc.Power(firstOperand);
      Assert.Equal(answer, poweredNumber);
    }


    [Theory]
    [InlineData(6.2, 1.82455)]
    public void CanNaturallyLog(double startingNumber, double answer)
    {
      calc.SetPreviousAnswer(startingNumber);
      double loggedNumber = calc.NaturalLog();
      Assert.Equal(answer, loggedNumber);
    }

    [Theory]
    [InlineData(4, 2)]
    [InlineData(9, 3)]
    public void CanSquareRoot(double startingNumber, double result)
    {
      calc.SetPreviousAnswer(startingNumber);
      double root = calc.SquareRoot();
      Assert.Equal(result, root);
    }

    [Theory]
    [InlineData(4, -4)]
    [InlineData(-9, 9)]
    public void CanChangeSign(double startingNumber, double result)
    {
      calc.SetPreviousAnswer(startingNumber);
      double invertedSign = calc.ChangeSign();
      Assert.Equal(result, invertedSign);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(-9)]
    public void CanClear(double startingNumber)
    {
      calc.SetPreviousAnswer(startingNumber);
      calc.Clear();
      Assert.Equal(0, calc.GetPreviousAnswer());
    }

    [Theory]
    [InlineData(5, 4, 9)]
    public void CanRememberLastResult(double firstOperand, double secondOperand, double result)
    {
      calc.Add(firstOperand);
      calc.Add(secondOperand);
      Assert.Equal(result, calc.GetPreviousAnswer());
    }

    public void Dispose()
    {
      //TODO: Implement fully
    }
  }
}