
using System.Reflection.Metadata.Ecma335;

void MathStuff(int firstValue, int secondValue)
{
    Console.WriteLine($"Сложение {firstValue + secondValue}");
    Console.WriteLine($"Вычитание {firstValue - secondValue}");
    Console.WriteLine($"Умножение {firstValue * secondValue}");
    Console.WriteLine($"Деление {firstValue / secondValue}");
}

try
{
    Console.WriteLine("Введите два целых числа: ");
    int firstValue = int.Parse(Console.ReadLine());
    int secondValue = int.Parse(Console.ReadLine());

    MathStuff(firstValue, secondValue);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
    File.AppendAllText("log.txt", $"[{DateTime.Now}] {ex.Message}\n");
}
catch (FormatException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
    File.AppendAllText("log.txt", $"[{DateTime.Now}] {ex.Message}\n");
}
catch (OverflowException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
    File.AppendAllText("log.txt", $"[{DateTime.Now}] {ex.Message}\n");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
    File.AppendAllText("log.txt", $"[{DateTime.Now}] {ex.Message}\n");
}