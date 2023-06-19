using BLL.Services;
using BLL.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories.Realizations.Main;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGBot.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ITelegramUserService,TelegramUserService>();
            services.AddTransient<ISearchAlghorithmService,SearchAlghorithmService>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<ITelegramUserRepository, TelegramUserRepository>();
            return services;
        }
    }
}
