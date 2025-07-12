using PrimeNumbers;

Console.WriteLine("Программа для вычисления простых чисел");

try
{
    Console.Write("Введите количество простых чисел для вычисления: ");
    int count = int.Parse(Console.ReadLine());

    if (count <= 0)
    {
        Console.WriteLine("Число должно быть положительным.");
        return;
    }
    
    var (primes, times) = PrimeNumberCalculator.FindPrimes(count);
    
    for (int i = 0; i < primes.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {primes[i]} (время: {PrimeNumberCalculator.CutTimeZero(times[i])} сек)");
    }

    double totalTime = 0;
    foreach (var t in times) totalTime += t;
    double avgTime = totalTime / count;

    Console.WriteLine("\nИтоговая статистика:");
    Console.WriteLine($"Суммарное время: {PrimeNumberCalculator.CutTimeZero(totalTime)} сек");
    Console.WriteLine($"Среднее время: {PrimeNumberCalculator.CutTimeZero(avgTime)} сек");
}
catch (Exception)
{
    Console.WriteLine("Введите целое положительное число.");
}
