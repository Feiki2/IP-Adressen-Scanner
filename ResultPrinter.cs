public void PrintToConsole(List<ScanResult> results)
{
    foreach (var r in results)
        if (r.IsAlive) Console.WriteLine($"[ONLINE] {r.IpAddress}");
        else           Console.WriteLine($"[offline] {r.IpAddress}");
}

public void SaveToFile(List<ScanResult> results, string path)
{
    var lines = results.Where(r => r.IsAlive)
                       .Select(r => $"ONLINE: {r.IpAddress}");
    File.WriteAllLines(path, lines);
}

Console.ForegroundColor = ConsoleColor.Green;  // vor ONLINE
Console.ForegroundColor = ConsoleColor.DarkGray;  // vor offline
Console.ResetColor();  // <-- NEU: nach der Schleife
