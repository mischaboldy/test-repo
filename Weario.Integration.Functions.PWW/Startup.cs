using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weario.Integration.Functions.PWW.Configuration;

[assembly: FunctionsStartup(typeof(Weario.Integration.Functions.PWW.Startup))]

namespace Weario.Integration.Functions.PWW
{
    public class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            Console.WriteLine(config["Test"]);

            builder.Services.AddOptions<AppSettings>().Bind(config.GetSection("AppSettings"));
        }
    }
}
