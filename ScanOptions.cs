namespace IpScanner; 

/// <summary> 

/// Konfigurationsklasse: Alle Einstellungen fuer den Scan 

/// </summary> 

public class ScanOptions 
{ 

    // Startadresse des Scans (z.B. 192.168.1.1) 

    public string StartIp { get; set; } = string.Empty; 

 

    // Endadresse des Scans (z.B. 192.168.1.254) 

    public string EndIp { get; set; } = string.Empty; 

 

    // Zeitlimit pro Ping in Millisekunden 

    public int TimeoutMs { get; set; } = 500; 

 

    // Liste der zu pruefenden TCP-Ports (leer = nur Ping) 

    public List<int> Ports { get; set; } = new(); 

 

    // Pfad zur Ausgabedatei (leer = keine Dateiausgabe) 

    public string OutputFile { get; set; } = string.Empty;
}