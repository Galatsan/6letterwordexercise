using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using _6letterwordexercise.Interfaces;
using _6letterwordexercise.Models;
using _6letterwordexercise.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _6letterwordexercise
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var sixLetterWordsFacade = serviceProvider.GetRequiredService<ISixLetterWordsFacade>();

            Console.WriteLine("Started");
            await sixLetterWordsFacade.Process();
            Console.WriteLine("Finished");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            services.AddSingleton(configuration)
            .AddTransient<IOtputDataSaveService, OtputDataSaveService>()
            .AddTransient<IInputDataReadService, InputDataReadService>()
            .AddTransient<IVariantsBuilderService, VariantsBuilderService>()
            .AddTransient<IPrepareOutputData, PrepareOutputData>()
            .AddTransient<ISixLetterWordsFacade, SixLetterWordsFacade>()
            .AddTransient<IEqualityComparer<IEnumerable<string>>, EnumerableStringComparer>()
            .Configure<Settings>(configuration.GetSection("Settings"));
        }
    }
}
