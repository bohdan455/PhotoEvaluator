using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resources;
using Serilog;
using Telegram.Bot;
using TGBot.Extensions;
using TGBot.Stages;
using TGBot.Stages.Interfaces;
using TGBot.Telegram;
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<Bot>();
        services.AddSingleton<IChatStage, ChatStage>();
        services.AddDbContext<PhotoEvaluatorContext>(options =>
        {
            options.UseSqlServer(DataBaseSettings.ConnectionString);
        });

        services.AddMiddleware();
        services.AddCustomServices();
        services.AddRepositories();
        services.AddStages();
        services.AddCommon();
    })
    .UseSerilog()
    .Build();

host.Services.GetService<Bot>()!.StartReceivingUpdates();
await host.RunAsync();
