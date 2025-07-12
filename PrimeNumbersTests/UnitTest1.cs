using PrimeNumbers;

namespace PrimeNumbersTests;

public class PrimeNumberCalculatorTests
{
    [Theory]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(5, true)]
    [InlineData(7, true)]
    [InlineData(11, true)]
    [InlineData(13, true)]
    [InlineData(1, false)]
    [InlineData(4, false)]
    [InlineData(6, false)]
    [InlineData(8, false)]
    [InlineData(9, false)]
    [InlineData(10, false)]
    [InlineData(-1, false)]
    [InlineData(0, false)]
    public void IsPrime_ReturnsCorrectResult(int number, bool expected)
    {
        var result = PrimeNumberCalculator.IsPrime(number);

        Assert.Equal(expected, result);
    }
}