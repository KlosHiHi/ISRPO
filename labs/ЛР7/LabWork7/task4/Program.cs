using System.Diagnostics;

Console.WriteLine("Hello, World!");

var sourceSwitch = new SourceSwitch("MyAppSwitch")
{
    Level = SourceLevels.Warning
};

var traceSource = new TraceSource("MyApp")
{
    Switch = sourceSwitch
};

var sourceSwitchStorage = new SourceSwitch("StorageSwitch")
{
    Level = SourceLevels.Warning
};

var traceStorage = new TraceSource("Storage")
{
    Switch = sourceSwitch
};

traceSource.Listeners.Clear();
traceSource.Listeners.Add(new TextWriterTraceListener("trace.log", "fileListener"));
traceSource.Listeners.Add(new ConsoleTraceListener());

traceSource.Listeners.Clear();
traceSource.Listeners.Add(new TextWriterTraceListener("storage.log", "fileListener"));

