using CommandLine;

namespace RabbitEater;

public class Options
{
    [Option('H', "hostname", Required = true, HelpText = "HostName")]
    public string HostName { get; set; }

    [Option('U', "username", Required = true, HelpText = "Username")]
    public string UserName { get; set; }

    [Option('W', "password", Required = true, HelpText = "Password")]
    public string Password { get; set; }

    [Option('P', "port", Required = true, HelpText = "Port")]
    public int Port { get; set; }

    [Option('Q', "queue", Required = true, HelpText = "queue name")]
    public string Queue { get; set; }

    [Option('E', "exchange", Required = false, HelpText = "exchange name")]
    public string? Exchange { get; set; }

    [Option('R', "routingkey", Required = false, HelpText = "routingkey name")]
    public string? RoutingKey { get; set; }

    [Option('O', "path", Required = false, HelpText = "path to outputfile")]
    public string? OutputPath { get; set; }
}