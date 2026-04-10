namespace IpScanner;

/// <summary>
/// Einstiegspunkt des IP-Scanners
/// Verarbeitet Kommandozeilenargumente und startet den Scan
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("IP-Adressen-Scanner v1.0");
        Console.WriteLine("========================");

        // Standard-Konfiguration
        var options = new ScanOptions
        {
            StartIp    = "192.168.1.1",
            EndIp      = "192.168.1.10", // kurzer Bereich zum Testen
            TimeoutMs  = 500,
            Ports      = new List<int> { 80, 443, 22 },
            OutputFile = "scan_results.txt"
        };

        // Kommandozeilen-Argumente auswerten
        if (args.Length >= 2)
        {
            options.StartIp = args[0];
            options.EndIp   = args[1];
        }

        Console.WriteLine($"Scanne: {options.StartIp} bis {options.EndIp}");
        Console.WriteLine($"Ports:  {string.Join(", ", options.Ports)}");
        Console.WriteLine("Bitte warten...");

        // Scan starten
        var scanner = new Scanner(options);
        var results = scanner.RunScan();

        // Ergebnisse ausgeben
        var printer = new ResultPrinter();
        printer.PrintToConsole(results);

        if (!string.IsNullOrEmpty(options.OutputFile))
            printer.SaveToFile(results, options.OutputFile);
    }
}
