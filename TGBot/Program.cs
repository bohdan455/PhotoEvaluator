using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resources;
using Telegram.Bot;
using TGBot.Extensions;
using TGBot.Telegram;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<Bot>();
        services.AddDbContext<PhotoEvaluatorContext>(options =>
        {
            options.UseSqlServer(DataBaseSettings.ConnectionString);
        });
        services.AddCustomServices();
        services.AddRepositories();
    }).Build();
host.Services.GetService<Bot>()!.StartReceivingUpdates();
await host.RunAsync();