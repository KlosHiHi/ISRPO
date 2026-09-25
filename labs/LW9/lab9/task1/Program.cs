using System.Text;

//Task 1
string filePath = "data.txt";
await ReadFromFile(filePath);

async Task ReadFromFile(string filePath)
{
    if (!File.Exists(filePath))
    {
        Console.WriteLine("File not found.");
        return;
    }

    using (var reader = new StreamReader(filePath, Encoding.Unicode, false, 8192))
    {
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
            Console.WriteLine(line);
    }
}

//Task 2
await WriteToFile(filePath, "Some data to be written to the file");

async Task WriteToFile(string filePath, string data)
{
    using (var writer = new StreamWriter(filePath, true, Encoding.UTF8, 8192))
    {
        await writer.WriteLineAsync(data);
    }
}

//Task 3

// Вычисление чисел Фибоначчи (сумма двух предыдущих значений: 0,1,1,2,3,5,8,...)
Console.WriteLine("Fibonacci Sequence:");
for (int i = 0; i < 20; i++)
{
    // Оптимизация: избежать повторного вычисления
    Console.WriteLine($"Fib({i}) = {Fibonacci(i)}");
}
// Нерациональный алгоритм для вычисления чисел Фибоначчи
int Fibonacci(int n)
{
    Dictionary<int, int> _fibonacciCach;
    if (n <= 1)
        return n;
    // Оптимизация: кэширование и улучшение алгоритма
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}