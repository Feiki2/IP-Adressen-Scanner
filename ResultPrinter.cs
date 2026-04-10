public void PrintToConsole(List<ScanResult> results)
{
    foreach (var r in results)
        if (r.IsAlive) Console.WriteLine($"[ONLINE] {r.IpAddress}");
        else           Console.WriteLine($"[offline] {r.IpAddress}");
}
