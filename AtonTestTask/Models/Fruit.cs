using AtonTestTask.Interfaces;

namespace AtonTestTask.Models
{
    public class Fruit : IFood
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}