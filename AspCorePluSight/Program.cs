using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
namespace AspCorePluSight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog((ctx, cfg) =>
                   {
                       cfg.ReadFrom.Configuration(ctx.Configuration)
                       .MinimumLevel.Error()
                       .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                       .Enrich.FromLogContext()
                       .Enrich.WithMachineName()
                       .Enrich.WithProperty("Application", ctx.Configuration["Application"])
                       .Enrich.WithEnvironmentUserName()
                       .WriteTo.File(@"C:\Users\hyarimaga\Desktop\New folder\a.txt", outputTemplate: "[{Timestamp:HH:mm:ss.fff} {Level:u3}] {SourceContext}: {Message:lj}{NewLine}{Exception}")
                       .WriteTo.RollingFile("KeLogs\\Web-{Date}.log", outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Application} {Level:u3}] {SourceContext}: {Message:lj}{NewLine}{Exception}");
                   }).Build();
    }
}
