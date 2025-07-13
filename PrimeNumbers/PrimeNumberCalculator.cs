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

    public static Dictionary<int, double> FindPrimes(int count)
    {
        Dictionary<int, double> primesTimes = new Dictionary<int, double>();
        int current = 2;
        int found = 0;

        var stopwatch = new Stopwatch();

        while (found < count)
        {
            stopwatch.Restart();
            if (IsPrime(current))
            {
                stopwatch.Stop();
                primesTimes.Add(current, (stopwatch.ElapsedTicks * 1_000_000_000.0) / Stopwatch.Frequency);
                found++;
            }

            current++;
        }

        return primesTimes;
    }
}