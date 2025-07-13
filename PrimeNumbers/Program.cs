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

    Dictionary<int, double> primesTimes = new Dictionary<int, double>();
    primesTimes = PrimeNumberCalculator.FindPrimes(count);

    ResultMenu.Menu(primesTimes, count);
}
catch (Exception)
{
    Console.WriteLine("Введите целое положительное число.");
}