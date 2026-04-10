namespace IpScanner;

/// <summary>
/// Gibt Scan-Ergebnisse aus: auf der Konsole und/oder in eine Datei
/// </summary>
public class ResultPrinter
{
    /// <summary>
    /// Druckt alle Ergebnisse auf die Konsole
    /// Online-Geraete werden gruen, offline-Geraete grau angezeigt
    /// </summary>
    public void PrintToConsole(List<ScanResult> results)
    {
        Console.WriteLine();
        Console.WriteLine("=== Scan-Ergebnisse ===");
        Console.WriteLine($"Gefunden: {results.Count} IPs geprueft");
        Console.WriteLine();

        foreach (var r in results)
        {
            if (r.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"[ONLINE] {r.IpAddress,-18}");

                // Ports ausgeben falls geprueft
                if (r.OpenPorts.Count > 0)
                {
                    var openList = r.OpenPorts
                        .Where(p => p.Value)
                        .Select(p => p.Key.ToString());
                    Console.Write($" Offene Ports: {string.Join(", ", openList)}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"[offline] {r.IpAddress}");
            }
        }

        // Farbe zuruecksetzen
        Console.ResetColor();
        Console.WriteLine("======================");
    }

    /// <summary>
    /// Speichert nur die Online-Geraete in eine Textdatei
    /// </summary>
    public void SaveToFile(List<ScanResult> results, string path)
    {
        var lines = new List<string>();
        lines.Add($"IP-Scan vom {DateTime.Now:dd.MM.yyyy HH:mm}");
        lines.Add(new string('-', 40));

        foreach (var r in results.Where(r => r.IsAlive))
        {
            string ports = r.OpenPorts.Count > 0
                ? " Ports: " + string.Join(", ",
                    r.OpenPorts.Where(p => p.Value).Select(p => p.Key))
                : string.Empty;
            lines.Add($"ONLINE: {r.IpAddress}{ports}");
        }

        File.WriteAllLines(path, lines);
        Console.WriteLine($"Ergebnisse gespeichert in: {path}");
    }
}
