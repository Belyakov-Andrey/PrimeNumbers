using System.Text;

public class ResultMenu
{
    public static void Menu(Dictionary<int, double> primesTimes, int count)
    {
        try
        {
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
    }


    static void WriteConsole(Dictionary<int, double> primesTimes, int count)
        {
            string fullReport = GenerateFullReport(primesTimes, count, "нано сек");
            Console.WriteLine(fullReport);
        }


        static void InFile(Dictionary<int, double> primesTimes, int count)
        {
            try
            {
                Console.WriteLine("\nВведите имя файла для сохранения");
                Console.Write("Название файла: ");
                string fileName = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    Console.WriteLine("Имя файла не может быть пустым.");
                    return;
                }

                if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    fileName += ".txt";

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, fileName);

                if (File.Exists(filePath))
                {
                    Console.WriteLine($"\nФайл '{fileName}' уже существует.");
                    Console.WriteLine("Для перезаписи введите - 1");
                    Console.WriteLine("Для отмены введите - Любой символ кроме 1");
                    Console.Write("Ваш выбор: ");
                    string input = Console.ReadLine();
                    Console.WriteLine();

                    if (input != "1")
                    {
                        Console.WriteLine("Сохранение отменено.");
                        return;
                    }
                }

                string fullReport = GenerateFullReport(primesTimes, count, "нано сек");

                File.WriteAllText(filePath, fullReport);

                Console.WriteLine($"Файл сохранён: {filePath}");
            }
            catch (Exception)
            {
                Console.WriteLine("Не предвиденная ошибка =(");
            }
        }

        static string GenerateFullReport(Dictionary<int, double> primesTimes, int count, string timeUnit)
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
