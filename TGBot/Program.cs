using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resources;
using Telegram.Bot;
using TGBot.Telegram;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<Bot>();
    }).Build();
host.Services.GetService<Bot>()!.Start();
await host.RunAsync();