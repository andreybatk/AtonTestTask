using AtonTestTask.Interfaces;

namespace AtonTestTask.Models
{
    public class Meat : IFood
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}