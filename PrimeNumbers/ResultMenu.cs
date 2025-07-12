using System.Text;

public class ResultMenu
{
    public static void WriteConsole(Dictionary<int, double> primesTimes, int count)
    {
        string fullReport = GenerateFullReport(primesTimes, count, "нано сек");
        Console.WriteLine(fullReport);
    }

    public static void InFile(Dictionary<int, double> primesTimes, int count)
    {
        try
        {
            Console.Write("Введите имя файла для сохранения (например, primes.txt): ");
            string fileName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Имя файла не может быть пустым.");
                return;
            }
            
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            
            if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".txt";
            }

            string filePath = Path.Combine(appPath, fileName);

            string fullReport = GenerateFullReport(primesTimes, count, "нано сек");

            File.WriteAllText(filePath, fullReport);
            Console.WriteLine($"Данные успешно сохранены в файл: {filePath}");

        }
        catch (Exception)
        {
            Console.WriteLine("Ошибка при сохранении в файл");
        }
    }

    private static string GenerateFullReport(Dictionary<int, double> primesTimes, int count, string timeUnit)
    {
        var report = new StringBuilder();
        double totalTime = 0;
        int i = 1;

        foreach (var entry in primesTimes)
        {
            report.AppendLine($"{i}. простое число: {entry.Key}, время расчета: {entry.Value} {timeUnit}");
            totalTime += entry.Value;
            i++;
        }

        double avgTime = totalTime / count;
        report.AppendLine("\nИтоговая статистика:")
            .AppendLine($"Суммарное время: {totalTime} {timeUnit}")
            .AppendLine($"Среднее время: {avgTime} {timeUnit}")
            .AppendLine("Здесь могла быть ваша реклама xD");

        return report.ToString();
    }
}