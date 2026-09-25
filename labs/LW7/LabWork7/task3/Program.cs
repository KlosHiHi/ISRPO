using System.Diagnostics;


var ts = new TraceSource("Calculator")
{
    Switch = new SourceSwitch("MyCalculatorSwitch") { Level = SourceLevels.Verbose }
};

ts.Listeners.Clear();
ts.Listeners.Add(new TextWriterTraceListener("trace_verbose.log", "fileListener"));
ts.Listeners.Add(new ConsoleTraceListener()); 

Console.WriteLine("Введите два целых числа: ");
int firstValue = int.Parse(Console.ReadLine());
int secondValue = int.Parse(Console.ReadLine());

ts.TraceEvent(TraceEventType.Verbose, 1, $"Входные параметры: ({firstValue}, {secondValue})");
try
{
    ts.TraceInformation($"[{DateTime.Now}] Начинаем выполнение операций");
    Console.WriteLine($"Сложение {firstValue + secondValue}");
    Console.WriteLine($"Вычитание {firstValue - secondValue}");
    Console.WriteLine($"Умножение {firstValue * secondValue}");
    ts.TraceEvent(TraceEventType.Warning, 2, $"[{DateTime.Now}] Начинаем деление!!!");
    Console.WriteLine($"Деление {firstValue / secondValue}");
}
catch (Exception ex)
{
    ts.TraceEvent(TraceEventType.Error, 3, $"[{DateTime.Now}] {ex.Message}");
}

ts.Flush();
ts.Close();
ts.TraceInformation($"Проверка");