using System;
using System.Collections.Generic;
using System.Text;

namespace PHY_Calc_Lib
{
  /// <summary>
  /// A standard calculator that performs 
  /// basic addition, subtraction, multiplication, division, square roots
  /// and natural logarithms. 
  /// </summary>
  public class Calculator
  {
    private double PreviousAnswer = 0;

    public double Add(double newNumber)
    {
      PreviousAnswer += newNumber;
      return PreviousAnswer;
    }

    public double Subtract(double newNumber)
    {
      PreviousAnswer -= newNumber;
      return PreviousAnswer;
    }

    public void SetPreviousAnswer(double number)
    {
      PreviousAnswer = number;
    }

    public double Multiply(double newNumber)
    {
      return PreviousAnswer *= newNumber;
    }

    public double Divide(double newNumber)
    {
      return PreviousAnswer /= newNumber;
    }

    public double ChangeSign()
    {
      PreviousAnswer *= -1;
      return PreviousAnswer;
    }

    public double Power(double amountToPowerBy)
    {
      PreviousAnswer = Math.Pow(PreviousAnswer, amountToPowerBy);
      return PreviousAnswer;
    }

    /// <summary>
    /// Takes the natural logarithm, base e , of
    /// the currently stored number.
    /// </summary>
    /// <returns>the natural log of the currently stored number
    /// rounded to 5 decimal places</returns>
    public double NaturalLog()
    {
      PreviousAnswer = Math.Round(Math.Log(PreviousAnswer), 5);
      return PreviousAnswer;
    }

    public double SquareRoot()
    {
      double number = PreviousAnswer;
      float precision = 0.0001f; // We only care to the thousandth's position; must be one decimal point larger than our rounding
      double min = 0;
      double max = number;
      double result = 0;
      while (max - min > precision) // While we haven't reached the precision yet
      {
        result = (min + max) / 2; // Add the min and maximum ranges together and go halfway
        if ((result * result) >= number) // Multiply our last result by itself 
        {
          max = result; //The number we want is smaller than that
        }
        else
        {
          min = result; // The number we want is bigger than the last result
        }
      }
      PreviousAnswer = Math.Round(result, 3); // Round to the nearest thousandth
      return PreviousAnswer;
    }

    public double GetPreviousAnswer()
    {
      return PreviousAnswer;
    }

    public void Clear()
    {
      PreviousAnswer = 0;
    }

  }
}
