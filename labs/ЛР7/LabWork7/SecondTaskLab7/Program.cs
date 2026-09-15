using System.Diagnostics;

Stopwatch sw = new();
Stopwatch totalStopwatch = new();
TimeSpan ts = new();
void ReadFile(string Path)
{
    string[] fileText = File.ReadAllLines(Path);
    foreach (string line in fileText)
    {
        Console.WriteLine(line);
    }
}

async void ApiConnect(double Value)
{
    HttpClient client = new();
    var responce = client.GetStringAsync("https://search.worldbank.org/api/v3/wds?format=json&qterm=energy&display_title=water&fl=display_title&rows=2&os=20");
    Console.WriteLine(responce.Result);
}

totalStopwatch.Start();
sw.Start();
ReadFile("text.txt");
PrintReadFileElapsed(ts);

sw.Start();
ReadFile("text.txt");
PrintReadFileElapsed(ts);

sw.Start();
ReadFile("text.txt");
PrintReadFileElapsed(ts);

sw.Start();
ApiConnect(60);
PrintMathElapsed(ts);

sw.Start();
ApiConnect(60);
PrintMathElapsed(ts);

sw.Start();
ApiConnect(60);
PrintMathElapsed(ts);

totalStopwatch.Stop();
TimeSpan totalTimeSpan = totalStopwatch.Elapsed;
Debug.WriteLine($"[{DateTime.Now}] Total time elapsed = {totalTimeSpan.Milliseconds} ms");
File.AppendAllText("timings.log", $"[{DateTime.Now}] Total time elapsed = {totalTimeSpan.Milliseconds} ms{Environment.NewLine}");


void PrintReadFileElapsed(TimeSpan ts)
{
    sw.Stop();
    ts = sw.Elapsed;
    sw.Restart();
    Debug.WriteLine($"[{DateTime.Now}] Operation: ReadFile Elapsed = {ts.Milliseconds} ms");
    File.AppendAllText("timings.log", $"[{DateTime.Now}] Operation: ReadFile Elapsed = {ts.Milliseconds} ms{Environment.NewLine}");
}

void PrintMathElapsed(TimeSpan ts)
{
    sw.Stop();
    ts = sw.Elapsed;
    sw.Restart();
    Debug.WriteLine($"[{DateTime.Now}] Operation: ApiConnect Elapsed = {ts.Milliseconds} ms");
    File.AppendAllText("timings.log", $"[{DateTime.Now}] Operation: ApiConnect Elapsed = {ts.Milliseconds} ms{Environment.NewLine}");
}