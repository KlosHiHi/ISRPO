using System.Diagnostics;

Random random = new();

var sourceSwitchStorage = new SourceSwitch("StorageSwitch")
{
    Level = SourceLevels.Information
};

var traceStorage = new TraceSource("Storage")
{
    Switch = sourceSwitchStorage
};

traceStorage.Listeners.Clear();
traceStorage.Listeners.Add(new TextWriterTraceListener("storage_1.log", "fileListener"));
traceStorage.Listeners.Add(new ConsoleTraceListener());

try
{
    File.AppendAllText("info.txt", "Кажется мы добавили новые данные\n");

    var fileData = File.ReadAllText("info.txt");
    traceStorage.TraceEvent(TraceEventType.Information, 1, $"[{DateTime.Now}] {fileData}");
    Console.WriteLine(fileData);

    traceStorage.TraceEvent(TraceEventType.Warning, 2, $"[{DateTime.Now}] Начинаем проверку!!!");
    if (random.Next(2) == 1)
    {
        traceStorage.TraceEvent(TraceEventType.Verbose, 0, $"[{DateTime.Now}] Начинаем удаление файла операций");
        File.Delete("info.txt");
    }
}
catch (Exception ex)
{
    traceStorage.TraceEvent(TraceEventType.Error, 3, $"[{DateTime.Now}] {ex.Message}");
}

traceStorage.Flush();
traceStorage.Close();