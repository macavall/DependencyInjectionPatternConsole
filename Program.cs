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


        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGreetingService, GreetingService>();
        }

        public interface IGreetingService
        {
            public void Greet(string name);
        }

        public class  GreetingService : IGreetingService
        {
            public void Greet(string name)
            {
                Console.WriteLine($"Hello, {name}");
            }
        }
    }
}
