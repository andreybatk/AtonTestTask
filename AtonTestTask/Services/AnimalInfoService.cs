using AtonTestTask.Interfaces;
using AtonTestTask.Models;
using System.Globalization;
using System.Text;

namespace AtonTestTask.Services
{
    public class AnimalInfoService : IAnimalInfoService
    {
        private readonly IFoodPricesService _foodPricesService;
        private readonly List<AnimalInfo> _animalInfo;

        public AnimalInfoService(IFoodPricesService foodPricesService)
        {
            _foodPricesService = foodPricesService;
            _animalInfo = new List<AnimalInfo>();
        }

        public double GetPrice(Animal animal)
        {
            var animalInfo = _animalInfo.FirstOrDefault(x => x.Kind == animal.Kind);

            if (animalInfo is null)
            {
                throw new Exception($"Животное {animal.Kind} не существует!");
            }

            if (animalInfo.MeatCoeff == 0)
            {
                var food = _foodPricesService.GetFood(animalInfo.FoodName);
                return animal.Weigth * animalInfo.Coeff * food.Price;
            }
            else
            {
                var foods = _foodPricesService.GetFoods();
                var meatCoeff = animalInfo.MeatCoeff / 100;
                var fruitCoeff = 100 - animalInfo.MeatCoeff / 100;
                return meatCoeff * animal.Weigth + fruitCoeff * animal.Weigth;
            }
        }
        public void LoadAnimalsInfoFromFile(string path)
        {
            using var reader = new StreamReader(path, Encoding.UTF8);
            var culture = new CultureInfo("en-us");
            while (!reader.EndOfStream)
            {
                var data = reader.ReadLine().Split(';');
                double.TryParse(data[1], culture, out double coeff);
                double currentMeatCoeff = 0;
                if (data.Length > 2)
                {
                    double.TryParse(data[3].Replace("%", ""), culture, out double meatCoeff);
                    currentMeatCoeff = meatCoeff;
                }
                _animalInfo.Add(new AnimalInfo
                {
                    Kind = data[0],
                    Coeff = coeff,
                    FoodName = data[2],
                    MeatCoeff = currentMeatCoeff
                });
            }
        }
    }
}
