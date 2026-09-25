using LabWork6;
using NLog;

AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
{
    Console.WriteLine("Произошла ошибка. Подробности в логах.");
    File.AppendAllText("crash.log", $"------------------------[{DateTime.Now}] {((Exception)e.ExceptionObject).Message}{Environment.NewLine}");
}

Lab.Task1();
Lab.Task2(-3);
Task3 task3 = new();
var count = task3.CountLines("C:\\Temp\\ispp31\\МДК 02.02\\labs\\ЛР6\\LabWork6\\LabWork6\\bin\\Debug\\net10.0\\FULES.txt");
Console.WriteLine($"Количество строк: {count}.");

public class Task3
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public int CountLines(string fileName)
    {
        int count = 0;
        string line = "";
        //try
        {
            using var file = new StreamReader(fileName);

            while ((line = file.ReadLine()) != null)
                count++;

            return count;
        }
        //catch (FileNotFoundException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    logger.Info(ex.Message);
        //    return -1;
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    logger.Error(ex.Message);
        //    return -1;
        //}
    }
}

public static class Lab
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public static void Task1()
    {
        //try
        {
            Console.WriteLine("Введите два числа для деления: ");
            Console.Write("Делимое ");

            var input = Console.ReadLine();
            if (!int.TryParse(input, out int dividendValue))
                throw new FormatException();
            Console.Write("Делитель ");
            input = Console.ReadLine();

            if (!int.TryParse(input, out int dividerValue))
                throw new FormatException();

            if (dividerValue == 0)
                throw new DivideByZeroException();

            //Console.WriteLine(dividendValue / dividerValue);
        }
        //catch (FormatException ex)
        //{
        //    Console.WriteLine("Введён неверный формат");
        //    logger.Info("Введён неверный формат");
        //}
        //catch (DivideByZeroException ex)
        //{
        //    Console.WriteLine("Ошибка, деление на ноль невозможно");
        //    logger.Info("Ошибка, деление на ноль невозможно");
        //}
        //catch (Exception ex)
        //{
        //    logger.Info($"Ошибка: {ex.Message}\nСтек вызовов:\n{ex.StackTrace}");
        //    Console.WriteLine($"Ошибка: {ex.Message}");
        //    Console.WriteLine($"Стек вызовов:\n{ex.StackTrace}");
        //}
    }

    public static void Task2(int age)
    {
        //try
        {
            if (age < 0)
                throw new NegativeNumberException("Ваш возраст отрицательный, так быть не может.");

            Console.WriteLine($"Ваш возраст: {age}");
            logger.Info($"Ваш возраст: {age}");
        }
        //catch (NegativeNumberException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    logger.Info(ex.Message);
        //}
    }
}
