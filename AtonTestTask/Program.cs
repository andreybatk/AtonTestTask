using AtonTestTask.Interfaces;
using AtonTestTask.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AtonTestTask
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection()
                 .AddSingleton<IFoodPricesService, FoodPricesService>()
                 .AddSingleton<IAnimalInfoService, AnimalInfoService>()
                 .AddSingleton<IAnimalService, AnimalService>()
                 .BuildServiceProvider();

            services.GetRequiredService<IFoodPricesService>().LoadFoodPricesFromFile("prices.txt");
            services.GetRequiredService<IAnimalInfoService>().LoadAnimalsInfoFromFile("animals.csv");
            services.GetRequiredService<IAnimalService>().LoadAnimalsFromFile("zoo.csv");
            var result = services.GetRequiredService<IAnimalService>().CalculateMoney();
            Console.WriteLine(String.Format("{0:C2}", result));
        }
    }
}