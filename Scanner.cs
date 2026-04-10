// NEU: Scanner.cs - nur PingHost() und leeres RunScan() 

public class Scanner 
{ 
    private bool PingHost(string ip) 
    { 
        using var ping = new Ping(); 

        var reply = ping.Send(ip, 500); 

        return reply.Status == IPStatus.Success; 
    } 
    // ERGAENZT in Scanner.cs: RunScan() Methode 

    public List<ScanResult> RunScan() 
    { 
        var results = new List<ScanResult>(); 

        uint start = IpToUint(_options.StartIp); 

        uint end   = IpToUint(_options.EndIp); 

        for (uint i = start; i <= end; i++) 
        { 
            string ip = UintToIp(i); 

            results.Add(new ScanResult { IpAddress = ip, IsAlive = PingHost(ip) }); 
        } 
        return results; 
    } 
} 

public class ScanResult
{
    public string IpAddress { get; set; } = string.Empty;
    public bool IsAlive { get; set; }
    public Dictionary<int, bool> OpenPorts { get; set; } = new();
}
