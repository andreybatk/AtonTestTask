using AtonTestTask.Models;

namespace AtonTestTask.Interfaces
{
    public interface IAnimalInfoService
    {
        public double GetPrice(Animal animal);
        public void LoadAnimalsInfoFromFile(string path);
    }
}