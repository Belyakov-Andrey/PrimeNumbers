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

    [Theory]
    [InlineData(1, new[] { 2 })]
    [InlineData(5, new[] { 2, 3, 5, 7, 11 })]
    [InlineData(10, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 })]
    public void FindPrimes_ReturnsCorrectPrimes(int count, int[] expectedPrimes)
    {
        var (primes, times) = PrimeNumberCalculator.FindPrimes(count);

        Assert.Equal(expectedPrimes, primes);
    }

    [Theory]
    [InlineData(0.000000000123456789, "0,000000000123456789")]
    [InlineData(1.23456789000000000, "1,23456789")]
    [InlineData(0.00000000000000000, "0")]
    [InlineData(1.00000000000000000, "1")]
    [InlineData(123.456000000000000, "123,456")]
    public void CutTimeZero_CorrectString(double value, string expected)
    {
        var result = PrimeNumberCalculator.CutTimeZero(value);

        Assert.Equal(expected, result);
    }
}