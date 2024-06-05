using AtonTestTask.Interfaces;
using AtonTestTask.Models;
using System.Globalization;
using System.Text;

namespace AtonTestTask.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalInfoService _infoService;
        private readonly List<Animal> _animals;

        public AnimalService(IAnimalInfoService infoService)
        {
            _infoService = infoService;
            _animals = new List<Animal>();
        }

        public double CalculateMoney()
        {
            return _animals.Sum(_infoService.GetPrice);
        }
        public void LoadAnimalsFromFile(string path)
        {
            using var reader = new StreamReader(path, Encoding.UTF8);
            var culture = new CultureInfo("en-us");
            while (!reader.EndOfStream)
            {
                var data = reader.ReadLine().Split(';');
                double.TryParse(data[2], culture, out double weigth);
                _animals.Add(new Animal
                {
                    Kind = data[0],
                    Name = data[1],
                    Weigth = weigth
                });
            }
        }
    }
}
