using System.Diagnostics;

namespace PrimeNumbers;

public static class PrimeNumberCalculator
{
    public static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
    
        int maxDivisor = (int)Math.Sqrt(n) + 1;
        for (int d = 3; d < maxDivisor; d += 2)
        {
            if (n % d == 0) return false;
        }

        return true;
    }

    public static (int[] primes, double[] times) FindPrimes(int count)
    {
        int[] primes = new int[count];
        double[] times = new double[count];
        int current = 2;
        int found = 0;

        var stopwatch = new Stopwatch();

        while (found < count)
        {
            stopwatch.Restart();
            if (IsPrime(current))
            {
                stopwatch.Stop();
                primes[found] = current;
                times[found] = stopwatch.Elapsed.TotalSeconds;
                found++;
            }

            current++;
        }

        return (primes, times);
    }
    
    public static string CutTimeZero(double value)
    {
        string cutTime = value.ToString(
            "0.00000000000000000000000000000000000000000");
        cutTime = cutTime.TrimEnd('0');
        if (cutTime.EndsWith(",")) 
            cutTime = cutTime.TrimEnd(',');

        return cutTime;
    }
}