using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspireBudgetTelegramBot.Models;
using AspireBudgetTelegramBot.Options;
using AspireBudgetTelegramBot.Services;
using AspireBudgetTelegramBot.Services.Authentication;
using AspireBudgetTelegramBot.Services.BackgroundQueue;
using AspireBudgetTelegramBot.Workers;
using MediatR;

namespace AspireBudgetTelegramBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<TelegramOptions>(hostContext.Configuration.GetSection(nameof(TelegramOptions)))
                        .Configure<AspireOptions>(hostContext.Configuration.GetSection(nameof(AspireOptions)))
                        .AddSingleton(typeof(IBackgroundQueue<TelegramMessage>),
                            typeof(BackgroundQueue<TelegramMessage>))
                        .AddSingleton(typeof(IBackgroundQueue<TelegramReplyMessage>),
                            typeof(BackgroundQueue<TelegramReplyMessage>))
                        .AddSingleton<TelegramBotService>()
                        .AddSingleton<AspireApiService>()
                        .AddSingleton(typeof(IAuthenticationService), typeof(InMemoryAuthenticationService))
                        .AddScoped<TransactionService>()
                        .AddHostedService<TelegramWorker>()
                        .AddHostedService<IncomingMessageWorker>()
                        .AddMediatR(typeof(Program));
                });
    }
}
