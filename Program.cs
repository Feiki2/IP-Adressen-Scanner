static void Main(string[] args)
{
    var options = new ScanOptions { StartIp = "192.168.1.1", EndIp = "192.168.1.10" };
    if (args.Length >= 2) { options.StartIp = args[0]; options.EndIp = args[1]; }
    // Scan wird noch nicht aufgerufen - kommt im naechsten Commit
}
