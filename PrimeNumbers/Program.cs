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

    int answer;
    bool isFirstAttempt = true;

    do
    {
        if (isFirstAttempt)
        {
            Console.WriteLine("\nКак вы хотите вывести результат?");
            Console.WriteLine("1 - в консоль");
            Console.WriteLine("2 - в файл");
            Console.WriteLine("3 - завершить программу");
        }
        else
        {
            Console.WriteLine("\nДЛЯ КОГО НАПИСАНО ТО? 1, 2 или 3?");
        }

        Console.Write("Ваш выбор: ");
        string input = Console.ReadLine();
        
        if (!int.TryParse(input, out answer)) 
        {
            isFirstAttempt = false;
            continue;
        }

        switch (answer)
        {
            case 1:
                ResultMenu.WriteConsole(primesTimes, count);
                break;
            case 2:
                ResultMenu.InFile(primesTimes, count);
                break;
            case 3:
                Console.WriteLine("\nУдачного дня!");
                break;
            default:
                isFirstAttempt = false;
                continue;
        }

        break;

    } while (true);
}
catch (Exception)
{
    Console.WriteLine("Введите целое положительное число.");
}
