// NEU: Scanner.cs - nur PingHost() und leeres RunScan() 

public class Scanner 
{ 
    private bool PingHost(string ip) 

    { 
        using var ping = new Ping(); 

        var reply = ping.Send(ip, 500); 

        return reply.Status == IPStatus.Success; 
    } 
} 