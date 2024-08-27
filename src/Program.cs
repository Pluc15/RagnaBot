
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.RegisterServices();

        var host = builder.Build();
        host.Run();
    }
}