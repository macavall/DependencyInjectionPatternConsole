using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var greetingService = serviceProvider.GetService<IGreetingService>();
            greetingService.Greet("World");
            
            var greetingService2 = serviceProvider.GetService<IGreetingService>();
            greetingService2.Greet("World");

            Console.ReadLine();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IGreetingService, GreetingService>();
            //services.AddScoped<IGreetingService, GreetingService>();
            services.AddSingleton<IGreetingService, GreetingService>();
        }

        public interface IGreetingService
        {
            public void Greet(string name);
        }

        public class  GreetingService : IGreetingService
        {
            public int GreetingCounter;

            public void Greet(string name)
            {
                Console.WriteLine($"Hello, {name}");
                GreetingCounter++;
                Console.WriteLine($"Greeting Counter: {GreetingCounter}");
            }
        }
    }
}
