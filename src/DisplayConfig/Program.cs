// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DisplayConfig;
using Commands;

var builder = new HostBuilder();

builder.ConfigureServices(x =>
{
    x.AddScoped<DisplayOperator>();
    x.AddScoped<ConfigManager>();
});

return await builder.RunCommandLineApplicationAsync<MainCommand>(args);
