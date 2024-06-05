using AtonTestTask.Interfaces;
using AtonTestTask.Models;
using System.Globalization;
using System.Text;

namespace AtonTestTask.Services
{
    public class FoodPricesService : IFoodPricesService
    {
        private readonly List<IFood> _foods;

        public FoodPricesService()
        {
            _foods = new List<IFood>();
        }

        public IFood GetFood(string name)
        {
            return _foods.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
        public List<IFood> GetFoods()
        {
            return _foods;
        }
        public void LoadFoodPricesFromFile(string path)
        {
            using var reader = new StreamReader(path, Encoding.UTF8);
            var culture = new CultureInfo("en-us");
            while (!reader.EndOfStream)
            {
                var data = reader.ReadLine().Split('=');
                double.TryParse(data[1], culture, out double price);
                _foods.Add(FoodFactory.CreateFood(data[0], price));
            }
        }
    }
}
